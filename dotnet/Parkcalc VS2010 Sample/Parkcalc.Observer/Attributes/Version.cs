using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Observer.Enums;

namespace Parkcalc.Observer
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Version : Attribute
    {
        // Was changed from public readonly ApplicationVersion VersionNumber;
        private readonly ApplicationVersion VersionNumber;

        public Version(ApplicationVersion numberVersion) 
        {
            VersionNumber = numberVersion;
        }

        public ApplicationVersion NumberVersion
        {
            get
            {
                return VersionNumber;
            }
        }
    }
}
