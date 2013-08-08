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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

namespace Stax.ControlGrabber.ControlEye
{
    public class NativeUtils
    {
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT Point);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);
        public delegate bool IsWow64ProcessHandler(IntPtr processHandle, out bool is64Process);

        public delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);

        public class WINDOWCMD
        {
            public const int GW_HWNDFIRST = 0;
            public const int GW_HWNDLAST = 1;
            public const int GW_HWNDNEXT = 2;
            public const int GW_HWNDPREV = 3;
            public const int GW_OWNER = 4;
            public const int GW_CHILD = 5;
        };

        public class PROCESSACCESS
        {
            public const int PROCESS_QUERY_INFORMATION = 0x0400;
        }

        public class WM
        {
            public const int WM_CREATE = 0x0001;
        }

        public class RDW
        {
            public const uint RDW_INVALIDATE = 0x0001;
            public const uint RDW_INTERNALPAINT = 0x0002;
            public const uint RDW_ERASE = 0x0004;

            public const uint RDW_VALIDATE = 0x0008;
            public const uint RDW_NOINTERNALPAINT = 0x0010;
            public const uint RDW_NOERASE = 0x0020;

            public const uint RDW_NOCHILDREN = 0x0040;
            public const uint RDW_ALLCHILDREN = 0x0080;

            public const uint RDW_UPDATENOW = 0x0100;
            public const uint RDW_ERASENOW = 0x0200;

            public const uint RDW_FRAME = 0x0400;
            public const uint RDW_NOFRAME = 0x0800;
        }

        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hwnd, ref RECT rc);

        [DllImport("user32.dll")]
        public static extern bool EnumThreadWindows(int threadId, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, out IntPtr processID);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int width, int height, bool repaint);
        public static Point NativeScreenToClient(IntPtr window, Point originalPoint)
        {
            POINT point1 = new POINT(originalPoint.X, originalPoint.Y);
            if (NativeUtils.ScreenToClient(window, ref point1))
            {
                return new Point(point1.x, point1.y);
            }
            return Point.Empty;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lpRect, IntPtr hrgnUpdate, uint flags);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern IntPtr GetClientRect(IntPtr hwnd, ref RECT rc);

        //		.Net 2.0 Only :(
        //		[DllImport("mscoree.dll")]
        //		public static extern IntPtr GetVersionFromProcess (IntPtr hProcess, StringBuilder version, long bufferSize, ref long written);
        //		public static string GetVersionFromProcess(IntPtr process)
        //		{
        //			
        //		}

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public static string GetWindowText(IntPtr hwnd)
        {
            int bufLen = GetWindowTextLength(hwnd) + 1;

            StringBuilder buffer = new StringBuilder(bufLen);
            GetWindowText(hwnd, buffer, bufLen);

            return buffer.ToString();
        }
        public static string GetClassName(IntPtr hwnd)
        {
            StringBuilder buffer = new StringBuilder(256);
            GetClassName(hwnd, buffer, buffer.Capacity);
            return buffer.ToString();
        }
        public static bool IsTargetInDifferentProcess(IntPtr targetWindowHandle)
        {
            IntPtr targetProcessId;

            IntPtr targetThreadId = GetWindowThreadProcessId(targetWindowHandle, out targetProcessId);

            if (targetProcessId == IntPtr.Zero)
            {
                return true;
            }

            IntPtr thisProcessId = new IntPtr(Process.GetCurrentProcess().Id);

            return thisProcessId != targetProcessId;
        }

        public static bool IsCurrentProcessx64
        {
            get
            {
                return Isx64Process(new IntPtr(Process.GetCurrentProcess().Id));
            }
        }


       // private static IsWow64ProcessHandler isWow64Process;
       // private static bool isWow64ProcessChecked = false;

        public static bool Isx64Process(IntPtr processId)
        {
#if NET2
			if (!isWow64ProcessChecked)
			{
				IntPtr kernel32Module = GetModuleHandle("kernel32");
				IntPtr isWow64ProcessPtr = GetProcAddress(kernel32Module, "IsWow64Process");

				if (isWow64ProcessPtr != IntPtr.Zero)
				{
					isWow64Process = (IsWow64ProcessHandler)Marshal.GetDelegateForFunctionPointer(isWow64ProcessPtr, typeof(IsWow64ProcessHandler));
				}
				isWow64ProcessChecked = true;
			}

			if (isWow64Process != null)
			{
				bool is64Process;

				int procId = processId.ToInt32();
				IntPtr processHandle = OpenProcess(PROCESSACCESS.PROCESS_QUERY_INFORMATION, false, procId);

				try
				{
					if (isWow64Process(processHandle, out is64Process))
					{
						return !is64Process;
					}
					else
					{
						int lastError = Marshal.GetLastWin32Error();
						Trace.WriteLine("LastError:" + lastError);
					}
				}
				finally
				{
					CloseHandle(processHandle);
				}
			}
			return false;
#else
            return false;
#endif
        }

        public static IntPtr GetProcessForWindow(IntPtr windowHandle)
        {
            IntPtr processId;
            IntPtr threadId = NativeUtils.GetWindowThreadProcessId(windowHandle, out processId);
            return processId;
        }

        public static void GetWindowThreadAndProcess(IntPtr windowHandle, out IntPtr threadId, out IntPtr processId)
        {
            threadId = NativeUtils.GetWindowThreadProcessId(windowHandle, out processId);
        }
    }
}