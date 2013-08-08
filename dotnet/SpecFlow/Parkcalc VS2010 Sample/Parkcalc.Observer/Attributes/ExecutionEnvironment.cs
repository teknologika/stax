using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Observer.Enums;

namespace Parkcalc.Observer
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
