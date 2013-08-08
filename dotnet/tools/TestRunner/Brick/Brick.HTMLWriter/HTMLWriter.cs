using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;




namespace Brick
{
    public class HTMLWriter : IResultWriter
    {
        

        public void WriteResult(string AssemblyName, List<TestResult> TestResults)
        {
            WriteHTMLResult(AssemblyName, (List<TestResult>)TestResults);
        }

        private void WriteHTMLResult(string AssemblyName, List<TestResult> testResults)
        {
            StringBuilder resultsFile = new StringBuilder();
            resultsFile.Append(GetResourceContent("HTMLHeader.txt"));
            resultsFile.Append(WriteSummaryTables(testResults));
            resultsFile.Append(WriteDetailsTable(testResults));
            resultsFile.Append(GetResourceContent("HTMLFooter.txt"));

            // Write the string to a file.

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\TestResults\");
            string fileName = Directory.GetCurrentDirectory() + @"\TestResults\" + Environment.UserName.ToString() + "_" + Environment.MachineName + "" + DateTime.Now.ToString("yyyy-mm-dd hh_mm_ss") + ".html";

            StreamWriter file = new System.IO.StreamWriter(fileName);
            file.WriteLine(resultsFile);
            file.Close();

        }

        private string WriteSummaryTables(List<TestResult> testResults)
        {
            testResults.Sort();
            
            TestStats GlobalStats = new TestStats();
            TestStats tmpStats;
            List<TestStats> AssemblyStats = new List<TestStats>();

            // Calculate Statistics
            testResults.Sort();
            var testgroups =
                from test in testResults
                group test by test.ClassName into groups
                select new { ClassName = groups.Key, tests = groups };

            foreach (var groups in testgroups)
            {
                tmpStats = new TestStats();
                tmpStats.Name = groups.ClassName;
                foreach (var n in groups.tests)
                {
                    tmpStats.TotalTime = tmpStats.TotalTime.Add(n.Duration);
                    GlobalStats.TotalTime = GlobalStats.TotalTime.Add(n.Duration);
                    switch (n.TestOutcome.ToLower())
                    {
                        case "passed":
                        case "pass":
                            GlobalStats.TotalPassed++;
                            tmpStats.TotalPassed++;
                            
                            break;

                        case "failed":
                        case "fail":
                            GlobalStats.TotalFailed++;
                            tmpStats.TotalFailed++;
                            break;

                        case "inconclusive":
                        case "ingnored":
                        case "aborted":

                            GlobalStats.TotalInconclusive++;
                            tmpStats.TotalInconclusive++;
                            break;
                    }
                }
                tmpStats.TotalTests = tmpStats.TotalFailed + tmpStats.TotalPassed + tmpStats.TotalInconclusive;
                AssemblyStats.Add(tmpStats);
            }

            GlobalStats.TotalTests = GlobalStats.TotalPassed + GlobalStats.TotalInconclusive + GlobalStats.TotalFailed;

            // Write out global Statistics
            StringBuilder bob = new StringBuilder();

            bob.AppendLine(string.Format("    <h3>Summary</h3>"));

            bob.AppendLine("  <table class=details cellSpacing=2 cellPadding=5 width='95%' border=0>");
            bob.AppendLine("    <tbody>");
            bob.AppendLine("      <tr vAlign=top>");
            bob.AppendLine("        <th>Tests</th>");
            bob.AppendLine("        <th>Passed</th>");
            bob.AppendLine("        <th>Inconclusive or Ingored</th>");
            bob.AppendLine("        <th>Failed</th>");
            bob.AppendLine("        <th>Success Rate</th>");
            bob.AppendLine("        <th>Time</th>");
            bob.AppendLine("      </tr>");

            bob.AppendLine("  <tr vAlign=top>");
            bob.AppendLine(string.Format("        <td >{0}</td>", GlobalStats.TotalTests));
            bob.AppendLine(string.Format("        <td >{0}</td>", GlobalStats.TotalPassed));
            bob.AppendLine(string.Format("        <td >{0}</td>", GlobalStats.TotalInconclusive));
            bob.AppendLine(string.Format("        <td >{0}</td>", GlobalStats.TotalFailed));

            int SuccessfulGlobalTests = GlobalStats.TotalTests - (GlobalStats.TotalInconclusive + GlobalStats.TotalFailed);
            bob.AppendLine(string.Format("        <td >{0}&nbsp;({1}%)</td>", SuccessfulGlobalTests, GetPercentage(SuccessfulGlobalTests, GlobalStats.TotalTests, 1)));
            bob.AppendLine(string.Format("        <td >{0}</td>", GlobalStats.TotalTime));
            bob.AppendLine("      </tr>");
            bob.AppendLine("    </tbody>");
            bob.AppendLine("  </table>");
            bob.AppendLine("  &nbsp;<a href='#top'>Back to top</a>");
            bob.AppendLine("  <br/><br/>");

            bob.AppendLine(string.Format("    <h3>Summary</h3>"));

            bob.AppendLine("  <table class=details cellSpacing=2 cellPadding=5 width='95%' border=0>");
            bob.AppendLine("    <tbody>");
            bob.AppendLine("      <tr vAlign=top>");
            bob.AppendLine("        <th width='80%'>Name</th>");
            bob.AppendLine("        <th>Tests</th>");
            bob.AppendLine("        <th>Passed</th>");
            bob.AppendLine("        <th>Inconclusive</th>");
            bob.AppendLine("        <th>Failed</th>");
            bob.AppendLine("        <th>Success Rate</th>");
            bob.AppendLine("        <th>Time</th>");
            bob.AppendLine("      </tr>");

            foreach (var item in AssemblyStats)
            {
                    bob.AppendLine("  <tr vAlign=top>");
                    bob.AppendLine(string.Format("        <td ><a href='#{0}' >{0}</a></td>", item.Name));
                    bob.AppendLine(string.Format("        <td >{0}</td>", item.TotalTests));
                    bob.AppendLine(string.Format("        <td >{0}</td>", item.TotalPassed));
                    bob.AppendLine(string.Format("        <td >{0}</td>", item.TotalInconclusive));
                    bob.AppendLine(string.Format("        <td >{0}</td>", item.TotalFailed));
                    int SuccessfulTests = item.TotalTests - (item.TotalInconclusive + item.TotalFailed);
                    bob.AppendLine(string.Format("        <td >{0}&nbsp;({1}%)</td>", SuccessfulTests, GetPercentage(SuccessfulTests, item.TotalTests,1)));
                    bob.AppendLine(string.Format("        <td >{0}</td>", item.TotalTime));
                    bob.AppendLine("      </tr>");
            }
                bob.AppendLine("    </tbody>");
                bob.AppendLine("  </table>");
                bob.AppendLine("  &nbsp;<a href='#top'>Back to top</a>");
                bob.AppendLine("  <br/><br/>");
            return bob.ToString();
        }



