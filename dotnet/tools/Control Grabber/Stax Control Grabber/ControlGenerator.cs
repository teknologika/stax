/*Apache License
Version 2.0, January 2004
http://www.apache.org/licenses/

TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION

1. Definitions.

"License" shall mean the terms and conditions for use, reproduction, and distribution as defined by Sections 1 through 9 of this document.

"Licensor" shall mean the copyright owner or entity authorized by the copyright owner that is granting the License.

"Legal Entity" shall mean the union of the acting entity and all other entities that control, are controlled by, or are under common control with that entity. For the purposes of this definition, "control" means (i) the power, direct or indirect, to cause the direction or management of such entity, whether by contract or otherwise, or (ii) ownership of fifty percent (50%) or more of the outstanding shares, or (iii) beneficial ownership of such entity.

"You" (or "Your") shall mean an individual or Legal Entity exercising permissions granted by this License.

"Source" form shall mean the preferred form for making modifications, including but not limited to software source code, documentation source, and configuration files.

"Object" form shall mean any form resulting from mechanical transformation or translation of a Source form, including but not limited to compiled object code, generated documentation, and conversions to other media types.

"Work" shall mean the work of authorship, whether in Source or Object form, made available under the License, as indicated by a copyright notice that is included in or attached to the work (an example is provided in the Appendix below).

"Derivative Works" shall mean any work, whether in Source or Object form, that is based on (or derived from) the Work and for which the editorial revisions, annotations, elaborations, or other modifications represent, as a whole, an original work of authorship. For the purposes of this License, Derivative Works shall not include works that remain separable from, or merely link (or bind by name) to the interfaces of, the Work and Derivative Works thereof.

"Contribution" shall mean any work of authorship, including the original version of the Work and any modifications or additions to that Work or Derivative Works thereof, that is intentionally submitted to Licensor for inclusion in the Work by the copyright owner or by an individual or Legal Entity authorized to submit on behalf of the copyright owner. For the purposes of this definition, "submitted" means any form of electronic, verbal, or written communication sent to the Licensor or its representatives, including but not limited to communication on electronic mailing lists, source code control systems, and issue tracking systems that are managed by, or on behalf of, the Licensor for the purpose of discussing and improving the Work, but excluding communication that is conspicuously marked or otherwise designated in writing by the copyright owner as "Not a Contribution."

"Contributor" shall mean Licensor and any individual or Legal Entity on behalf of whom a Contribution has been received by Licensor and subsequently incorporated within the Work.

2. Grant of Copyright License.

Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable copyright license to reproduce, prepare Derivative Works of, publicly display, publicly perform, sublicense, and distribute the Work and such Derivative Works in Source or Object form.

3. Grant of Patent License.

Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, offer to sell, sell, import, and otherwise transfer the Work, where such license applies only to those patent claims licensable by such Contributor that are necessarily infringed by their Contribution(s) alone or by combination of their Contribution(s) with the Work to which such Contribution(s) was submitted. If You institute patent litigation against any entity (including a cross-claim or counterclaim in a lawsuit) alleging that the Work or a Contribution incorporated within the Work constitutes direct or contributory patent infringement, then any patent licenses granted to You under this License for that Work shall terminate as of the date such litigation is filed.

4. Redistribution.

You may reproduce and distribute copies of the Work or Derivative Works thereof in any medium, with or without modifications, and in Source or Object form, provided that You meet the following conditions:

1. You must give any other recipients of the Work or Derivative Works a copy of this License; and

2. You must cause any modified files to carry prominent notices stating that You changed the files; and

3. You must retain, in the Source form of any Derivative Works that You distribute, all copyright, patent, trademark, and attribution notices from the Source form of the Work, excluding those notices that do not pertain to any part of the Derivative Works; and

4. If the Work includes a "NOTICE" text file as part of its distribution, then any Derivative Works that You distribute must include a readable copy of the attribution notices contained within such NOTICE file, excluding those notices that do not pertain to any part of the Derivative Works, in at least one of the following places: within a NOTICE text file distributed as part of the Derivative Works; within the Source form or documentation, if provided along with the Derivative Works; or, within a display generated by the Derivative Works, if and wherever such third-party notices normally appear. The contents of the NOTICE file are for informational purposes only and do not modify the License. You may add Your own attribution notices within Derivative Works that You distribute, alongside or as an addendum to the NOTICE text from the Work, provided that such additional attribution notices cannot be construed as modifying the License.

You may add Your own copyright statement to Your modifications and may provide additional or different license terms and conditions for use, reproduction, or distribution of Your modifications, or for any such Derivative Works as a whole, provided Your use, reproduction, and distribution of the Work otherwise complies with the conditions stated in this License.

5. Submission of Contributions.

Unless You explicitly state otherwise, any Contribution intentionally submitted for inclusion in the Work by You to the Licensor shall be under the terms and conditions of this License, without any additional terms or conditions. Notwithstanding the above, nothing herein shall supersede or modify the terms of any separate license agreement you may have executed with Licensor regarding such Contributions.

6. Trademarks.

This License does not grant permission to use the trade names, trademarks, service marks, or product names of the Licensor, except as required for reasonable and customary use in describing the origin of the Work and reproducing the content of the NOTICE file.

7. Disclaimer of Warranty.

Unless required by applicable law or agreed to in writing, Licensor provides the Work (and each Contributor provides its Contributions) on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied, including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE. You are solely responsible for determining the appropriateness of using or redistributing the Work and assume any risks associated with Your exercise of permissions under this License.

8. Limitation of Liability.

In no event and under no legal theory, whether in tort (including negligence), contract, or otherwise, unless required by applicable law (such as deliberate and grossly negligent acts) or agreed to in writing, shall any Contributor be liable to You for damages, including any direct, indirect, special, incidental, or consequential damages of any character arising as a result of this License or out of the use or inability to use the Work (including but not limited to damages for loss of goodwill, work stoppage, computer failure or malfunction, or any and all other commercial damages or losses), even if such Contributor has been advised of the possibility of such damages.

9. Accepting Warranty or Additional Liability.

While redistributing the Work or Derivative Works thereof, You may choose to offer, and charge a fee for, acceptance of support, warranty, indemnity, or other liability obligations and/or rights consistent with this License. However, in accepting such obligations, You may act only on Your own behalf and on Your sole responsibility, not on behalf of any other Contributor, and only if You agree to indemnify, defend, and hold each Contributor harmless for any liability incurred by, or claims asserted against, such Contributor by reason of your accepting any such warranty or additional liability. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatiN.Core;

namespace Stax.ControlGrabber.ControlEye
{
    public static class ControlGenerator
    {
        internal static string GenerateControlCS(List<Control> validControls, List<Control> invalidControls, string className, string Namespace)
        {
            ObjectCollection controlCollection = new ObjectCollection();
            controlCollection.ControlMap = validControls;

            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.AppendLine("using System;");
            bobTheBuilder.AppendLine("using System.Collections.Generic;");
            bobTheBuilder.AppendLine("using System.Text;");
            bobTheBuilder.AppendLine("");
            bobTheBuilder.AppendLine("namespace " + Namespace + ".Controls");
            bobTheBuilder.AppendLine("{");
            bobTheBuilder.AppendLine("    public class " + className);
            bobTheBuilder.AppendLine("    {");

            foreach (Control item in validControls)
            {
                bobTheBuilder.AppendLine(GenerateControlLine(Namespace, className, item));
            }

            bobTheBuilder.AppendLine("/*");
            bobTheBuilder.AppendLine("The following are controls that cannot be properly generated");

            if (invalidControls != null)
            {
                foreach (Control item in invalidControls)
                {
                    bobTheBuilder.AppendLine(GenerateControlLine(Namespace, className, item));
                }
            }
            bobTheBuilder.AppendLine("*/");
            bobTheBuilder.AppendLine("    }");
            bobTheBuilder.AppendLine("}");

            return bobTheBuilder.ToString();


            //return SerializationHelper.SerializeObject<ObjectCollection>(controlCollection); ;
        }

        internal static string GeneratePhysicalCS(List<Control> validControls, List<Control> invalidControls, string className, string Namespace)
        {
            Namespace = Utility.ConvertStringToCamelCase(Namespace);
            className = Utility.ConvertStringToCamelCase(className);

            ObjectCollection controlCollection = new ObjectCollection();
            controlCollection.ControlMap = validControls;

            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.AppendLine("using System;");
            bobTheBuilder.AppendLine("using System.Collections.Generic;");
            bobTheBuilder.AppendLine("using System.Text;");
            bobTheBuilder.AppendLine("using Stax.Controllers.Web;");
          
            bobTheBuilder.AppendLine("using " + Namespace + ";");
            bobTheBuilder.AppendLine("using " + Namespace + ".Data;");
            bobTheBuilder.AppendLine("");
            bobTheBuilder.AppendLine("namespace " + Namespace + ".Physical");
            bobTheBuilder.AppendLine("{");
            bobTheBuilder.AppendLine("    public class " + className);
            bobTheBuilder.AppendLine("    {");
            bobTheBuilder.AppendLine("        public static void Set" + className + "Values(" + className + "Data testdata" +")");
            bobTheBuilder.AppendLine("        {");


            // Text Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.text)
                {
                    bobTheBuilder.AppendLine(GenerateSetValuesLine(Namespace, className, item));
                }
            }
            
            // Check Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.checkBox)
                {
                    bobTheBuilder.AppendLine(GenerateSetValuesLine(Namespace, className, item));
                }
            }
            // links

            // radio buttons
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.radiobutton)
                {
                    bobTheBuilder.AppendLine(GenerateSetValuesLine(Namespace, className, item));
                }
            }

            // Select lists
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.select)
                {
                    bobTheBuilder.AppendLine(GenerateSetValuesLine(Namespace, className, item));
                }
            }

            // button
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.button)
                {
                    if (item.Value.ToLower() == "submit" || item.Value.ToLower() == "save" || item.Value.ToLower() == "go" || item.Value.ToLower() == "search")
                    {
                        bobTheBuilder.AppendLine(GenerateSetValuesLine(Namespace, className, item));
                    }
                    else
                    {
                        bobTheBuilder.AppendLine(@"//" + GenerateSetValuesLine(Namespace, className, item));
                    }
                }
            }
            bobTheBuilder.AppendLine("        }");


            bobTheBuilder.AppendLine("        public static " + className + "Data Get" + className + "Values(" + className + "Data testdata" + ")");
            bobTheBuilder.AppendLine("        {");
            bobTheBuilder.AppendLine("            " + className + "Data actual = new " + className + "Data();");
            // Text Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.text)
                {
                    bobTheBuilder.AppendLine(GenerateGetValuesLine(Namespace, className, item));
                }
            }

            // Check Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.checkBox)
                {
                    bobTheBuilder.AppendLine(GenerateGetValuesLine(Namespace, className, item));
                }
            }
            // links

            // radio buttons
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.radiobutton)
                {
                    bobTheBuilder.AppendLine(GenerateGetValuesLine(Namespace, className, item));
                }
            }

            // Select lists
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.select)
                {
                    bobTheBuilder.AppendLine(GenerateGetValuesLine(Namespace, className, item));
                }
            }

            bobTheBuilder.AppendLine("            return actual;");
            bobTheBuilder.AppendLine("        }");
            bobTheBuilder.AppendLine("    }");
            bobTheBuilder.AppendLine("}");

            return bobTheBuilder.ToString();


            //return SerializationHelper.SerializeObject<ObjectCollection>(controlCollection); ;
        }

        internal static string GenerateDataCS(List<Control> validControls, List<Control> invalidControls, string className, string Namespace)
        {
            Namespace = Utility.ConvertStringToCamelCase(Namespace);
            className = Utility.ConvertStringToCamelCase(className);


           ObjectCollection controlCollection = new ObjectCollection();
            controlCollection.ControlMap = validControls;

            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.AppendLine("using System;");
            bobTheBuilder.AppendLine("using System.Collections.Generic;");
            bobTheBuilder.AppendLine("using System.Text;");
            bobTheBuilder.AppendLine("");
            bobTheBuilder.AppendLine("namespace " +Namespace + ".Data");
            bobTheBuilder.AppendLine("{");
            bobTheBuilder.AppendLine("    public partial class " + className + "Data");
            bobTheBuilder.AppendLine("    {");


            
            // Text Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.text)
                {
                    bobTheBuilder.AppendLine(GenerateDataLine(Namespace, className, item));
                }
            }
            
            // Check Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.checkBox)
                {
                    bobTheBuilder.AppendLine(GenerateDataLine(Namespace, className, item));
                }
            }
            // links

            // radio buttons
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.radiobutton)
                {
                    bobTheBuilder.AppendLine(GenerateDataLine(Namespace, className, item));
                }
            }

            // Select lists
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.select)
                {
                    bobTheBuilder.AppendLine(GenerateDataLine(Namespace, className, item));
                }
            }

           
            bobTheBuilder.AppendLine("    }");
            bobTheBuilder.AppendLine("}");

            return bobTheBuilder.ToString();
        }

        internal static string GenerateVerificationCS(List<Control> validControls, List<Control> invalidControls, string className, string Namespace)
        {
            string UnitTestFramework = "MsTest";

            Namespace = Utility.ConvertStringToCamelCase(Namespace);
            className = Utility.ConvertStringToCamelCase(className);

            ObjectCollection controlCollection = new ObjectCollection();
            controlCollection.ControlMap = validControls;

            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.AppendLine("using System;");
            bobTheBuilder.AppendLine("using System.Collections.Generic;");
            bobTheBuilder.AppendLine("using System.Text;");
            if (UnitTestFramework == "NUnit")
            {
                bobTheBuilder.AppendLine("using NUnit.Framework;");
            }
            else if (UnitTestFramework == "MsTest")
            {
                bobTheBuilder.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
            }   
            bobTheBuilder.AppendLine("using " + Namespace + ";");
            bobTheBuilder.AppendLine("using " + Namespace + ".Data;");
            bobTheBuilder.AppendLine("using " + Namespace + ".Physical;");
            bobTheBuilder.AppendLine("");
            bobTheBuilder.AppendLine("namespace " + Namespace + ".Verification");
            bobTheBuilder.AppendLine("{");
            bobTheBuilder.AppendLine("    public class " + className);
            bobTheBuilder.AppendLine("    {");
            bobTheBuilder.AppendLine("        public static void Verify" + className + "(" + className + "Data expected" + ")");
            bobTheBuilder.AppendLine("        {");
            bobTheBuilder.AppendLine("             " + className + "Data actual = new " + className + "Data();");
            bobTheBuilder.AppendLine("");

            // Text Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.text)
                {
                    bobTheBuilder.AppendLine(GenerateVerificationLine(Namespace, className, item));
                }
            }

            // Check Boxes
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.checkBox)
                {
                    bobTheBuilder.AppendLine(GenerateVerificationLine(Namespace, className, item));
                }
            }
            // links

            // radio buttons
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.radiobutton)
                {
                    bobTheBuilder.AppendLine(GenerateVerificationLine(Namespace, className, item));
                }
            }

            // Select lists
            foreach (Control item in validControls)
            {
                if (item.Type == ControlType.select)
                {
                    bobTheBuilder.AppendLine(GenerateVerificationLine(Namespace, className, item));
                }
            }

            bobTheBuilder.AppendLine("        }");
            bobTheBuilder.AppendLine("    }");
            bobTheBuilder.AppendLine("}");

            return bobTheBuilder.ToString();

        }

        private static string GenerateVerificationLine(string Namespace, string className, Control control)
        {
            switch (control.Type)
            {

                case ControlType.checkBox:
                case ControlType.radiobutton:
                case ControlType.select:
                case ControlType.text:
                    string nameToUse = Utility.ConvertStringToCamelCase(control.RawName);
                    return "             Assert.AreEqual(expected." + nameToUse + ",actual." + nameToUse + ");";
                default:
                    break;
            }
            return string.Empty;

        }

        private static string GenerateDataLine(string Namespace, string className, Control control)
        {
            StringBuilder ncs = new StringBuilder();
            switch (control.Type)
            {
                case ControlType.checkBox:
                    ncs.Append("            public string " + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.radiobutton:
                    ncs.Append("            public string " + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.select:
                    ncs.Append("            public string " + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.text:
                    ncs.Append("            public string " + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                default:
                    break;
            }

            ncs.Append(";");
            // TODO: write out the control to the string here ....
            return ncs.ToString();
        }

        internal static string GenerateControlXml(List<Control> controlList, string pageTitle)
        {
            //TODO: Modify Xml Generation to support the invalid control List
            ObjectCollection controlCollection = new ObjectCollection();
            controlCollection.ControlMap = controlList;
            return SerializationHelper.SerializeObject<ObjectCollection>(controlCollection); ;
        }

        /// <summary>
        /// Retrieve the control contained in the supplied IEContainer
        /// </summary>
        /// <param name="IE">IEContainer</param>
        internal static void GenerateControl(IEDocument IE, ControlSelection selections, List<Control> validControls, List<Control> invalidControl)
        {
            Control tempControl = new Control();

            Cursor.Current = Cursors.WaitCursor;

           

            //Loop through all types of control supported by Watin and add the control to the appropriate control list

            AddControlsforDocument(IE, selections, validControls, invalidControl,"");

            if (IE.Frames.Count > 0)
            {  
                foreach (var item in IE.Frames)
	            {
                    AddControlsforDocument(item, selections, validControls, invalidControl,item.Id);
	            }
            }


            

            Cursor.Current = Cursors.Default;
        }

        private static void AddControlsforDocument(Document IE, ControlSelection selections, List<Control> validControls, List<Control> invalidControl, string frameName)
        {

            if (selections.TextField)
            {
                foreach (WatiN.Core.TextField textField in IE.TextFields)
                {
                    AddControlToList(textField, "txt", ControlType.text, validControls, invalidControl, frameName);
                }
            }

            if (selections.SelectList)
            {
                foreach (WatiN.Core.SelectList selectList in IE.SelectLists)
                {
                    AddControlToList(selectList, "ddl", ControlType.select, validControls, invalidControl, frameName);
                }
            }

            if (selections.CheckBox)
            {
                foreach (WatiN.Core.CheckBox checkBox in IE.CheckBoxes)
                {
                    AddControlToList(checkBox, "chk", ControlType.checkBox, validControls, invalidControl, frameName);
                }
            }

            if (selections.Div)
            {
                foreach (WatiN.Core.Div div in IE.Divs)
                {
                    AddControlToList(div, "div", ControlType.div, validControls, invalidControl, frameName);
                }
            }

            if (selections.Image)
            {
                foreach (WatiN.Core.Image image in IE.Images)
                {
                    AddControlToList(image, "img", ControlType.image, validControls, invalidControl, frameName);
                }
            }

            if (selections.Label)
            {
                foreach (WatiN.Core.Label label in IE.Labels)
                {
                    AddControlToList(label, "lbl", ControlType.label, validControls, invalidControl, frameName);
                }
            }

            if (selections.Link)
            {
                foreach (WatiN.Core.Link link in IE.Links)
                {
                    AddControlToList(link, "lnk", ControlType.link, validControls, invalidControl, frameName);
                }
            }

            if (selections.RadioButton)
            {
                foreach (WatiN.Core.RadioButton radioButton in IE.RadioButtons)
                {
                    AddControlToList(radioButton, "rdo", ControlType.radiobutton, validControls, invalidControl, frameName);
                }
            }



            if (selections.Span)
            {
                foreach (WatiN.Core.Span span in IE.Spans)
                {
                    AddControlToList(span, "span", ControlType.span, validControls, invalidControl, frameName);
                }
            }

            if (selections.Table)
            {
                foreach (WatiN.Core.Table table in IE.Tables)
                {
                    AddControlToList(table, "tbl", ControlType.table, validControls, invalidControl, frameName);
                }
            }

            if (selections.Button)
            {
                foreach (WatiN.Core.Button button in IE.Buttons)
                {
                    AddControlToList(button, "btn", ControlType.button, validControls, invalidControl, frameName);
                }
            }
        }

        private static string GenerateControlLine(string Namespace, string className, Control control)
        {
            StringBuilder ncs = new StringBuilder();
            ncs.Append("        public static string ");
            ncs.Append(Utility.ConvertStringToPascalCase(control.Name));
            ncs.Append(" = ");
            ncs.Append("\"");
            ncs.Append("type=" + control.Type + ";");

            // this could be the last item so no semicolon
            ncs.Append(control.Key + "=" + control.Value);

            if (!string.IsNullOrEmpty(control.frame))
            {
                ncs.Append(";frame=" + control.frame );
            }

            if (control.WaitForComplete)
            {
                ncs.Append(";WaitForComplete=true");
            }

            ncs.Append("\";");
            // TODO: write out the control to the string here ....

            return ncs.ToString();
        }

        private static string GenerateSetValuesLine(string NameSpace, String ClassName, Control control)
        {
            string handler ="Browser";

            StringBuilder ncs = new StringBuilder();
            switch (control.Type)
            {
                case ControlType.button:
                    ncs.Append("            " + handler + ".Invoke(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name));
                    break;
                case ControlType.checkBox:
                    ncs.Append("            " + handler + ".SetValue(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name) + ",testdata." + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.link:
                    ncs.Append("            " + handler + ".Invoke(Controls." +ClassName + "." + Utility.ConvertStringToPascalCase(control.Name));
                    break;
                case ControlType.radiobutton:
                    ncs.Append("            " + handler + ".SetValue(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name) + ",testdata." + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.select:
                    ncs.Append("            " + handler + ".SetValue(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name) + ",testdata." + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                case ControlType.text:
                    ncs.Append("            " + handler + ".SetValue(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name) + ",testdata." + Utility.ConvertStringToCamelCase(control.RawName));
                    break;
                default:
                    break;
            }

            ncs.Append(");");
            // TODO: write out the control to the string here ....
            return ncs.ToString();
        }

        private static string GenerateGetValuesLine(string NameSpace, String ClassName, Control control)
        {
            string handler = "Browser";

            StringBuilder ncs = new StringBuilder();
            switch (control.Type)
            {
                case ControlType.button:
                case ControlType.checkBox:
                case ControlType.link:            
                case ControlType.radiobutton:
                case ControlType.select:
                case ControlType.text:
                    ncs.Append("            actual." + control.RawName + " = " + handler + ".GetValue(Controls." + ClassName + "." + Utility.ConvertStringToPascalCase(control.Name));
                    break;
                default:
                    break;
            }

            ncs.Append(");");
            // TODO: write out the control to the string here ....
            return ncs.ToString();
        }

        private static void AddControlToList(Element element, string namePrefix, ControlType type, List<Control> validControls, List<Control> invalidControls)
        {
            AddControlToList(element, namePrefix, type, validControls, invalidControls, string.Empty);
        }

        private static void AddControlToList(Element element, string namePrefix, ControlType type, List<Control> validControls, List<Control> invalidControls, string FrameName)
        {
            List<Control> tmpVaildControls = validControls;
            List<Control> tmpInvalidControls = invalidControls;
            Control tempControl = new Control();

            

            tempControl = GetControlIdentity(element);

            if (tempControl != null)
            {
                tempControl.Type = type;
                if (!Utility.IsValidName(tempControl.Value) && !String.IsNullOrEmpty(element.Text))
                {
                    if (tempControl.Type == ControlType.select && !String.IsNullOrEmpty(element.Id))
                    {
                        tempControl.RawName = Utility.ConvertStringToCamelCase(element.Id);
                        tempControl.Name = namePrefix + Utility.ConvertStringToCamelCase(element.Id);
                    }
                    else
                    {
                        tempControl.RawName = Utility.ConvertStringToCamelCase(element.Text);
                        tempControl.Name = namePrefix + Utility.ConvertStringToCamelCase(element.Text);
                    }
                }
                else
                {
                    if (tempControl.Type == ControlType.select && !String.IsNullOrEmpty(element.Id))
                    {
                        tempControl.RawName = Utility.ConvertStringToCamelCase(element.Id);
                        tempControl.Name = namePrefix + Utility.ConvertStringToCamelCase(element.Id);
                    }
                    else
                    {
                        tempControl.RawName = Utility.ConvertStringToCamelCase(tempControl.Value);
                        tempControl.Name = namePrefix + Utility.ConvertStringToCamelCase(tempControl.Value);
                    }
                }

                if (!string.IsNullOrEmpty(FrameName))
                {
                    tempControl.frame = FrameName;
                }

                tempControl.RawName = tempControl.RawName.Replace(" ", "");
                tempControl.Name = tempControl.Name.Replace(" ", "");

                
                if (Utility.IsValidControl(tempControl))
                {
                    bool matchfound = false;
                    foreach (var item in validControls)
                    {
                        if (item.Name == tempControl.Name)
                        {
                            matchfound = true;
                        }
                    }
                    if (!matchfound)
                    {
                        validControls.Add(tempControl);
                    }
                }
                else
                {
                    bool matchfound = false;
                    foreach (var item in invalidControls)
                    {
                        if (item.Name == tempControl.Name)
                        {
                            matchfound = true;
                        }
                    }
                    if (!matchfound)
                    {
                        invalidControls.Add(tempControl);
                    }
                }


            }
        }

        /// <summary>
        /// Retrieve the identification attribute detail of the element with the following priority:
        /// "id", "name", "value", "alt", "custom", "for", "index", "src", "href", "style", "text", "title", "url"
        /// </summary>
        /// <param name="element">Element</param>
        private static Control GetControlIdentity(WatiN.Core.Element element)
        {
            Control control = new Control();

            if (!String.IsNullOrEmpty(element.Id))
            {
                control.Key = ControlKeyType.id;
                control.Value = element.Id.Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("name")))
            {
                control.Key = ControlKeyType.name;
                control.Value = element.GetAttributeValue("name").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("value")))
            {
                control.Key = ControlKeyType.value;
                control.Value = element.GetAttributeValue("value").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("alt")))
            {
                control.Key = ControlKeyType.alt;
                control.Value = element.GetAttributeValue("alt").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("custom")))
            {
                control.Key = ControlKeyType.custom;
                control.Value = element.GetAttributeValue("custom").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("index")))
            {
                control.Key = ControlKeyType.index;
                control.Value = element.GetAttributeValue("index").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("src")))
            {
                control.Key = ControlKeyType.src;
                control.Value = element.GetAttributeValue("src").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("href")))
            {
                control.Key = ControlKeyType.href;
                control.Value = element.GetAttributeValue("href").Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("style")))
            {
                control.Key = ControlKeyType.style;
                control.Value = element.GetAttributeValue("style").Trim();
            }
            else if (!String.IsNullOrEmpty(element.Text))
            {
                control.Key = ControlKeyType.text;
                control.Value = element.Text.Trim();
            }
            else if (!String.IsNullOrEmpty(element.Title))
            {
                control.Key = ControlKeyType.title;
                control.Value = element.Title.Trim();
            }
            else if (!String.IsNullOrEmpty(element.GetAttributeValue("url")))
            {
                control.Key = ControlKeyType.url;
                control.Value = element.GetAttributeValue("url").Trim();
            }
            else
            {
                control = null;
            }

            return control;
        }




    }
}
