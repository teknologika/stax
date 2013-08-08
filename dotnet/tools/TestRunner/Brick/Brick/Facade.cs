/* Copyright 2010 Bruce McLeod 
 * Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.

A "contribution" is the original software, or any additions or changes to the software.

A "contributor" is any person that distributes its contribution under this license.

"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights

(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations

(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement. 
*/
 
using System;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Configuration;



namespace Brick
{
    /// <summary>
    /// Facade for the test runner application.
    /// </summary>
    public class Facade
    {
    
        /// <summary>
        /// Validates the command-line args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public bool ValidateArgs(string[] args)
        {
            if (args.Count() != 1)
            {
                WriterHeader("Brick");
                Console.WriteLine("This tool executes unit tests created with NUnit or Visual Studio unit tests");
                Console.WriteLine("Usage: Brick.exe [AssemblyName(.dll)]");
                Console.WriteLine("       AssemblyName - name of the assembly containing the unit tests.");
                Console.WriteLine("                      The assembly must be in the same directory.");
                Console.WriteLine();
                Console.WriteLine("Example:");
                Console.WriteLine("UnitTest.dll or UnitTest");
                return false;
            }

            if (!args[0].ToString().ToLower().EndsWith(".trx"))
            {
                string assemblyPath = GetFullAssemblyPath(args[0]);
                if (!File.Exists(assemblyPath))
                {
                    Console.WriteLine("The specified assembly could not be found at '{0}'.", assemblyPath);
                    return false;
                }

            }
            return true;
        }

        public void WriteTrxFileAsHTML(string fileName)
        {

            TrxFileParser parser = new TrxFileParser();
            List<MSTestResult> trxResults = parser.processTrxFile(fileName);

            if (trxResults != null)
            {
                List<TestResult> testResults = new List<TestResult>();

                foreach (var item in trxResults)
                {
                    TestResult tmp = new TestResult();
                    tmp.ClassName = item.ClassName;
                    tmp.ComputerName = item.ComputerName;
                    tmp.Duration = item.ExecutionDuration;
                    tmp.Messages = item.ExecutionComments;
                    tmp.TestName = item.TestName;
                    tmp.TestOutcome = item.ResultAsString;
                    testResults.Add(tmp);
                }

                HTMLWriter writer = new HTMLWriter();
                string[] split = fileName.Split('\\');


                writer.WriteResult(split[split.Length - 1], testResults);
            }
        }



