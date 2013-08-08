using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Brick
{
  
    public interface IResultWriter
    {

        void WriteResult(string AssemblyName, List<TestResult> TestResults);
    }

 
}
