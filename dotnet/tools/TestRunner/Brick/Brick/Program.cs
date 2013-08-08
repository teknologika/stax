using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brick
{
    class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            if (!facade.ValidateArgs(args))
            {
                //facade.WriteTrxFileAsHTML(@"c:\test.trx");
                facade.RunTests(System.IO.Directory.GetCurrentDirectory() + @"\Brick.DemoTest.UnitTest.dll");
            }
            else
            {
                if (args[0].EndsWith(".trx"))
                {
                    facade.WriteTrxFileAsHTML(args[0]);
                }
                else
                {
                    facade.RunTests(args[0]);
                }
            }

        }
    }
}
