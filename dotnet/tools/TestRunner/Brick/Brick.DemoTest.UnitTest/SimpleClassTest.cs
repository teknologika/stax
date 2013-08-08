using Brick.DemoTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Brick.DemoTest.UnitTest
{
    /// <summary>
    ///This is a test class for SimpleClassTest and is intended
    ///to contain all SimpleClassTest Unit Tests
    ///</summary>
    [TestClass]
    public class zzzzSimpleClassTest
    {

        [TestInitialize]
        public void vsInit()
        {
            System.Console.WriteLine("TestInitialize");
        }

        [TestCleanup]
        public void vsClean()
        {

            System.Console.WriteLine("TestCleanup");
        }


        [TestMethod]
        public void GetText_NoInput_ReturnsStaticText()
        {
            SimpleClass target = new SimpleClass();
            Assert.AreEqual("MSTestRunner", target.GetText());
        }


        /// <summary>
        ///A test for GetTextFromAppConfig
        ///</summary>
        [TestMethod]
        public void GetTextFromAppConfig_NoInput_ReturnsStaticTextFromAppConfig()
        {
            SimpleClass target = new SimpleClass();
            Assert.AreEqual("MSTestRunner from app.configgg", target.GetTextFromAppConfig());
        }
    }


    [NUnit.Framework.TestFixture]
    public class zzNunitTest
    {
        [NUnit.Framework.TestFixtureSetUp]
        public void tfSetup()
        {
            System.Console.WriteLine("TestFixtureSetup");
        }

        [NUnit.Framework.TestFixtureTearDown]
        public void tfTear()
        {
            System.Console.WriteLine("TestFixtureTearDown");
        }
        
        
        [NUnit.Framework.SetUp]
        public void Setup()
        {
            System.Console.WriteLine("TestSetup");
        }

        [NUnit.Framework.Test]
        public void CC()
        {
             NUnit.Framework.Assert.AreEqual("aa","aa");
        }

        [NUnit.Framework.Test]
        public void AA()
        {
            NUnit.Framework.Assert.AreEqual("bbbb", "bb");
        }


        [NUnit.Framework.TearDown]
        public void tear()
        {
            System.Console.WriteLine("TestTeardown");
        }
    }



}
