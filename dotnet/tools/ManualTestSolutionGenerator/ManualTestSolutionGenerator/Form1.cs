/*Copyright (c) 2010 Bruce McLeod
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation
and/or other materials provided with the distribution.

Neither the name of Stax nor the names of its contributors may be used to endorse or promote products derived from this
software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY ANDFITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Stax.TFS2008Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Configuration;

namespace ManualTestSolutionGenerator
{
    public partial class Form1 : Form
    {
        private string outputFolder;
        private string searchQuery;
        public Form1()
        {
            InitializeComponent();
            searchQuery = null;

            // Load the default directiory
            outputFolder = ConfigurationManager.AppSettings["OutputFolder"].ToString();
            txtTargetDirectory.Text = outputFolder;

            this.SendToBack();
           
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (rbSavedQueryFile.Checked && string.IsNullOrEmpty(txtWiqFile.Text))
            {
                btnGenerate.Enabled = false;
            }
            else
            {
                generate();
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            selectFolder();
        }

        private void selectFolder()
        {
            // Select the directory
            dlgSelectOutputFolder.ShowDialog();
            outputFolder = dlgSelectOutputFolder.SelectedPath;
                   
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["OutputFolder"].Value = outputFolder;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            txtTargetDirectory.Text = ConfigurationManager.AppSettings["OutputFolder"].ToString();
            
        }

        private void rbTFSQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTFSQuery.Checked)
            {

                // Give the user some "we are working" feedback
                btnGenerate.Enabled = false;
                Cursor = Cursors.WaitCursor;

                cbTFSServerQuery.Enabled = true;

                cbTFSServerQuery.Items.Clear();
                StoredQueryCollection queryCollection = TfsManager.GetStoredQueries(ConfigurationManager.AppSettings["TFSProject"].ToString());

                foreach (StoredQuery tfsQuery in queryCollection)
                {
                    if (tfsQuery.QueryText.Contains(ConfigurationManager.AppSettings["WorkItemType"].ToString()))
                    {
                        // only add the private queries
                        if (tfsQuery.QueryScope == QueryScope.Public)
                        {
                            cbTFSServerQuery.Items.Add(tfsQuery.Name);
                        }
                    }
                }


                // Reset back to normal
                Cursor = Cursors.Default;
                btnGenerate.Enabled = true;
            }
            else
            {
                cbTFSServerQuery.Enabled = false;
            }
        }

        private void rbTFSUserQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTFSUserQuery.Checked)
            {

                // Give the user some "we are working" feedback
                btnGenerate.Enabled = false;
                Cursor = Cursors.WaitCursor;

                cbTFSUserQuery.Enabled = true;

                cbTFSUserQuery.Items.Clear();
                StoredQueryCollection queryCollection = TfsManager.GetStoredQueries(ConfigurationManager.AppSettings["TFSProject"].ToString());

                foreach (StoredQuery tfsQuery in queryCollection)
                {
                    if (tfsQuery.QueryText.Contains(ConfigurationManager.AppSettings["WorkItemType"].ToString()))
                    {
                        // only add the private queries
                        if (tfsQuery.QueryScope == QueryScope.Private)
                        {

                            cbTFSUserQuery.Items.Add(tfsQuery.Name);
                        }
                    }
                }


                // Reset back to normal
                Cursor = Cursors.Default;
                btnGenerate.Enabled = true;
            }
            else
            {
                cbTFSUserQuery.Enabled = false;
            }
        }
        
        private void rbSavedQueryFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSavedQueryFile.Checked)
            {
                txtWiqFile.Enabled = true;
                btnSelectWiqFile.Enabled = true;
                if (string.IsNullOrEmpty(txtWiqFile.Text))
                {
                    btnGenerate.Enabled = false;
                }
            }
            else
            {
                txtWiqFile.Enabled = false;
                btnSelectWiqFile.Enabled = false;
            }
        }
        
        private void cbTFSQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbTFSQuery.Checked)
            {
                cbTFSServerQuery.Enabled = true;
            }
            else
            {
                 cbTFSServerQuery.Enabled = false;
            }


            StoredQueryCollection queryCollection2 = TfsManager.GetStoredQueries(ConfigurationManager.AppSettings["TFSProject"].ToString());
            foreach (StoredQuery tfsQuery in queryCollection2)
            {
                if (tfsQuery.Name.Equals(cbTFSServerQuery.Text))
                {
                    searchQuery = tfsQuery.QueryText;
                }
            }
        }

        void cbTFSUserQuery_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            StoredQueryCollection queryCollection2 = TfsManager.GetStoredQueries(ConfigurationManager.AppSettings["TFSProject"].ToString());
            foreach (StoredQuery tfsQuery in queryCollection2)
            {
                if (tfsQuery.Name.Equals(cbTFSUserQuery.Text))
                {
                    searchQuery = tfsQuery.QueryText;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            TFSWriter writer = new TFSWriter();
            writer.GenerateProject(worker, searchQuery, outputFolder);          
        }

        void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Reset back to normal
            Cursor = Cursors.Default;
            btnGenerate.Enabled = true;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            this.SendToBack();
            aboutBox.BringToFront();
            aboutBox.Visible = true;
            
          
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void generate()
        {
            // If the query selected does not contain the correct work item type then don't generate
            string workItemType = ConfigurationManager.AppSettings["WorkItemType"].ToString();
            if(!string.IsNullOrEmpty(searchQuery))
            {
                if (!searchQuery.Contains(workItemType))
                {

                    System.Windows.Forms.MessageBox.Show
                        ("Error: Unable to generate solution, the query does not contain the correct work item type: '" + workItemType + "'.",
                         "Manual Test Case Generator",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }
            
            // Give the user some "we are working" feedback
            btnGenerate.Enabled = false;
            Cursor = Cursors.WaitCursor;

            // if the user hasn't selected the output folder yet, make them.
            if (string.IsNullOrEmpty(outputFolder))
            {
                selectFolder();
            }

            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;

            TFSWriterParameters paramaters = new TFSWriterParameters(searchQuery, outputFolder);
            backgroundWorker1.RunWorkerAsync(paramaters);
        }

        private void selectFolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFolder();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string website = @"http://www.teknologika.com/";
            System.Diagnostics.Process.Start("iexplore.exe", website);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWiqFileName();
        }

        private void updateDefaultQuery()
        {
            string defaultQuery = TFSWriter.OpenSavedQuery( GetWiqFileName());
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DefaultQuery"].Value = searchQuery;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

       
        private string GetWiqFileName()
        {
            dlgOpenWiqFile.Filter = ("Work Item Query (*.wiq)|*.wiq|Any file (*.*)|*.*");
            dlgOpenWiqFile.DefaultExt = "*.wiq";
            dlgOpenWiqFile.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            dlgOpenWiqFile.ShowDialog();
            return dlgOpenWiqFile.FileName;
        }

        private void btnSelectWiqFile_Click(object sender, EventArgs e)
        {
            string fileName = GetWiqFileName();
            searchQuery = TFSWriter.OpenSavedQuery( fileName);
            txtWiqFile.Text = fileName;
            btnGenerate.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}
