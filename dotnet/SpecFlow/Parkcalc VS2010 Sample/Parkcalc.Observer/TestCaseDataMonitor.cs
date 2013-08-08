using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.Text;
using Parkcalc.Observer.Enums;

namespace Parkcalc.Observer
{
    public static class TestCaseDataMonitor
    {
        private static string testCaseDescription = String.Empty;
        private static Dictionary<TestCaseData, object> testCaseData = new Dictionary<TestCaseData, object>();

        public static string TestCaseName
        {
            get
            {
                return testCaseDescription;
            }
            set
            {
                testCaseDescription = value;
            }
        }

        public static bool ContainsKey(TestCaseData testDataKey)
        {
            return testCaseData.ContainsKey(testDataKey);
        }

        public static void StoreTestData(TestCaseData testDataKey, object data)
        {
            testCaseData[testDataKey] = data;
        }

        public static T GetData<T>(TestCaseData testDataKey)
        {
            return (T)testCaseData[testDataKey];
        }

        //internal static void SetTestContext(TestContext testAttributes)
        //{
        //    TestCaseName = testAttributes.TestName;
        //    testCaseData.Clear();
        //}
    }

}
