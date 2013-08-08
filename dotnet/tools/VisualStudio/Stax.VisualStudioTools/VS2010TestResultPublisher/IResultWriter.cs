using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010TestResultPublisher
{
    public class IResultsWriter
    {

        protected ProjectSettings _currentProject;
        protected bool _cancelled = false;

        public bool Cancelled
        {
            get
            {
                return _cancelled;
            }
            set
            {
                _cancelled = value;
            }
        }

        public ProjectSettings CurrentProject
        {
            get
            {
                return _currentProject;
            }
            set
            {
                _currentProject = value;

            }
        }

        public virtual string UpdateTestResult(TestResult result, bool publishFailures, bool publishInconclusive, bool publishErrorInformation)
        {
            return String.Empty;
        }

        public virtual void Disconnect() { }
    }
}