        /// <summary>
        /// Runs the tests.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        public void RunTests(string assemblyName)
        {
            // Set up the global results containers
            List<TestResult> testResults = new List<TestResult>();
            Stats stats = new Stats();
            List<IResultWriter> plugins = LoadResultPlugIns();

            Console.WriteLine("Loading Assemblies ...");
            try
            {
                // 1. Load the assembly.
                Assembly assembly = GetAssembly(GetFullAssemblyPath(assemblyName));

                // 2. Get test classes.
                Type[] allTypes = assembly.GetTypes();
                List<Type> testClasses = new List<Type>();
                foreach (var item in allTypes)
                {
                    if (CheckClassIsATestClass(CustomAttributeData.GetCustomAttributes(item)))
                    {
                        testClasses.Add(item);
                    }
                }

                if (testClasses == null || testClasses.Count() == 0)
                    return;

                // 3. Get test methods for each class.

                foreach (var current in testClasses)
                {
                    List<MethodInfo> testMethods = new List<MethodInfo>();
                    List<MethodInfo> classSetupMethods = new List<MethodInfo>();
                    List<MethodInfo> classTeardownMethods = new List<MethodInfo>();
                    List<MethodInfo> setupMethods = new List<MethodInfo>();
                    List<MethodInfo> teardownMethods = new List<MethodInfo>();

                    MethodInfo[] allMethods = current.GetMethods();

                    foreach (var item in allMethods)
                    {
                        if (CheckMethodIsAClassSetupMethod(CustomAttributeData.GetCustomAttributes(item)))
                        {
                            classSetupMethods.Add(item);
                        }

                        if (CheckMethodIsATestSetupMethod(CustomAttributeData.GetCustomAttributes(item)))
                        {
                            setupMethods.Add(item);
                        }

                        if (CheckMethodIsATestMethod(CustomAttributeData.GetCustomAttributes(item)))
                        {
                            testMethods.Add(item);
                        }

                        if (CheckMethodIsATestTeardownMethod(CustomAttributeData.GetCustomAttributes(item)))
                        {
                            teardownMethods.Add(item);
                        }

                        if (CheckMethodIsAClassTeardownMethod(CustomAttributeData.GetCustomAttributes(item)))
                        {
                            classTeardownMethods.Add(item);
                        }
                    }


                    if (testMethods == null || testMethods.Count() == 0)
                        continue;



                    Console.WriteLine("Loading " + current.FullName + "...");
                    Console.WriteLine("Starting execution, {0} tests to run...", testMethods.Count());

                    object instance = assembly.CreateInstance(current.FullName);


                    // 4. Run test methods.
                    ExecuteMethods(classSetupMethods, instance);
                    try
                    {
                        ExecuteTestMethods(stats, testResults, setupMethods, testMethods, teardownMethods, instance);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        ExecuteMethods(classTeardownMethods, instance);
                    }

                    Console.WriteLine();
                    Console.WriteLine(stats.GetFinalResult());
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                // Unexpected error.
                Console.WriteLine("  An unexpected error occured: {0}", ex.Message);
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message == "Exception has been thrown by the target of an invocation.")
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            Console.WriteLine("  Reason: {0}", ex.InnerException.InnerException.Message);
                        }

                        else
                        {
                            Console.WriteLine("  Reason: {0}", ex.InnerException.Message);
                        }
                    }
                }
            }
            finally
            {
                foreach (IResultWriter item in plugins)
                {
                    item.WriteResult(assemblyName, testResults);
                }
            }
        }

        private List<IResultWriter> LoadResultPlugIns()
        {
            List<IResultWriter> plugins = new List<IResultWriter>();
            string exePathName = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName); 


            string[] files = Directory.GetFiles(exePathName, "*.plug");
            Console.WriteLine("Loading plugins from :" + exePathName); 
 
            foreach (string item in files)
            {
                Assembly a = Assembly.LoadFrom(item);
                System.Type[] types = a.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface("IResultWriter") != null)
                    {
                        plugins.Add((IResultWriter)Activator.CreateInstance(type));
                        Console.WriteLine("Loaded :" + item.ToString());
                    }
                }

            }

            return plugins;
        }

        private bool CheckMethodIsAClassSetupMethod(IList<CustomAttributeData> attributes)
        {
            bool isMatched = CheckForAttributes(false,attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.TestFixtureSetUpAttribute");
        }

        private bool CheckMethodIsAClassTeardownMethod(IList<CustomAttributeData> attributes)
        {
            bool isMatched = CheckForAttributes(false, attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.TestFixtureTearDownAttribute");
        }
       

        private bool CheckMethodIsATestSetupMethod(IList<CustomAttributeData> attributes)
        {

            bool isMatched = CheckForAttributes(false, attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.SetUpAttribute");
        }

        private bool CheckMethodIsATestTeardownMethod(IList<CustomAttributeData> attributes)
        {
            bool isMatched = CheckForAttributes(false, attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.TearDownAttribute");

        }

        private static void ExecuteMethods(List<MethodInfo> methods, object instance)
        {
            foreach (var method in methods)
            {
                method.Invoke(instance, null);
            }
        }

        private void ExecuteTestMethods(Stats stats, List<TestResult> testResults, List<MethodInfo> testSetupMethods, List<MethodInfo> testMethods, List<MethodInfo> testTeardownMethods, object instance)
        {
            foreach (var method in testMethods)
            {
                TestResult testResult = new TestResult();
                testResult.ClassName = instance.GetType().Name;
                testResult.TestName = method.Name;
                testResult.TestOutcome = "Failed";

                try
                {
                    stats.AddGlobalCount();
                    
                    Console.WriteLine("Running test: {0}", method.Name);
                    stats.StartLocalTime();
                    ExecuteMethods(testSetupMethods, instance);        
                    try
                    {
                        method.Invoke(instance, null); 
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        ExecuteMethods(testTeardownMethods, instance);
                    }

                    Console.WriteLine("  Passed ({0} s).", stats.LocalTime.TotalSeconds);
                    testResult.TestOutcome = "Passed";
                    testResult.Duration = stats.LocalTime;
                    stats.AddGlobalPassCount();
                }
                catch (Exception ex)
                {
                    stats.AddGlobalFailCount();
                    testResult.TestOutcome = "Failed";
                    string TestResultString = string.Empty;
                    // Check for a failing assert.
                    if (ex.InnerException != null)
                    {
                        string exceptionType = ex.InnerException.GetType().ToString();
                        switch (exceptionType)
                        {
                            case "Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException":
                            case "NUnit.Framework.AssertionException":
                                testResult.TestOutcome = "Failed";
                                TestResultString = String.Format("  Failed: {0} ({1} s).", ex.InnerException.Message, stats.LocalTime.TotalSeconds);
                                stats.AddGlobalFailCount();
                                Console.WriteLine(TestResultString);
                                testResult.Messages = TestResultString;
                                testResult.Duration = stats.LocalTime;
                                break;

                            case "Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException":
                            case "NUnit.Framework.Assert.InconclusiveException":

                                testResult.TestOutcome = "Inconclusive";
                                TestResultString = String.Format("  Inconclusive: {0} ({1} s).", ex.InnerException.Message, stats.LocalTime.TotalSeconds);
                                stats.AddGlobalInconclusiveCount();
                                Console.WriteLine(TestResultString);
                                testResult.Messages = TestResultString;
                                testResult.Duration = stats.LocalTime;
                                break;
                            default:
                                break;
                        }
                        continue;
                    }

                    // Unexpected error.
                    TestResultString = String.Format("  An unexpected error occured: {0}", ex.Message);
                   
                    if (ex.InnerException != null)
                    {
                        TestResultString = TestResultString + "\n" + string.Format("  Reason: {0}", ex.InnerException.Message);
                        Console.WriteLine(TestResultString);
                        testResult.Messages = TestResultString;
                    }
                }
                finally
                {
                    stats.ResetLocalTime();
                    testResults.Add(testResult);
                }
            }
        }

        private static bool CheckClassIsATestClass(IList<CustomAttributeData> attributes)
        {
            bool isMatched  = CheckForAttributes(false, attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.TestFixtureAttribute");
        }

        private static bool CheckMethodIsATestMethod(IList<CustomAttributeData> attributes)
        {
            bool isMatched  = CheckForAttributes(false, attributes, "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute");
            return CheckForAttributes(isMatched, attributes, "NUnit.Framework.TestAttribute");
        }

        private static bool CheckForAttributes(bool isMatched, IList<CustomAttributeData> attributes, string attributeName)
        {
            foreach (CustomAttributeData cad in attributes)
            {
                string tmpString = cad.ToString();
                tmpString = tmpString.Replace("[", "");
                tmpString = tmpString.Replace("]", "");
                tmpString = tmpString.Replace("(", "");
                tmpString = tmpString.Replace(")", "");

                if (tmpString == attributeName)
                {
                    isMatched = true;
                }
            }
            return isMatched;
        }

                
        private static void ShowAttributeData(IList<CustomAttributeData> attributes)
        {
            foreach (CustomAttributeData cad in attributes)
            {
                
                
                Console.WriteLine("   {0}", cad);
                Console.WriteLine("      Constructor: '{0}'", cad.Constructor);

                Console.WriteLine("      Constructor arguments:");
                foreach (CustomAttributeTypedArgument cata
                    in cad.ConstructorArguments)
                {
                    ShowValueOrArray(cata);
                }

                Console.WriteLine("      Named arguments:");
                foreach (CustomAttributeNamedArgument cana
                    in cad.NamedArguments)
                {
                    Console.WriteLine("         MemberInfo: '{0}'",
                        cana.MemberInfo);
                    ShowValueOrArray(cana.TypedValue);
                }
            }
        }

        private static void ShowValueOrArray(CustomAttributeTypedArgument cata)
        {
            if (cata.Value.GetType() == typeof(ReadOnlyCollection<CustomAttributeTypedArgument>))
            {
                Console.WriteLine("         Array of '{0}':", cata.ArgumentType);

                foreach (CustomAttributeTypedArgument cataElement in
                    (ReadOnlyCollection<CustomAttributeTypedArgument>)cata.Value)
                {
                    Console.WriteLine("             Type: '{0}'  Value: '{1}'",
                        cataElement.ArgumentType, cataElement.Value);
                }
            }
            else
            {
                Console.WriteLine("         Type: '{0}'  Value: '{1}'",
                    cata.ArgumentType, cata.Value);
            }
        }


        private static Assembly GetAssembly(string name)
        {
            Assembly assembly = Assembly.LoadFrom(name);
            string location = assembly.Location + ".config";
            string configFileName = name + ".config";

            if (File.Exists(location))
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", location);
                Console.WriteLine(String.Format("Configuration file loaded from: '{0}'", configFileName));

                Console.WriteLine();
            }

            return assembly;
        }

        private void WriterHeader(string title)
        {
            Console.WriteLine(title);
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (++i < title.Length + 1)
                sb.Append("-");

            Console.WriteLine(sb);
        }

        private string GetFullAssemblyPath(string path)
        {
            if (path.Contains(@":\"))
            {
                if (path.ToLower().EndsWith(".dll"))
                {
                    return Path.Combine(path);
                }
                else
                {
                    return Path.Combine(path + ".dll");
                }
            }
            else
            {
                if (path.ToLower().EndsWith(".dll"))
                {
                    return Path.Combine(Environment.CurrentDirectory, path);
                }
                else
                {
                    return Path.Combine(Environment.CurrentDirectory, path + ".dll");
                }
            }
        }

       
    }
}
