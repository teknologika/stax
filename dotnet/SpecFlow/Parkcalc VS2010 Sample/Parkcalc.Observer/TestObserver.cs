using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Parkcalc.Observer
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
