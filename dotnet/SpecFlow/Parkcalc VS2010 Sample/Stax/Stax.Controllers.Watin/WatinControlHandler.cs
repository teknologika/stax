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
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WatiN.Core;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Native.Windows;
using System.Security;
using System.Net;
using System.Security.Principal;
using System.Reflection;
using System.IO;
using Fizzler;
using WatiNCssSelectorExtensions;

namespace Stax.Controllers.Web.Watin
{
    public partial class Browser
    {
        private static IE _ie;
        private static Document _document;
        static readonly object threadSafeLock = new object();
        private static WatinControlStringHandler _control;
        private static int defaultTimeout = 5000;
        private static WatiN.Core.Table _table;  //To modify the Watin Table controller.
        public static WatinTableHandler Table;  //To defined the table handler and called from the Control Handler

        //This stuff is required for alternate user support
        private static NetworkCredential alternateUserCredentials = new NetworkCredential();
        private static IntPtr hToken = IntPtr.Zero;
        private static IntPtr hTokenDuplicate = IntPtr.Zero;
        private static WindowsIdentity windowsIdentity = null;
        private static WindowsImpersonationContext impersonationContext = null;


        private Browser()
        {
        }

        private static void StartIE()
        {
            int globalTimeout = 0;
            if (Int32.TryParse(ConfigurationManager.AppSettings["GlobalIETimeout"], out globalTimeout))
            {
                WatiN.Core.Settings.WaitForCompleteTimeOut = globalTimeout;
                defaultTimeout = globalTimeout;
            }

            _ie = new IE();
            //string baseUrl = String.Empty;
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["BaseURL"]))
            {
                _ie.GoTo(ConfigurationManager.AppSettings["BaseURL"]);
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["MaximizeBrowser"]))
            {
                _ie.ShowWindow(NativeMethods.WindowShowStyle.ShowMaximized);
            }

            InjectJQueryAjaxMonitor();
            // _ie.AddDialogHandler(new LogonDialogCloser());
            // _ie.AddDialogHandler(new MessageFromPageDialogHandler());
            //_ie.AddDialogHandler(new CloseIEDialogHandler(true));

        }

        public static void Close()
        {
            try
            {
                if (_ie != null)
                {
                    if (_ie.InternetExplorer != null)
                    {
                        Process ieProcess = Process.GetProcessById(_ie.ProcessID);
                        _ie.Close();
                        _ie.Dispose();
                        _ie = null;
                        if (!ieProcess.HasExited)
                        {
                            ieProcess.Kill();
                        }
                    }
                }
            }
            catch
            {
                _ie = null;
            }
        }

        public static void SetAlternateUser(string userName, string password, string domain)
        {
            // thread safe singleton code
            lock (threadSafeLock)
            {
                if (_ie == null)
                {
                    StartIE();
                }

                _ie.Close();
                _ie = null;


                // fill the NetworkCredeitials object that we use for impersonation
                if (string.IsNullOrEmpty(domain))
                {
                    alternateUserCredentials = new NetworkCredential(userName, password);
                }
                else
                {
                    alternateUserCredentials = new NetworkCredential(userName, password, domain);
                }

                // Prepare to launch
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UserName = userName;
                psi.Password = SecurePassword(password);
                if (!string.IsNullOrEmpty(domain))
                {
                    psi.Domain = domain;
                }
                psi.UseShellExecute = false;
                psi.LoadUserProfile = true;
                psi.FileName = "c:\\Program Files\\Internet Explorer\\iexplore.exe";
                psi.Arguments = "about:blank";


                // launch
                Process proc = new Process();
                proc.StartInfo = psi;
                proc.Start();

                // Time to become an imposter
                hToken = IntPtr.Zero;
                hTokenDuplicate = IntPtr.Zero;

                if (Win32.LogonUser(alternateUserCredentials.UserName, alternateUserCredentials.Domain, alternateUserCredentials.Password, 2 /*LOGON32_LOGON_INTERACTIVE*/, 0 /*LOGON32_PROVIDER_DEFAULT*/, out hToken))
                {
                    if (Win32.DuplicateToken(hToken, 2, out hTokenDuplicate))
                    {
                        windowsIdentity = new WindowsIdentity(hTokenDuplicate);
                        impersonationContext = windowsIdentity.Impersonate();
                        //_ie = new IE();
                        System.Threading.Thread.Sleep(1000);
                        _ie = IE.AttachToIE(Find.ByUrl("about:blank"));
                        _document = _ie.DomContainer;
                        InjectJQueryAjaxMonitor();

                    }
                }
            }
        }


        /// <summary>
        /// Public method that will return the ControlHandler -> singleton
        /// </summary>
        /// <returns>ControlHandler</returns>
        private static IE BrowserController
        {
            get
            {
                // thread safe singleton code
                lock (threadSafeLock)
                {
                    if (_ie == null)
                    {
                        StartIE();
                    }
                    else
                    {
                        if (_ie.InternetExplorer == null)
                        {
                            _ie = null;
                            StartIE();
                        }
                    }
                    _document = _ie.DomContainer;
                    return _ie;
                }
            }
        }


        private static void SetDocument()
        {
            _document = _ie.DomContainer;
            if (!String.IsNullOrEmpty(_control.HTMLDialog))
            {
                _document = _ie.HtmlDialog(Find.ByTitle(new Regex(_control.HTMLDialog)));
            }

            if (!String.IsNullOrEmpty(_control.Frame))
            {
                string[] frames = _control.Frame.Split(',');
                foreach (string frame in frames)
                {
                    try
                    {
                        _document = _document.Frame(Find.BySrc(new Regex(frame)));
                    }
                    catch
                    {
                        _document = _document.Frame(Find.ById(new Regex(frame)));
                    }
                }
            }
        }

        /// <summary>
        /// Goes to.
        /// </summary>
        /// <param name="url">The URL.</param>
        public static void GoTo(string url)
        {
            BrowserController.GoTo(new Uri(url));
        }

        /// <summary>
        /// Goes to.
        /// </summary>
        /// <param name="url">The URL.</param>
        public static void GoTo(Uri uri)
        {
            BrowserController.GoTo(uri);
            InjectJQueryAjaxMonitor();
        }

        /// <summary>
        /// Invokes the specified control.
        /// </summary>
        /// <param name="ControlString">The control.</param>
        public static void Invoke(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "button":
                case "submit":
                    if (_control.WaitForComplete)
                    {
                        _document.Button(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Button(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "link":

                    if (_control.WaitForComplete)
                    {
                        _document.Link(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Link(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "image":
                    if (_control.WaitForComplete)
                    {
                        _document.Image(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Image(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "radiobutton":
                    if (_control.WaitForComplete)
                    {
                        _document.RadioButton(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.RadioButton(_control.WatinAttribute).ClickNoWait();

                    }
                    break;

                case "checkbox":
                    if (_control.WaitForComplete)
                    {
                        _document.CheckBox(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.CheckBox(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "div":
                    if (_control.WaitForComplete)
                    {
                        _document.Div(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Div(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "span":
                    if (_control.WaitForComplete)
                    {
                        _document.Span(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Span(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                case "table":
                    if (_control.WaitForComplete)
                    {
                        _document.Table(_control.WatinAttribute).Click();
                    }
                    else
                    {
                        _document.Table(_control.WatinAttribute).ClickNoWait();
                    }
                    break;

                default:
                    throw new NotImplementedException(" The control has not been implemented in Controller.Invoke");
            }
        }

        /// <summary>
        /// Invokes the specified control.
        /// </summary>
        /// <param name="ControlString">The control.</param>
        public static string GetControlStyle(string controlString)
        {
            string value = "";
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "button":
                case "submit":
                    value = _document.Button(_control.WatinAttribute).Style.ToString();
                    break;

                case "link":
                    value = _document.Link(_control.WatinAttribute).Style.ToString();
                    break;

                case "image":
                    value = _document.Image(_control.WatinAttribute).Style.ToString();
                    break;

                case "radiobutton":
                    value = _document.RadioButton(_control.WatinAttribute).Style.ToString();
                    break;

                case "checkbox":
                    value = _document.CheckBox(_control.WatinAttribute).Style.ToString();
                    break;

                case "div":
                    value = _document.Div(_control.WatinAttribute).Style.ToString();
                    break;

                case "span":
                    value = _document.Span(_control.WatinAttribute).Style.ToString();
                    break;

                case "table":
                    value = _document.Table(_control.WatinAttribute).Style.ToString();
                    break;
                default:
                    throw new NotImplementedException(" The control has not been implemented in Controller.GetControlStyle");
            }

            return value;
        }

        public static string GetParentControlStyle(string controlString)
        {
            string value = "";
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "button":
                case "submit":
                    value = _document.Button(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "link":
                    value = _document.Link(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "image":
                    value = _document.Image(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "radiobutton":
                    value = _document.RadioButton(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "checkbox":
                    value = _document.CheckBox(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "div":
                    value = _document.Div(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "span":
                    value = _document.Span(_control.WatinAttribute).Parent.Style.ToString();
                    break;

                case "table":
                    value = _document.Table(_control.WatinAttribute).Parent.Style.ToString();
                    break;
                default:
                    throw new NotImplementedException(" The control has not been implemented in Controller.GetParentControlStyle");
            }
            return value;
        }

        public static void SetValue(string controlString, string value)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "input":
                case "text":
                    if (!string.IsNullOrEmpty(value))
                    {
                        _document.TextField(_control.WatinAttribute).Value = value ?? string.Empty;
                        WaitForAsyncPostBackToComplete();
                    }
                    break;

                case "typetext":
                    if (!string.IsNullOrEmpty(value))
                    {
                        _document.TextField(_control.WatinAttribute).TypeText(value ?? string.Empty);
                        WaitForAsyncPostBackToComplete();
                    }
                    break;

                case "select":
                    // if the value to set is empty, ignore it.
                    if (!string.IsNullOrEmpty(value))
                    {
                        WaitForAsyncPostBackToComplete();
                        _document.SelectList(_control.WatinAttribute).Select(value);
                        WaitForAsyncPostBackToComplete();
                    }
                    break;

                case "checkbox":
                    // if the value to set is empty, ignore it.
                    if (!string.IsNullOrEmpty(value))
                    {
                        bool isChecked;
                        bool.TryParse(value, out isChecked);
                        _document.CheckBox(_control.WatinAttribute).Checked = isChecked;

                        WaitForAsyncPostBackToComplete();
                    }
                    break;

                case "radiobutton":
                    // if the value to set is empty, ignore it.
                    if (!string.IsNullOrEmpty(value))
                    {
                        _document.RadioButton((_control.WatinAttribute) && Find.ByValue(value)).Checked = true; 
                        WaitForAsyncPostBackToComplete(); ;
                    }
                    break;

                case "fileupload":
                    _document.FileUpload(_control.WatinAttribute).Set(value);
                    WaitForAsyncPostBackToComplete();
                    break;

                default:
                    throw new NotImplementedException("The control type has not been implemented in Stax.Controller.Watin SetValue()");
            }
            _document = BrowserController.DomContainer;
        }

        private static void WebActionSetUp(string controlString)
        {
            _control = new WatinControlStringHandler(controlString);
            if (_control.WaitForComplete)
            {
                _ie.WaitForComplete();
            }

            WaitForAsyncPostBackToComplete();
            SetDocument();

            if (!string.IsNullOrEmpty(_control.CSSSelector))
            {
              
            }

        }

        public static void SetValue(string controlString, bool value)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "checkbox":
                    _document.CheckBox(_control.WatinAttribute).Checked = value;
                    WaitForAsyncPostBackToComplete();
                    break;

                case "radiobutton":
                    _document.RadioButton(_control.WatinAttribute).Checked = value;
                    WaitForAsyncPostBackToComplete();
                    break;
                default:
                    throw new NotImplementedException("he control type has not been implemented in Stax.Controller.Watin SetValue()");
            }
            _document = BrowserController.DomContainer;
        }


        public static string GetValue(string controlString)
        {
            WebActionSetUp(controlString);

            string text;
            switch (_control.ControlType)
            {
                case "span":
                    text = _document.Span(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "label":
                    text = _document.Label(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "text":
                case "typetext":
                case "textarea":
                    text = _document.TextField(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "div":
                    text = _document.Div(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "table":
                    text = _document.Table(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "radiobutton":
                    text = _document.RadioButton(_control.WatinAttribute).Text ?? string.Empty;
                    break;

                case "checkbox":
                    // since text is string, we have to 'translate it from bool'
                    bool isChecked = _document.CheckBox(_control.WatinAttribute).Checked;
                    text = isChecked ? bool.TrueString : bool.FalseString;
                    break;
                case "select":
                    text = _document.SelectList(_control.WatinAttribute).Text ?? string.Empty;
                    break;
                case "link":
                    text = _document.Link(_control.WatinAttribute).Text ?? string.Empty;
                    break;
                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin GetValue()");
            }
            return text;
        }

        public static bool DoesControlExist(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "select":
                    if (_document.SelectList(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        // Give a guy a second chance
                        System.Threading.Thread.Sleep(500);

                        return _document.SelectList(_control.WatinAttribute).Exists;
                    }

                case "text":
                case "typetext":
                    if (_document.TextField(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "div":
                    if (_document.Div(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "link":
                    if (_document.Link(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "checkbox":
                    if (_document.CheckBox(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "button":
                case "submit":
                    if (_document.Button(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "label":
                    if (_document.Label(_control.WatinAttribute).Exists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "span":
                    return _document.Span(_control.WatinAttribute).Exists;

                default:
                    throw new NotImplementedException(
                        "he control type has not been implemented in Stax.Controller.Watin.IsControlExisting");
            }
        }

        public static bool IsControlEnabled(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "text":
                case "typetext":
                    if (_document.TextField(_control.WatinAttribute).Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "link":
                    if (_document.Link(_control.WatinAttribute).Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "checkbox":
                    if (_document.CheckBox(_control.WatinAttribute).Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "select":
                    if (_document.SelectList(_control.WatinAttribute).Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "table":
                    if (_document.Table(_control.WatinAttribute).Enabled)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin.IsControlEnabled");
            }

        }

        public static bool IsControlEditable(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "text":
                case "typetext":
                    if (_document.TextField(_control.WatinAttribute).GetAttributeValue("isContentEditable") == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "checkbox":
                    if (_document.CheckBox(_control.WatinAttribute).GetAttributeValue("isContentEditable") == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "select":
                    if (_document.SelectList(_control.WatinAttribute).GetAttributeValue("isContentEditable") == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "span":
                    if (_document.Span(_control.WatinAttribute).GetAttributeValue("isContentEditable") == "True")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin.IsControlEditable");
            }

        }

        public static bool IsControlChecked(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "checkbox":
                    if (_document.CheckBox(_control.WatinAttribute).Checked)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin.IsControlChecked");
            }

        }

        public bool DoesSelectControlContain(string controlString, string expectedContent)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "select":
                    if (_document.SelectList(_control.WatinAttribute).AllContents.Contains(expectedContent))
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                default:
                    throw new NotImplementedException
                    ("The control type has not been implemented in Stax.Controller.Watin.IsSelectControlContains");
            }


        }

        public static int GetSelectControlOptionNumber(string controlString)
        {
            WebActionSetUp(controlString);

            switch (_control.ControlType)
            {
                case "select":
                    return _document.SelectList(_control.WatinAttribute).AllContents.Count;
                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin.GetSelectControlOptionNumber");
            }

        }

        private static void WaitForAsyncPostBackToComplete()
        {
             // When using JQuery, ensurre
            // the page is currently not in an async postback or wait for it to complete

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSupportForJQueryAjaxControls"]))
            {
                int timeWaitedInMilliseconds = 0;
                var maxWaitTimeInMilliseconds = Settings.WaitForCompleteTimeOut * 1000;

                // the exception is to handle if the page does not have the ajax control toolkit code ready and loaded
                try
                {
                    // This line of code calls javascript in browser to execute the ajax toolkit's
                    // get_isInAsyncPostBack method
                    while ((_ie.Eval("watinAjaxMonitor.isRequestInProgress()") == "true") && timeWaitedInMilliseconds < maxWaitTimeInMilliseconds)
                    {
                        System.Threading.Thread.Sleep(200);
                        timeWaitedInMilliseconds += 200;
                    }   
                }
                catch (WatiN.Core.Exceptions.JavaScriptException e)
                {
                    if (e.Message == "TypeError: 'watinAjaxMonitor' is undefined")
                    {
                        InjectJQueryAjaxMonitor();
                    }
                    else if (e.Message == "TypeError: 'watinAjaxMonitor' is null or not an object")
                    {
                    }
                    else
                    {
                        throw;
                    }
                }
               


            }



            // When using the Ajax control toolkit ensure that
            // the page is currently not in an async postback or wait for it to complete
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSupportForAjaxControlToolkit"]))
            {
                bool isInPostback = true;
                while (isInPostback)
                {

                    // the exception is to handle if the page does not have the ajax control toolkit code ready and loaded
                    try
                    {
                        // This line of code calls javascript in browser to execute the ajax toolkit's
                        // get_isInAsyncPostBack method
                        isInPostback = Convert.ToBoolean(_ie.Eval("Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack();"));

                    }
                    catch (WatiN.Core.Exceptions.JavaScriptException e)
                    {
                        if (e.Message == "TypeError: 'Sys' is undefined")
                        {
                            isInPostback = false;
                            break;
                        }
                        else
                        {
                            throw;
                        }
                    }

                    // This exception is being thrown when running under impersonation
                    // I think the eval needs an impersonation call first
                    catch (WatiN.Core.Exceptions.RunScriptException scriptException)
                    {
                        Debug.Print(scriptException.Message);
                        isInPostback = false;
                    }
                    if (isInPostback)
                    {
                        //sleep for 200ms and query again  
                        System.Threading.Thread.Sleep(200);
                    }
                }
            }
        }


        internal static void InjectJQueryAjaxMonitor()
        {

            const string monitorScript =
                @"function AjaxMonitor(){"
                + "var ajaxRequestCount = 0;"

                + "$(document).ajaxStart(function(){"
                + "    ajaxRequestCount++;"
                + "});"

                + "$(document).ajaxComplete(function(){"
                + "    ajaxRequestCount--;"
                + "});"

                + "this.isRequestInProgress = function(){"
                + "    return (ajaxRequestCount > 0);"
             
                + "};"
                + "}"

                + "var watinAjaxMonitor = new AjaxMonitor();";
            
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSupportForJQueryAjaxControls"]))
            {
               
                try
                {
                    // This line of code injects javascript in browser to track the JQuery ajax events
                    _ie.Eval(monitorScript);
                }
                catch (WatiN.Core.Exceptions.JavaScriptException e)
                {
                    if (e.Message != "TypeError: Object expected")
                    {
                        throw;
                    }
                }
            }
        }


        public static void WaitUntilFrameExists(string frameName)
        {

            bool a = _document.Element(Find.BySrc(new Regex(frameName))).Exists;
            if (!a)
            {
                _document.Element(Find.BySrc(new Regex(frameName))).WaitUntilExists();
            }
        }

        public static void WaitUntilControlIsEnabled(string controlString)
        {
            int timeout = 0;
            bool a = IsControlEnabled(controlString);
            while (!a && timeout <= defaultTimeout)
            {
                System.Threading.Thread.Sleep(100);
                timeout += 100;
                a = IsControlEnabled(controlString);
            }
        }

        public static void WaitUntilValueExists(string controlString, String value)
        {
            int timeout = 0;
            bool a = DoesValueExist(controlString, value);
            while (!a && timeout <= defaultTimeout)
            {
                System.Threading.Thread.Sleep(100);
                timeout += 100;
                a = DoesValueExist(controlString, value);
            }
        }

        public static bool DoesValueExist(string controlString, String value)
        {
            _control = new WatinControlStringHandler(controlString);
            if (_control.WaitForComplete)
            {
                _ie.WaitForComplete();
            }

            WaitForAsyncPostBackToComplete();
            SetDocument();
            bool returnValue = false;
            switch (_control.ControlType)
            {
                case "select":
                    if (_document.SelectList(_control.WatinAttribute).Option(value).Exists)
                    {
                        returnValue = true;
                    }
                    else
                    {
                        // Give a guy a second chance
                        System.Threading.Thread.Sleep(500);

                        returnValue = _document.SelectList(_control.WatinAttribute).Option(value).Exists;
                    }
                    break;
                default:
                    throw new NotImplementedException(
                        "The control type has not been implemented in Stax.Controller.Watin.DoesValueExist");
            }
            _document = BrowserController.DomContainer;
            return returnValue;
        }

        public static void WaitUntilControlExists(string controlString)
        {
            int timeout = 0;
            bool a = DoesControlExist(controlString);
            while (!a && timeout <= defaultTimeout)
            {
                System.Threading.Thread.Sleep(100);
                timeout += 100;
                a = DoesControlExist(controlString);
            }
        }

        public static bool BrowserContainsText(string expected)
        {
            return _ie.ContainsText(expected);
        }


        #region AlternateUser helper methods

        private static SecureString SecurePassword(string password)
        {
            SecureString passwordAsSecureString = new SecureString();
            char[] PasswordArray = password.ToCharArray();
            foreach (char c in PasswordArray)
            {
                passwordAsSecureString.AppendChar(c);
            }
            return passwordAsSecureString;
        }
        #endregion
    }
}
