using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Reflection;
using System.Configuration;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace TestAutomationProject1.Observer
{
    public static class ProjectMonitor
    {
        public static string ProjectNumber { get; set; }

        public static void GenerateProjectNumber()
        {
            int projectNumber = Utility.GenerateRandomNumber(10000000, 99999999);

            ProjectNumber = projectNumber.ToString(CultureInfo.CurrentCulture);
        }

    }
}