        private string WriteDetailsTable(List<TestResult> testResults)
        {
            testResults.Sort();
            
            StringBuilder bob = new StringBuilder();

            var testgroups =
                from test in testResults
                group test by test.ClassName into groups
                select new { ClassName = groups.Key, tests = groups };

           foreach ( var groups in testgroups )
           {
                bob.AppendLine(string.Format("    <a name={0}></a>", groups.ClassName));
                bob.AppendLine(string.Format("    <h3>TestCases for {0}</h3>", groups.ClassName));

                bob.AppendLine("  <table class=details cellSpacing=2 cellPadding=5 width='95%' border=0>");
                bob.AppendLine("    <tbody>");
                bob.AppendLine("      <tr vAlign=top>");
                bob.AppendLine("        <th>Name</th>");
                bob.AppendLine("        <th>Status</th>");
                bob.AppendLine("        <th width='80%'>Message</th>");
                bob.AppendLine("        <th >Time</th>");
                bob.AppendLine("      </tr>");

                foreach (var test in groups.tests)
                {
                    //Console.WriteLine("{0} {1}", test.TestName, test.TestOutcome);
                    bob.AppendLine("  <tr vAlign=top>");
                    bob.AppendLine(string.Format("        <td>{0}</td>", test.TestName));
                    bob.AppendLine(string.Format("        <td class='{0}'> {0}</td>", test.TestOutcome));
                    if (!string.IsNullOrEmpty(test.Messages))
                    {
                        test.Messages = test.Messages.Replace("\r\n", "<br/>");
                    }
                    bob.AppendLine(string.Format("        <td width='80%'>{0}</td>", test.Messages));
                    bob.AppendLine(string.Format("        <td >{0}</td>", test.Duration.ToString()));
                    bob.AppendLine("      </tr>");
                }
                bob.AppendLine("    </tbody>");
                bob.AppendLine("  </table>");
                bob.AppendLine("  &nbsp;<a href='#top'>Back to top</a>");
                bob.AppendLine("  <br/><br/>");
           }
            return bob.ToString();
        }


        public string GetResourceContent(string filename)
        {
            string functionReturnValue = null;
            // get the current assembly
            Assembly asm = Assembly.GetExecutingAssembly();
            // resources are named using a fully qualified name
            Stream strm = asm.GetManifestResourceStream(asm.GetName().Name + "." + filename);
            // read the contents of the embedded file
            StreamReader reader = new StreamReader(strm);
            functionReturnValue = reader.ReadToEnd();
            reader.Close();
            return functionReturnValue;
        }


        private class TestStats
        {
            public string Name;
            public TimeSpan TotalTime = new TimeSpan();
            public int TotalTests = 0;
            public int TotalPassed = 0;
            public int TotalInconclusive = 0;
            public int TotalFailed = 0;
        }

        /// <summary>
        /// Generates a percentage, formatted with "places" decimal places.
        /// </summary>
        /// <param name="value">Value for which a percentage is needed</param>
        /// <param name="total">Total of all values from which to generate a percentage</param>
        /// <param name="places">How many decimal places to return in the percentage string</param>
        /// <returns>string with the percentage value</returns>
        private static String GetPercentage(Int32 value, Int32 total, Int32 places)
        {
            Decimal percent = 0;
            String retval = string.Empty;
            String strplaces = new String('0', places);

            if (value == 0 || total == 0)
            {
                percent = 0;
            }

            else
            {
                percent = Decimal.Divide(value, total) * 100;

                if (places > 0)
                {
                    strplaces = "." + strplaces;
                }
            }

            retval = percent.ToString("#" + strplaces);

            return retval;
        }


    }

  

   
    

}
