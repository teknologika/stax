/*Copyright (c) 2010 Bruce McLeod
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation
and/or other materials provided with the distribution.

Neither the name of Stax nor the names of its contributors may be used to endorse or promote products derived from this
software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY ANDFITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Configuration;
using System.ComponentModel;
using System.Xml.Linq;

namespace Stax.TFS2008Common
{
    public class TFSWriterParameters
    {
        public string TFSQuery;
        public string OutputFolder;
        
        public TFSWriterParameters(string TFSQuery, string OutputFolder)
        {

        }
        

    }
    
    public class TFSWriter
    {
 
        Assembly _assembly;
        string _ProjectFileTop;
        string _ProjectFileBottom;

        /// <summary>
        /// Generates the project.
        /// </summary>
        /// <param name="WorkItemQuery">The work item query.</param>
        /// <param name="targetDirectory">The target directory.</param>
        public void GenerateProject(BackgroundWorker worker, string WorkItemQuery, string targetDirectory)
        {
            targetDirectory = targetDirectory +  @"\TestGen\" + Environment.UserName.ToString() + "_" + Environment.MachineName + " " + DateTime.Now.ToString("yyyy-mm-dd hh_mm_ss");
           
            // Create the directory 
            DirectoryInfo outputDir = new DirectoryInfo(targetDirectory);
            outputDir.Create();
            
            
            // Clean the work item query
            if (!string.IsNullOrEmpty(WorkItemQuery))
            {
                WorkItemQuery = WorkItemQuery.Replace("@project", "'" + ConfigurationManager.AppSettings["TFSProject"].ToString() + "'");
            }
            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _ProjectFileTop = new StreamReader(_assembly.GetManifestResourceStream("Devtest.TFSCommon.CSProjPart1.txt")).ReadToEnd();
                _ProjectFileBottom = new StreamReader(_assembly.GetManifestResourceStream("Devtest.TFSCommon.CSProjPart2.txt")).ReadToEnd();

            }
            catch
            {
                Console.WriteLine("Error accessing resources");
                throw;
            }



            // Create Bob the stringBuilder :-)
            StringBuilder _bob = new StringBuilder();
            _bob.AppendLine(_ProjectFileTop);

            if (string.IsNullOrEmpty(WorkItemQuery))
            {
                 WorkItemQuery = ConfigurationManager.AppSettings["DefaultQuery"].ToString();
            }
            WorkItemCollection _testCaseCollection;
            _testCaseCollection = TfsManager.Query(WorkItemQuery);

            // Only add tests to the solution if they are actually returned.
            if (_testCaseCollection.Count > 0)
            {
                int lastPercent = 0;
                int totalNumberOfItems = _testCaseCollection.Count;
                int currentWorkItem = 0;
                int percentDone = 0;
                
                _bob.AppendLine("    <ItemGroup>");            
    
                // Loop through each of the returned work items.
                foreach (WorkItem workItem in _testCaseCollection)
                {
                    currentWorkItem++;
                    // Calculate the % done and update if we have increased
                    percentDone = (currentWorkItem *100) / totalNumberOfItems;
                    if (percentDone > lastPercent)
                    {
                        worker.ReportProgress(percentDone);
                    }
                    lastPercent = percentDone;

                    if (CheckTestNameForIllegalCharacters(workItem.Title))
                    {
                        _bob.Append("        <None Include=\"");
                        _bob.Append(workItem.Title);
                        _bob.AppendLine(".mtx\">");
                        _bob.AppendLine("            <CopyToOutputDirectory>Always</CopyToOutputDirectory>");
                        _bob.AppendLine("        </None>");

                        GenerateManualTest(targetDirectory, workItem);
                    }
                    // If the test name includes a character that is illegal for the windows file system, show an error and then continue.
                    else
                    {
                        string errorText = "Error generating test.\n\n The test name '" + workItem.Title + "' is invalid, the test case could not be generated.";
                        System.Windows.Forms.MessageBox.Show(errorText, "Manual Test Case Generator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                _bob.AppendLine("    </ItemGroup>");           
            }
            _bob.Append(_ProjectFileBottom);

            StreamWriter _streamWriter = new StreamWriter(targetDirectory + @"\ManualTestProject.csproj",false);
            _streamWriter.Write(_bob.ToString());
            _streamWriter.Close();
        }

        /// <summary>
        /// Generates the manual test.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="workItem">The work item.</param>
        public void GenerateManualTest(string targetDirectory, WorkItem workItem)
        {
            // Create Bob the stringBuilder :-)
            StringBuilder _bob = new StringBuilder();

            // Create the XML header
            _bob.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            
            // Create the root element of the manual test
            _bob.Append("<ManualTest xmlns=\"http://microsoft.com/schemas/VisualStudio/TeamTest/2006\" id=\"");
            _bob.Append(Guid.NewGuid().ToString());
            _bob.Append("\" name=\"");
            _bob.Append(workItem.Title);
            _bob.AppendLine("\">");
            _bob.AppendLine("");

            // Add the work item ID
            _bob.AppendLine("<Workitems>");
            _bob.Append("<Workitem>");
            _bob.Append(workItem.Id.ToString());
            _bob.AppendLine("</Workitem>");
            _bob.AppendLine("</Workitems>");
            _bob.AppendLine("");

            // Create the test body
            _bob.AppendLine("<BodyText>");
            _bob.Append("<![CDATA[");

            // Replace all the TFS line feeds with ones that work in the text document
            string alternateFieldName = ConfigurationManager.AppSettings["AlternateDescriptionFieldName"].ToString();
            if (string.IsNullOrEmpty(alternateFieldName))
            {
                _bob.Append(workItem.Title + "\n\r\n\r\n\r\n\r");
                _bob.Append(workItem.Description.Replace("\n","\n\r\n\r"));

            }
            else
            {
                string testDescription = workItem.Fields[alternateFieldName].Value.ToString();
                
                // Strip out the html
                testDescription = StripTags(testDescription);
                testDescription = workItem.Title + "\n\n" + testDescription;
                testDescription = testDescription.Replace("\n", "\n\r\n\r");
                _bob.Append(testDescription);
            }
            
            _bob.AppendLine("]]>");

            // Close out the document
            _bob.AppendLine("</BodyText>");
            _bob.AppendLine("</ManualTest>");

            // Write out the document to disk
            StreamWriter _streamWriter = new StreamWriter(targetDirectory + @"\" + workItem.Title + ".mtx", false);
            _streamWriter.Write(_bob.ToString());
            _streamWriter.Close();

        }

        public string StripTags(string HTML)
        {
            // Removes tags from passed HTML
            //System.Text.RegularExpressions.Regex objRegEx = new System.Text.RegularExpressions.Regex(HTML);


            // Replace BR tags with new lines
            HTML = HTML.Replace("<BR>", "\n");
            HTML = HTML.Replace("<br>", "\n");
            HTML = HTML.Replace("<BR/>", "\n");
            HTML = HTML.Replace("<br/>", "\n");

            // replace non breaking space with space
            HTML = HTML.Replace("&nbsp;", " ");
            HTML = System.Text.RegularExpressions.Regex.Replace(HTML, "<[^>]*>", "");
            return HTML;
        }


        /// <summary>
        /// Checks the test name for illegal characters.
        /// </summary>
        /// <param name="testName">Name of the test.</param>
        /// <returns></returns>
        private bool CheckTestNameForIllegalCharacters(string testName)
        {
            
            // Invalid file system characters / \ : * ? " < > |
            if (testName.Contains("/"))
                return false;
            if (testName.Contains(@"\"))
                return false;
            if (testName.Contains(":"))
                return false;
            if (testName.Contains("*"))
                return false;
            if (testName.Contains("?"))
                return false;
            if (testName.Contains("\""))
                return false;
            if (testName.Contains("<"))
                return false;
            if (testName.Contains(">"))
                return false;
            if (testName.Contains("|"))
                return false;
            if (testName.Contains("("))
                return false;
            if (testName.Contains(")"))
                return false;
            if (testName.Contains("'"))
                return false;
            if (testName.Contains("&"))
                return false;

            // If we don't find 
            return true;
        }

        public static string OpenSavedQuery(string fileName)
        {
            FileInfo wiqFile = new FileInfo(fileName);
            if (wiqFile.Exists)
            {
                StreamReader wiqReader = new StreamReader(fileName);
                string wiqFileContents = wiqReader.ReadToEnd();
                XElement wiqXml = XElement.Parse(wiqFileContents);
                return wiqXml.Element("Wiql").Value;
            }
            else
            {
                return null;
            }


        }

    }
}
