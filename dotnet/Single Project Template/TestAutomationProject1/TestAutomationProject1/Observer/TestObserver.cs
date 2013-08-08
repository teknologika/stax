using System;
using System.Collections.Generic;
using System.Text;


namespace TestAutomationProject1.Observer
{
    public static class TestObserver
    {
        public static void StartTestObserver()
        {
            EnvironmentMonitor.CheckSetEnvironment();
            VersionMonitor.CheckSetVersion();
            //TestCaseDataMonitor.SetTestContext(testContext);
            Console.WriteLine("Environment='" + EnvironmentMonitor.TestEnvironment + "'");
        }
    }
}
