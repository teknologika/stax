using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010TestResultPublisher
{
    class HPQualityCentreResultWriter :IResultsWriter
    {
        internal Settings _settings;
        private static HPQualityCentreResultWriter _instance = null;
        static readonly object threadSafeLock = new object();
        
        public string _testSet = String.Empty;
        public int _folderNodeId = 0;

        #if HPQC
        private TDAPIOLELib.TDConnection connection = null;
        #endif

        private HPQualityCentreResultWriter()
        {
            _settings = new Settings();

        }

        /// <summary>
        /// Public method that will return the class -> singleton
        /// </summary>
        /// <returns>ControlHandler</returns>
        public static HPQualityCentreResultWriter Instance()
        {
            // thread safe singleton code
            lock (threadSafeLock)
            {
                if (_instance == null)
                {
                    _instance = new HPQualityCentreResultWriter();
                    
                }
                MercuryDialog dialog = new MercuryDialog();
                dialog.ShowDialog();
                if (dialog.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    _instance.Cancelled = true;
                }
                else
                {
                    _instance.Cancelled = false;
                }
                if (!String.IsNullOrEmpty(dialog.ServerUrl))
                {
                    _instance.CurrentProject = new ProjectSettings(dialog.ServerUrl, dialog.DomainName, dialog.ProjectName, dialog.UserName, dialog.Password);
                    _instance._folderNodeId = dialog.FolderNodeId;
                }
                else
                {
                    throw new Exception("Not enough information has been given to log into Mercury!");
                }
                return _instance;
            }
        }
       
        public override string UpdateTestResult(TestResult result, bool publishFailures, bool publishInconclusive, bool publishErrorInformation)
        {
            string resultString = "You should never see this.";
           
            if (result == null)
            {
                return "No test result was passed to publish.";
            }

            if ( result.Description.ToString() ==  null)
            {
                return "The test " + result.Description + " does not have a description defined in code.";
            }

            bool publishResult = false;
            switch (result.Outcome)
	        {
		        case TestResult.TestResultType.Aborted:
                    resultString = "The test " + result.Description + " has aborted will not be published.";
                    publishResult = false;
                    break;

                case TestResult.TestResultType.Passed:
                    publishResult = true;
                    break;
                case TestResult.TestResultType.Failed:
                    if (publishFailures)
                    {
                        publishResult = true;
                    }
                    else
                    {
                        resultString = "The test " + result.Description + " has failed will not be published.";
                        publishResult = false;
                    }
                    break;
                case TestResult.TestResultType.Inconclusive:
                    if (publishInconclusive)
                    {
                        publishResult = true;
                    }
                    else
                    {
                       resultString = "The test " + result.Description + " was inconclusive will not be published.";
                        publishResult = false;
                    }
                    break;
                case TestResult.TestResultType.NotExecuted:
                    publishResult = false;
                    break;
	        }
            bool publishedSuccessfully = false;
            if (publishResult)
            {
                
                try
                {
                    #if HPQC 
                    connection = new TDAPIOLELib.TDConnection();
                    connection.InitConnectionEx(CurrentProject.ServerURL);
                    connection.ConnectProjectEx(CurrentProject.DomainName, CurrentProject.ProjectName, CurrentProject.Username, CurrentProject.Password);
                    #endif 
                }
                catch (Exception e)
                {
                    return "Unable to connect to the Mercury server: " + CurrentProject.DomainName + " on project "  + CurrentProject.ProjectName + ". The error was: " + e.Message;
                }

                publishedSuccessfully = UpdateTestExecution(result);
            }
            else
            {
                return resultString;
            }
            if (publishedSuccessfully)
            {
                return "'" + result.Description + "' was published successfully.";
            }
            else
            {
                return "'" + result.Description + "' did not publish because it was not found.";
            }
        }

        
        private bool UpdateTestExecution(TestResult result)
        {
            bool found = false;
            #if HPQC
            TDAPIOLELib.TestSetTreeManager testFolders = (TDAPIOLELib.TestSetTreeManager)connection.TestSetTreeManager;
            TDAPIOLELib.TestSetFolder testFolder = (TDAPIOLELib.TestSetFolder)testFolders.get_NodeById(_instance._folderNodeId);

            foreach (TDAPIOLELib.TestSet set in testFolder.FindTestSets("", false, ""))
            {
                 TDAPIOLELib.TSTestFactory fac = (TDAPIOLELib.TSTestFactory)set.TSTestFactory;
                 TDAPIOLELib.TDFilter testFilter = (TDAPIOLELib.TDFilter)fac.Filter;
                 testFilter["TS_NAME"] = result.Description.Replace(" ", "*").Replace("(", "*").Replace(")", "*");

                 foreach (TDAPIOLELib.TSTest tsTest in fac.NewList(testFilter.Text))
                 {
                    if (tsTest.TestName == result.Description)
                    {
                        found = true;
                        TDAPIOLELib.RunFactory testRun = (TDAPIOLELib.RunFactory)tsTest.RunFactory;
                        TDAPIOLELib.Run runner = (TDAPIOLELib.Run)testRun.AddItem("Run_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm"));
                        runner.CopyDesignSteps();
                        runner.Name = "Run_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
                        runner["RN_HOST"] = result.ComputerName;
                        runner["RN_DURATION"] = Convert.ToInt32(result.ExecutionDuration.TotalSeconds);
                        runner["RN_TESTER_NAME"] = "automation";
                        TDAPIOLELib.StepFactory allSteps = (TDAPIOLELib.StepFactory)runner.StepFactory;
                            foreach (TDAPIOLELib.Step stepper in allSteps.NewList(""))
                            {
                                stepper.Status = result.OutcomeAsString;
                                stepper["ST_ACTUAL"] = result.ExecutionComments;
                                stepper.Post();
                            }
                        runner.Status = result.OutcomeAsString;
                        runner.Post();
                    }
                 }
            }
            #endif
            return found;
        }

        public override void Disconnect()
        {
            #if HPQC 
            if (_instance.connection.ProjectConnected)
            {
                _instance.connection.DisconnectProject(); 
            }
            #endif
        }

    }
}

