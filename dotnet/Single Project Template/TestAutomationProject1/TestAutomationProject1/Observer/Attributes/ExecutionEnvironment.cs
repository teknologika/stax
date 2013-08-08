using System;
using TestAutomationProject1.Observer;

namespace TestAutomationProject1.Observer
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ExecutionEnvironment : Attribute
    {
        //Was changed from public readonly EnvironmentType EnvironmentType;
        private readonly EnvironmentType EnvironmentType;

        public ExecutionEnvironment(EnvironmentType environmentTypes) 
        {
            EnvironmentType = environmentTypes;
        }

        public EnvironmentType EnvironmentTypes
        {
            get
            {
                return EnvironmentType;
            }
        }
    }
}

