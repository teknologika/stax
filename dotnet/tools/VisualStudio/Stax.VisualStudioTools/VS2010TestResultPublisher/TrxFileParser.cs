using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace VS2010TestResultPublisher
{
    public class TrxFileParser
    {
        public TestResultCollection processTrxFile(string fileName, bool publishFailures, bool PublishErrorInformation)
        {
            TestResultCollection resultCollection = new TestResultCollection();
            //Holds the contents of the trx file
            string trxFileContents;

            //Read out the contents of the trx file
            using (StreamReader trxReader = new StreamReader(fileName))
            {
                trxFileContents = trxReader.ReadToEnd();
                trxReader.Close();
            }

            //Load the file contents into an XML document object
            XmlDocument trxFileXml = new XmlDocument();
            trxFileXml.LoadXml(trxFileContents);

            //Configure the namespace manager
            XmlNamespaceManager xmlManager = new XmlNamespaceManager(trxFileXml.NameTable);
            xmlManager.AddNamespace("ns", "http://microsoft.com/schemas/VisualStudio/TeamTest/2006");

            //Get the list of unit test result nodes
            XmlNodeList resultNodes = trxFileXml.GetElementsByTagName("UnitTestResult");
            resultCollection.Append(ProcessResultsNode(resultNodes, publishFailures, PublishErrorInformation));

            //Now do the same for Manual tests
            resultNodes = trxFileXml.GetElementsByTagName("ManualTestResult");
            resultCollection.Append(ProcessResultsNode(resultNodes, publishFailures, PublishErrorInformation));

            XmlNodeList definitionNodes = trxFileXml.GetElementsByTagName("TestDefinitions");
            AddWorkItemsToResults(resultCollection, trxFileXml);
            AddExecutionUserToResults(resultCollection, trxFileXml);

            return resultCollection;
        }

        private TestResultCollection ProcessResultsNode(XmlNodeList resultNodes, bool publishFailures, bool PublishErrorInformation)
        {
            TestResultCollection resultCollection = new TestResultCollection();
            foreach (XmlNode sourceNode in resultNodes)
            {
                //Send each result to the publish method
                TestResult singleResult = ProcessSingleTestNode(sourceNode);
                if (singleResult != null)
                {
                    resultCollection.Add(singleResult);
                }
            }
            return resultCollection;

        }

        private TestResultCollection AddWorkItemsToResults(TestResultCollection resultCollection, XmlDocument trxFileXml)
        {
            foreach (TestResult item in resultCollection)
            {
                string xpath = @"//ns:UnitTest[@name='" + item.TestName + "']/ns:Workitems/ns:Workitem";
                XmlNamespaceManager xmlManager = new XmlNamespaceManager(trxFileXml.NameTable);
                xmlManager.AddNamespace("ns", "http://microsoft.com/schemas/VisualStudio/TeamTest/2006");

                XmlNode tmpnode = trxFileXml.SelectSingleNode(xpath, xmlManager);
                // Get TFS Id
                if (tmpnode == null)
                {
                    xpath = @"//ns:ManualTest[@name='" + item.TestName + "']/ns:Workitems/ns:Workitem";
                    tmpnode = trxFileXml.SelectSingleNode(xpath, xmlManager);
                }

                if (tmpnode != null)
                {
                    item.TFSWorkItemId = Convert.ToInt32(tmpnode.InnerText.ToString());
                }

                // Get description
                if (tmpnode == null)
                {
                    xpath = @"//ns:UnitTest[@name='" + item.TestName + "']/ns:Description";
                    tmpnode = trxFileXml.SelectSingleNode(xpath, xmlManager);
                }

                if (tmpnode != null)
                {
                    item.Description = tmpnode.InnerText.ToString();
                }
            }
            return resultCollection;
        }

        private TestResultCollection AddExecutionUserToResults(TestResultCollection resultCollection, XmlDocument trxFileXml)
        {
            foreach (TestResult item in resultCollection)
            {
                string xpath = @"//ns:TestRun";
                XmlNamespaceManager xmlManager = new XmlNamespaceManager(trxFileXml.NameTable);
                xmlManager.AddNamespace("ns", "http://microsoft.com/schemas/VisualStudio/TeamTest/2006");

                XmlNode tmpnode = trxFileXml.SelectSingleNode(xpath, xmlManager);

                if (tmpnode != null)
                {
                    item.ExecutedBy = tmpnode.Attributes.GetNamedItem("runUser").Value;
                }
            }
            return resultCollection;
        }

        internal TestResult ProcessSingleTestNode(XmlNode theResultNode)
        {
            TestResult testResult = new TestResult();

            //Get the name and outcome of the test
            Regex match = new Regex("Environment='[A-Za-z]*'");
            Match environmentName = match.Match(theResultNode.InnerText);
            if (environmentName != Match.Empty)
            {
                string[] splitString = environmentName.ToString().Split('=');
                if (splitString.Length == 2)
                {
                    testResult.ExecutionEnvironment = splitString[1].Replace("'", "");
                }
            }
            testResult.TestName = theResultNode.Attributes["testName"].Value;
            testResult.setOutcome(theResultNode.Attributes["outcome"].Value);

            //Capture the end time and duration
            testResult.ExecutionCompletionDateTime = Convert.ToDateTime(theResultNode.Attributes["endTime"].Value);
            testResult.ExecutionDuration = TimeSpan.Parse(theResultNode.Attributes["duration"].Value);

            //Build the first part of the comment
            StringBuilder comment = new StringBuilder();
            comment.Append("\r\n");
            comment.Append("Test " + theResultNode.Attributes["outcome"].Value.ToUpper());
            comment.Append(" on " + theResultNode.Attributes["computerName"].Value);
            comment.Append(" at " + testResult.ExecutionCompletionDateTime.ToShortDateString() + " " + testResult.ExecutionCompletionDateTime.ToShortTimeString());
            comment.Append("\r\n");
            comment.Append("Duration: " + testResult.ExecutionDuration.Minutes + " min " + testResult.ExecutionDuration.Seconds + " sec");
            testResult.ExecutionComments = comment.ToString();
            testResult.ComputerName = theResultNode.Attributes["computerName"].Value;

            return testResult;
        }

        private string GetText(XmlNode context, String xPath)
        {
            String value = String.Empty;

            XmlNode node = context.SelectSingleNode(xPath);
            if (node != null)
            {
                value = node.InnerText;
            }

            return value;
        }

    }
}
