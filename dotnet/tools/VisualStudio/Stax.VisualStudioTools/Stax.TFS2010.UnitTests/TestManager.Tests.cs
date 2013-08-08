using Stax.TFS2010;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections.Generic;

namespace Stax.TFS2010.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for TFSManagerTest and is intended
    ///to contain all TFSManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TestManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        /// <summary>
        ///A test for GetTestProject
        ///</summary>
        [TestMethod()]
        public void GetTestProjectTest()
        {

            string projectName = "MSF Agile Test Project"; // TODO: Initialize to an appropriate value
            ITestManagementTeamProject expected = null; // TODO: Initialize to an appropriate value
            ITestManagementTeamProject actual;
            actual = TestManager.GetTestProject(projectName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateNewTestPlan
        ///</summary>
        [TestMethod()]
        public void CreateNewTestPlanTest()
        {
            string projectName = "MSF Agile Test Project";
            ITestManagementTeamProject teamProject = TestManager.GetTestProject(projectName);
            //ITestManagementTeamProject teamProject = null; // TODO: Initialize to an appropriate value
            string testPlanName = "First Test Plan"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = TestManager.CreateNewTestPlan(teamProject, testPlanName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for CreateNewTestPlan
        ///</summary>
        [TestMethod()]
        public void CreateNewTestSuiteTest()
        {
            string projectName = "MSF Agile Test Project";
            ITestManagementTeamProject teamProject = TestManager.GetTestProject(projectName);
            //ITestManagementTeamProject teamProject = null; // TODO: Initialize to an appropriate value
            string testPlanName = "First Test Plan"; // TODO: Initialize to an appropriate value
            string testSuiteName = "First Test Suite";
            //int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = TestManager.CreateNewStaticTestSuite(teamProject, testPlanName, testSuiteName);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for CreateTestConfiguration
        ///</summary>
        [TestMethod()]
        public void CreateTestConfigurationTest()
        {
            string projectName = "MSF Agile Test Project";
            ITestManagementTeamProject teamProject = TestManager.GetTestProject(projectName);
            int actual = TestManager.CreateCurrentTestConfiguration(teamProject);
        }

        /// <summary>
        ///A test for CreateTestCase
        ///</summary>
        [TestMethod()]
        public void CreateTestCaseTest()
        {
            string projectName = "MSF Agile Test Project";
            ITestManagementTeamProject teamProject = TestManager.GetTestProject(projectName);
            string name = "aaa"; // TODO: Initialize to an appropriate value
            string description = "The quick brown fox"; // TODO: Initialize to an appropriate value
            int actual = TestManager.CreateTestCase(teamProject, name, description);
        }

    }
}
