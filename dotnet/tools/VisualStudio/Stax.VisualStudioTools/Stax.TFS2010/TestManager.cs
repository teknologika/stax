using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Instrumentation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.TestManagement.Common;
using Microsoft.TeamFoundation.TestManagement.Client;


namespace Stax.TFS2010
{
    public sealed class TestManager
    {
        
        
        /// <summary>
        /// A private constructor to allow the class to be static.
        /// </summary>
        /// 
        private TestManager()
        {
        }

        public static ITestManagementTeamProject GetTestProject(string projectName)
        {
            ITestManagementService testService = (ITestManagementService)TFSManager.TFSStore.TeamProjectCollection.GetService(typeof(ITestManagementService));
            return testService.GetTeamProject(projectName);
        }

        public static ITestManagementTeamProject GetTestProject(Project project)
        {
            ITestManagementService test_service = (ITestManagementService)TFSManager.TFSStore.TeamProjectCollection.GetService(typeof(ITestManagementService));
            return test_service.GetTeamProject(project);
        }


        public static ITestPlanCollection GetTestPlans(Project project)
        {
            return GetTestProject(project).TestPlans.Query("Select * From TestPlan");
        }

        public static ITestPlanCollection GetTestPlans(ITestManagementTeamProject testProject)
        {
            return  testProject.TestPlans.Query("Select * From TestPlan");
        }

        public static ITestPlan GetTestPlan(ITestManagementTeamProject testProject, string testPlan)
        {
            ITestPlanCollection mTestPlanCollection = null;


            if (string.IsNullOrEmpty(testPlan))
            {
                mTestPlanCollection = GetTestPlans(testProject);
            }
            else
            {
                mTestPlanCollection = testProject.TestPlans.Query(string.Format("Select * From TestPlan where PlanName = '{0}'", testPlan));
            }
            if (mTestPlanCollection.Count > 0)
            {
                return mTestPlanCollection[0];
            }
            else
            {
                return null;
            }
        }


        public static ITestPlan GetTestPlan(ITestManagementTeamProject testProject, int testPlanId)
         {
            ITestPlanCollection mTestPlanCollection = null;
            mTestPlanCollection = testProject.TestPlans.Query(string.Format("Select * From TestPlan where Id = '{0}'", testPlanId));
            if (mTestPlanCollection.Count > 0)
            {
                return mTestPlanCollection[0];
            }
            else
            {
                return null;
            }
        }

        public static int CreateNewTestPlan(ITestManagementTeamProject teamProject, string testPlanName)
        {
            ITestPlan plan = teamProject.TestPlans.Create();
            plan.Name = testPlanName;
            plan.StartDate = DateTime.Now;
            plan.EndDate = DateTime.Now.AddMonths(2);
            plan.Save();
            return plan.Id;
        }

        public static ITestCaseCollection GetTestCases(ITestPlanCollection testPlans)
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            return null;
        }

        public static ITestCaseCollection GetTestCases(IStaticTestSuite suite)
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
           return suite.AllTestCases;
        }

        public static List<ITestCaseResult> GetTestResults(ITestPlanCollection testPlans)
        {
            List<ITestCaseResult> testResults = new List<ITestCaseResult>();
            // Loop through the test plan collection to read the associated test suite.
            foreach (ITestPlan testPlan in testPlans)
            {
                // Loop through the test suite to read the associated test case.
                foreach (ITestSuiteBase testSuite in testPlan.RootSuite.SubSuites)
                {
                    // Query Test points that holds the Test case and test result information
                    foreach (ITestPoint point in testPlan.QueryTestPoints(string.Format("SELECT * FROM TestPoint WHERE SuiteId = {0}", testSuite.Id)))
                    {
                        ITestCaseResult testResult = point.MostRecentResult;

                        if (point.MostRecentResult == null)
                        {
                            // test case is not executed at least once.
                        }
                        else
                        {
                            testResults.Add(testResult);
                        }
                    }
                }
            }
            return testResults;
        }

        public static int CreateNewStaticTestSuite(ITestManagementTeamProject teamProject, string testPlanName, string testSuiteName)
        {
            ITestPlan plan = GetTestPlan(teamProject, testPlanName);
            if (plan == null )
            {
                CreateNewTestPlan(teamProject, testPlanName);
            }
            Console.WriteLine("Got Plan {0} with Id {1}", plan.Name, plan.Id);


            
            IStaticTestSuite newSuite = teamProject.TestSuites.CreateStatic();
            newSuite.Title = testSuiteName;
            
            plan.RootSuite.Entries.Add(newSuite);
            plan.Save();
            return newSuite.Id;
        }

        public static int CreateNewDynamicTestSuite(ITestManagementTeamProject teamProject, string testPlanName, string testSuiteName)
        {
            ITestPlan plan = GetTestPlan(teamProject, testPlanName);
            if (plan == null)
            {
                CreateNewTestPlan(teamProject, testPlanName);
            }
            Console.WriteLine("Got Plan {0} with Id {1}", plan.Name, plan.Id);

            IDynamicTestSuite newSuite = teamProject.TestSuites.CreateDynamic();
            newSuite.Title = testSuiteName;

            plan.RootSuite.Entries.Add(newSuite);
            plan.Save();
            return newSuite.Id;
        }

        public static int CreateTestConfiguration (ITestManagementTeamProject teamProject, string name, string description, bool isDefault, IDictionary<string, string> values)
        {
            ITestConfiguration config = GetTestConfiguration(teamProject, name);
            if (config != null)
            {
                config = teamProject.TestConfigurations.Create();
                config.Name = name;
                config.Description = description;
                config.IsDefault = isDefault;
                foreach (var item in values)
                {
                    config.Values.Add(item.Key, item.Value);
                }
                config.Save();
            }
            return config.Id;
        }

        public static int CreateCurrentTestConfiguration(ITestManagementTeamProject teamProject)
        {
            ITestConfiguration config = GetTestConfiguration(teamProject, OSInfo.ShortNameWithIE);
            if (config == null)
            {
                config = teamProject.TestConfigurations.Create();
                config.Name = OSInfo.ShortNameWithIE;
                config.Description = OSInfo.FriendlyName + " with " + OSInfo.GetFriendyIEVersionName;
                config.Values.Add("Operating System", OSInfo.FriendlyName);
                config.Values.Add("Browser", OSInfo.GetFriendyIEVersionName);
                config.Save();
            }
            return config.Id;
        }

        public static ITestConfiguration GetTestConfiguration(ITestManagementTeamProject teamProject, string configurationName)
        {
            ITestConfiguration config = null;
            ITestConfigurationCollection configCollection = teamProject.TestConfigurations.Query(string.Format("Select * From TestConfiguration where name = '{0}'", configurationName));
            if (configCollection.Count > 0)
            {
                config = configCollection[0];
            }
            return config;
        }

        public static ITestConfigurationCollection GetTestConfigurations(ITestManagementTeamProject teamProject)
        {
            ITestConfigurationCollection configCollection = teamProject.TestConfigurations.Query(string.Format("Select * From TestConfiguration"));    
            return configCollection;
        }

        public static int CreateTestCase(ITestManagementTeamProject teamProject, string title, string description)
        {

            ITestCase tc = teamProject.TestCases.Create();
            tc.Title = title;
            tc.Description = description;
            tc.Save();
            return tc.Id;
        }

    }
}
