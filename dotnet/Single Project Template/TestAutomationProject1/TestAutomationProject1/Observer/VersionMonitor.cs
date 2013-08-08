using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Reflection;
using System.Configuration;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using TestAutomationProject1.Observer;

namespace TestAutomationProject1.Observer
{
    public static class VersionMonitor
    {
        private static ApplicationVersion _version = ApplicationVersion.V1;

        public static ApplicationVersion TestVersion
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        internal static void CheckSetVersion()
        {
            Object[] attributes = Utility.GetCallerAttributes(typeof(ExecutionVersion), 3);

            CheckVersion(attributes);

        }

        private static void CheckVersion(Object[] attributes)
        {
            ApplicationVersion currentVersion = GetCurrentVersion();

            if (attributes.Length <= 0 || attributes.Contains(new ExecutionVersion(currentVersion)))
            {
                TestVersion = currentVersion;
            }
            else
            {
                Assert.Inconclusive("This test is not designed to be executed in the application version '" + currentVersion.ToString());   
            }
        }

        private static ApplicationVersion GetCurrentVersion()
        {
            string currentVersion = ConfigurationManager.AppSettings["Version"].ToLower(CultureInfo.CurrentCulture);
            ApplicationVersion MISVersion = new ApplicationVersion();

            try
            {
                MISVersion = (ApplicationVersion) Enum.Parse(typeof (ApplicationVersion), currentVersion, true);
            }
            catch (System.ArgumentException)
            {
                Assert.Fail(" The current version setting in 'Version' in the app.config is invalid.");
            }

            return MISVersion;
        }
    }
}
