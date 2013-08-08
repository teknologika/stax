

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualStudio.TeamFoundation;
using System.Configuration;


namespace VS2010TestResultPublisher
{
    public partial class MainPublisherForm : Form
    {
        PublishResults resultsForm;
        ProjectSettings _currentProjectContext;
        IResultsWriter resultWriter = null;
        public MainPublisherForm(string solutionFile, ProjectSettings currentTFSProjectContext)
        {
            _currentProjectContext = currentTFSProjectContext;
                   
            InitializeComponent();

            if (!string.IsNullOrEmpty(solutionFile))
            {
                FileInfo fileinfo = new FileInfo(solutionFile);
                DirectoryInfo TestResultsDir = new DirectoryInfo(fileinfo.DirectoryName + @"\TestResults");
                if (TestResultsDir.Exists)
                {
                    txtResultsFolder.Text = TestResultsDir.FullName;
                    UpdateTrxList();
                }   
            }

            ConfigParser.LoadConfiguration();
           // this.BringToFront();

        }

        public MainPublisherForm(string solutionFile)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(solutionFile))
            {
                FileInfo fileinfo = new FileInfo(solutionFile);
                DirectoryInfo TestResultsDir = new DirectoryInfo(fileinfo.DirectoryName + @"\TestResults");
                if (TestResultsDir.Exists)
                {
                    txtResultsFolder.Text = TestResultsDir.FullName;
                    UpdateTrxList();
                }
            }
            ConfigParser.LoadConfiguration();
            // this.BringToFront();

        }


        private void txtResultsFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateTrxList();
        }

        private void UpdateTrxList()
        {
            //Get a list of trx files from the specified folder
            DirectoryInfo di = new DirectoryInfo(txtResultsFolder.Text);
            chkLstTrxFiles.Items.Clear();
            //Add each trx file to the checkedlistbox
            List<string> items = new List<string>();
            foreach (FileInfo fi in di.GetFiles("*.trx"))
            {
                items.Add(fi.Name);
            }
            items.Reverse();
            chkLstTrxFiles.Items.AddRange(items.ToArray());
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Display the folder browse dialog when the browse button is clicked
            FolderBrowserDialog browseForTrxFolder = new FolderBrowserDialog();
            browseForTrxFolder.Description = "Browse test results folder";
            DialogResult result = browseForTrxFolder.ShowDialog(this);

            //Update the test results path textbox with the selected folder path
            if (result == DialogResult.OK)
            {
                txtResultsFolder.Text = browseForTrxFolder.SelectedPath;
            }

        }

        private void resutlsForm_btnOk_click(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                this.Enabled = true;
                this.BringToFront();
            }
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            Exception errorCatch = null;
            try
            {
                TestResultCollection allTestResults = new TestResultCollection();
                TrxFileParser trxparser = new TrxFileParser();
                this.Enabled = false;

                if (chkLstTrxFiles.CheckedItems.Count > 0)
                {
                    Settings _settings = new Settings();
                    if (ddlProvider.Text.ToLower() == "mercury")
                    {
                        //resultWriter = MercuryResultWriter.Instance();
                    }
                    else
                    {
                       resultWriter = TFS2010ResultWriter.Instance(_currentProjectContext, cbxCreateTestRun.Checked);
                    }
                    if (resultWriter.Cancelled)
                    {
                        ErrorReportingForm ef = new ErrorReportingForm();
                        ef.txtErrorDetails.Text = "User cancelled";
                        ef.Show();
                    }
                    else
                    {
                        //Show the output form
                        resultsForm = new PublishResults();
                        resultsForm.txtOutput.Text = "";
                        resultsForm.btnOk.Click += new EventHandler(resutlsForm_btnOk_click);
                        resultsForm.Show();
                        //Publish each of the selected trx files
                        resultsForm.SetOutputText("Processing results file...Start");
                        for (int i = 0; i < chkLstTrxFiles.CheckedItems.Count; i++)
                        {
                            allTestResults.Append(trxparser.processTrxFile(txtResultsFolder.Text + @"\" + chkLstTrxFiles.CheckedItems[i].ToString(), publishFailures.Checked, publishErrorInfo.Checked));
                        }
                        resultsForm.SetOutputText("Processing results file...Done.");

                        foreach (TestResult item in allTestResults)
                        {
                            resultsForm.AddResult(resultWriter.UpdateTestResult(item, this.publishFailures.Checked, this.publishInconclusive.Checked, this.publishErrorInfo.Checked));
                        }
                        resultsForm.btnOk.Enabled = true;
                    }
                    this.btnOk.Enabled = false;
                    this.btnCancel.Text = "Close";
                }
            }
            catch (Exception ex)
            {
                errorCatch = ex;
                ErrorReportingForm ef = new ErrorReportingForm();
                ef.txtErrorDetails.Text = errorCatch.Message + errorCatch.StackTrace;
                ef.Show();
                resultsForm.Close();
                this.Close();
            }
            finally
            {
                if (resultWriter != null)
                {
                    resultWriter.Disconnect();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void chkLstTrxFiles_MouseLeave(object sender, EventArgs e)
        {
            if (chkLstTrxFiles.CheckedItems.Count > 0)
            {
                this.btnOk.Enabled = true;
            }
            else
            {
                this.btnOk.Enabled = false;
            }
        }

        private void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvider.Text.ToLower() == "tfs")
            {
                cbxCreateTestRun.Enabled = true;
            }
            else
            {
                cbxCreateTestRun.Enabled = false;
            }
        }
    }
}
