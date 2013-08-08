using System;

namespace TestAutomationProject1.Observer
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ExecutionVersion : Attribute
    {
        // Was changed from public readonly ApplicationVersion VersionNumber;
        private readonly ApplicationVersion VersionNumber;

        public ExecutionVersion(ApplicationVersion numberVersion)
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
