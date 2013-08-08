using Stax.TFS2010;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Client;

namespace Stax.TFS2010.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for TFSManagerTest and is intended
    ///to contain all TFSManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TFSManagerTest
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Projects
        ///</summary>
        [TestMethod()]
        public void ProjectsTest()
        {
            ProjectCollection  actual;
            actual = TFSManager.Projects;
       
            Assert.IsTrue(actual.Count > 0,"Greater than 0 projects were found.");
        }

        /// <summary>
        ///A test for GetStoredQueries
        ///</summary>
        [TestMethod()]
        public void GetStoredQueriesTest()
        {
            string projectName = "MSF Agile Test Project"; // TODO: Initialize to an appropriate value
            int actual;
            actual = TFSManager.GetStoredQueries(projectName).Count;
            Assert.IsTrue(actual > 0, "Greater than 0 Stored Queries was found.");
        }
    }
}
