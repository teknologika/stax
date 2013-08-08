

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Xml;
using WatiN.Core;
using System.Text.RegularExpressions;
using Stax.ControlGrabber;

namespace Stax.ControlGrabber.ControlEye
{
    public partial class ControlEye : UserControl
    {
        public event EventHandler ActiveWindowSelected;

        private bool searching = false;
        private Point lastPoint = Point.Empty;
        private static IntPtr winPoint = IntPtr.Zero;
        public ControlSelection Selection { get; set; }
        public string Namespace = String.Empty;
        public string ClassName = String.Empty;


        public ControlEye()
        {
            InitializeComponent();
            Selection = new ControlSelection();
        }

        private void WindowFinder_MouseDown(object sender, MouseEventArgs e)
        {
            if (!searching)
                StartSearch();
        }

        private void WindowFinder_MouseMove(object sender, MouseEventArgs e)
        {
            // Grab the window from the screen location of the mouse.
            Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
            POINT windowPoint = POINT.FromPoint(newPoint);
            winPoint = NativeUtils.WindowFromPoint(windowPoint);

            // we have a valid window handle
            if (winPoint != IntPtr.Zero)
            {
                // give it another try, it might be a child window (disabled, hidden .. something else)
                // offset the point to be a client point of the active window
                if (NativeUtils.ScreenToClient(winPoint, ref windowPoint))
                {
                    // check if there is some hidden/disabled child window at this point
                    IntPtr childWindow = NativeUtils.ChildWindowFromPoint(winPoint, windowPoint);
                    if (childWindow != IntPtr.Zero)
                    { // great, we have the inner child
                        winPoint = childWindow;
                    }
                }
            }
        }

        private void WindowFinder_MouseUp(object sender, MouseEventArgs e)
        {
            EndSearch();
            IEDocument Ie = new IEDocument(winPoint);
            if (Ie.NativeDocument != null)
            {
                if (String.IsNullOrEmpty(Namespace))
                {
                    Namespace = "TheNameSpace";
                }
                Namespace = Utility.ConvertStringToCamelCase(Namespace);

                // If a class name has not been specified, use the page title.
               
                if (String.IsNullOrEmpty(ClassName))
                {
                    ClassName = Utility.TransformToAlphaNumeric(Ie.Title);
                    ClassName = Utility.ConvertStringToCamelCase(ClassName);
                }
                          
                List<Control> validControls = new List<Control>();
                List<Control> invalidControls = new List<Control>();

                ControlGenerator.GenerateControl(Ie, Selection, validControls, invalidControls);

                string controlCS = ControlGenerator.GenerateControlCS(validControls, invalidControls, ClassName, Namespace);
                string PhysicalCS = ControlGenerator.GeneratePhysicalCS(validControls, invalidControls, ClassName, Namespace);
                string DataCS = ControlGenerator.GenerateDataCS(validControls, invalidControls, ClassName, Namespace);
                string VerificationCS = ControlGenerator.GenerateVerificationCS(validControls, invalidControls, ClassName, Namespace);

                if (Selection.SaveInSolutionStructure)
                {
                    SaveFilesInSolution(Namespace, ClassName, controlCS, PhysicalCS, DataCS, VerificationCS);
                    MessageBox.Show("Generation is complete.");
                }
                else
                {
                    if (Selection.GenerateControls)
                    {
                        SaveCs(controlCS, ClassName + ".Controls.generated");
                    }

                    if (Selection.GeneratePhysicalAndData)
                    {
                        SaveCs(PhysicalCS, ClassName + ".Physical.generated");
                        SaveCs(DataCS, ClassName + ".Data.generated");
                        SaveCs(VerificationCS, ClassName + ".Verification.generated");
                    }
                }
         
            }
            else
            {
                MessageBox.Show("No Web Page is detected on the cursor location", "Error");
            }
        }

        private void SaveXml(string controlXml, string fileName)
        {
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".xml";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog.FileName.Length > 0)
            {

                try
                {
                    FileManager.SaveFile(controlXml, saveFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot save control xml at location " + saveFileDialog.FileName, "Error");
                }
            }
        }

        public void SaveCs(string controlCs, string fileName)
        {
            saveFileDialog.FileName = Utility.TransformToAlphaNumericOrDot(fileName);
            saveFileDialog.Filter = "C# files (*.cs)|*.cs|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".cs";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog.FileName.Length > 0)
            {

                try
                {
                    FileManager.SaveFile(controlCs, saveFileDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot save file at location " + saveFileDialog.FileName, "Error");
                }
            }
        }

        public void SaveFilesInSolution(string nameSpace, string className, string controlFileContents, string physicalFileContents, string dataFileContents, string verificationFileContents)
        {
            saveFolderDialog = new FolderBrowserDialog();
            saveFolderDialog.Description = "Select the solution folder.";
            if (saveFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFolderDialog.SelectedPath.Length > 0)
            {
                WriteFileToPath(controlFileContents, saveFolderDialog.SelectedPath + @"\" + nameSpace + @".Controls\" + ClassName + ".cs");
                WriteFileToPath(physicalFileContents, saveFolderDialog.SelectedPath + @"\" + nameSpace + @".Physical\" + ClassName + ".cs");
                WriteFileToPath(dataFileContents, saveFolderDialog.SelectedPath + @"\" + nameSpace + @".Data\" + ClassName + ".cs");
                WriteFileToPath(verificationFileContents, saveFolderDialog.SelectedPath + @"\" + nameSpace + @".Verification\" + ClassName + ".cs");
            }



        }

        public void WriteFileToPath(string fileContents, string fullfileNameIncludingPath)
        {
            try
            {
                FileManager.SaveFile(fileContents, fullfileNameIncludingPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot save file at location " + fullfileNameIncludingPath, "Error");
            }
        }


        public void StartSearch()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlEye));

            searching = true;
            Cursor.Current = new Cursor(GetType().Assembly.GetManifestResourceStream("Stax.ControlGrabber.ControlEye.Resources.Eye.cur"));
            Capture = true;

            this.MouseMove += new MouseEventHandler(WindowFinder_MouseMove);
            this.MouseUp += new MouseEventHandler(WindowFinder_MouseUp);
            this.Hide();
        }

        public void EndSearch()
        {
            this.MouseMove -= new MouseEventHandler(WindowFinder_MouseMove);
            this.MouseUp -= new MouseEventHandler(WindowFinder_MouseUp); 
            Capture = false;
            searching = false;
            Cursor.Current = Cursors.Default;

            if (ActiveWindowSelected != null)
            {
                ActiveWindowSelected(this, EventArgs.Empty);
            }
            this.Show();
        }

        public IntPtr IePtr
        {
            get
            { return winPoint; }
        }

        public event EventHandler GrabbingControl;

        protected virtual void OnGrabbingControl(ControlType controlType)
        {
            GrabbingControl(controlType, EventArgs.Empty);
        }

        

        




    }
}
