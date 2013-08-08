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

namespace ManualTestSolutionGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dlgSelectOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectWiqFile = new System.Windows.Forms.Button();
            this.txtWiqFile = new System.Windows.Forms.TextBox();
            this.rbSavedQueryFile = new System.Windows.Forms.RadioButton();
            this.cbTFSUserQuery = new System.Windows.Forms.ComboBox();
            this.rbTFSUserQuery = new System.Windows.Forms.RadioButton();
            this.cbTFSServerQuery = new System.Windows.Forms.ComboBox();
            this.rbTFSQuery = new System.Windows.Forms.RadioButton();
            this.rbQueryDefault = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTargetDirectory = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenWiqFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(340, 295);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectWiqFile);
            this.groupBox1.Controls.Add(this.txtWiqFile);
            this.groupBox1.Controls.Add(this.rbSavedQueryFile);
            this.groupBox1.Controls.Add(this.cbTFSUserQuery);
            this.groupBox1.Controls.Add(this.rbTFSUserQuery);
            this.groupBox1.Controls.Add(this.cbTFSServerQuery);
            this.groupBox1.Controls.Add(this.rbTFSQuery);
            this.groupBox1.Controls.Add(this.rbQueryDefault);
            this.groupBox1.Location = new System.Drawing.Point(13, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 198);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please select the query to use";
            // 
            // btnSelectWiqFile
            // 
            this.btnSelectWiqFile.Enabled = false;
            this.btnSelectWiqFile.Location = new System.Drawing.Point(327, 62);
            this.btnSelectWiqFile.Name = "btnSelectWiqFile";
            this.btnSelectWiqFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectWiqFile.TabIndex = 7;
            this.btnSelectWiqFile.Text = "Browse";
            this.btnSelectWiqFile.UseVisualStyleBackColor = true;
            this.btnSelectWiqFile.Click += new System.EventHandler(this.btnSelectWiqFile_Click);
            // 
            // txtWiqFile
            // 
            this.txtWiqFile.Enabled = false;
            this.txtWiqFile.Location = new System.Drawing.Point(25, 64);
            this.txtWiqFile.Name = "txtWiqFile";
            this.txtWiqFile.Size = new System.Drawing.Size(296, 20);
            this.txtWiqFile.TabIndex = 6;
            // 
            // rbSavedQueryFile
            // 
            this.rbSavedQueryFile.AutoSize = true;
            this.rbSavedQueryFile.Location = new System.Drawing.Point(7, 44);
            this.rbSavedQueryFile.Name = "rbSavedQueryFile";
            this.rbSavedQueryFile.Size = new System.Drawing.Size(106, 17);
            this.rbSavedQueryFile.TabIndex = 5;
            this.rbSavedQueryFile.TabStop = true;
            this.rbSavedQueryFile.Text = "Saved Query File";
            this.rbSavedQueryFile.UseVisualStyleBackColor = true;
            this.rbSavedQueryFile.CheckedChanged += new System.EventHandler(this.rbSavedQueryFile_CheckedChanged);
            // 
            // cbTFSUserQuery
            // 
            this.cbTFSUserQuery.Enabled = false;
            this.cbTFSUserQuery.FormattingEnabled = true;
            this.cbTFSUserQuery.Location = new System.Drawing.Point(25, 162);
            this.cbTFSUserQuery.Name = "cbTFSUserQuery";
            this.cbTFSUserQuery.Size = new System.Drawing.Size(377, 21);
            this.cbTFSUserQuery.TabIndex = 4;
            this.cbTFSUserQuery.Text = "< Please select a query >";
            this.cbTFSUserQuery.SelectedIndexChanged += new System.EventHandler(this.cbTFSUserQuery_SelectedIndexChanged);
            // 
            // rbTFSUserQuery
            // 
            this.rbTFSUserQuery.AutoSize = true;
            this.rbTFSUserQuery.Location = new System.Drawing.Point(6, 138);
            this.rbTFSUserQuery.Name = "rbTFSUserQuery";
            this.rbTFSUserQuery.Size = new System.Drawing.Size(204, 17);
            this.rbTFSUserQuery.TabIndex = 3;
            this.rbTFSUserQuery.TabStop = true;
            this.rbTFSUserQuery.Text = "Team Foundation Server - My Queries";
            this.rbTFSUserQuery.UseVisualStyleBackColor = true;
            this.rbTFSUserQuery.CheckedChanged += new System.EventHandler(this.rbTFSUserQuery_CheckedChanged);
            // 
            // cbTFSServerQuery
            // 
            this.cbTFSServerQuery.Enabled = false;
            this.cbTFSServerQuery.FormattingEnabled = true;
            this.cbTFSServerQuery.Location = new System.Drawing.Point(25, 113);
            this.cbTFSServerQuery.Name = "cbTFSServerQuery";
            this.cbTFSServerQuery.Size = new System.Drawing.Size(377, 21);
            this.cbTFSServerQuery.TabIndex = 2;
            this.cbTFSServerQuery.Text = "< Please select a query >";
            this.cbTFSServerQuery.SelectedIndexChanged += new System.EventHandler(this.cbTFSQuery_SelectedIndexChanged);
            // 
            // rbTFSQuery
            // 
            this.rbTFSQuery.AutoSize = true;
            this.rbTFSQuery.Location = new System.Drawing.Point(7, 90);
            this.rbTFSQuery.Name = "rbTFSQuery";
            this.rbTFSQuery.Size = new System.Drawing.Size(217, 17);
            this.rbTFSQuery.TabIndex = 1;
            this.rbTFSQuery.TabStop = true;
            this.rbTFSQuery.Text = "Team Foundation Server - Team Queries";
            this.rbTFSQuery.UseVisualStyleBackColor = true;
            this.rbTFSQuery.CheckedChanged += new System.EventHandler(this.rbTFSQuery_CheckedChanged);
            // 
            // rbQueryDefault
            // 
            this.rbQueryDefault.AutoSize = true;
            this.rbQueryDefault.Checked = true;
            this.rbQueryDefault.Location = new System.Drawing.Point(7, 20);
            this.rbQueryDefault.Name = "rbQueryDefault";
            this.rbQueryDefault.Size = new System.Drawing.Size(88, 17);
            this.rbQueryDefault.TabIndex = 0;
            this.rbQueryDefault.TabStop = true;
            this.rbQueryDefault.Text = "Default query";
            this.rbQueryDefault.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(444, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(50, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTargetDirectory);
            this.groupBox2.Controls.Add(this.btnSelectFolder);
            this.groupBox2.Location = new System.Drawing.Point(13, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 44);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output directory";
            // 
            // txtTargetDirectory
            // 
            this.txtTargetDirectory.Location = new System.Drawing.Point(25, 17);
            this.txtTargetDirectory.Name = "txtTargetDirectory";
            this.txtTargetDirectory.Size = new System.Drawing.Size(296, 20);
            this.txtTargetDirectory.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(327, 17);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Browse";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.selectFolToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.toolsToolStripMenuItem.Text = "&Generate";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.customizeToolStripMenuItem.Text = "Generate Solution ";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // selectFolToolStripMenuItem
            // 
            this.selectFolToolStripMenuItem.Name = "selectFolToolStripMenuItem";
            this.selectFolToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.selectFolToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.selectFolToolStripMenuItem.Text = "Select Output Directory";
            this.selectFolToolStripMenuItem.Click += new System.EventHandler(this.selectFolToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.contentsToolStripMenuItem.Text = "&Open";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem2.Text = "&About...";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // dlgOpenWiqFile
            // 
            this.dlgOpenWiqFile.DefaultExt = "*.wiq";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(444, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Manual Test Case Generator";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
       
        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectOutputFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTFSServerQuery;
        private System.Windows.Forms.RadioButton rbTFSQuery;
        private System.Windows.Forms.RadioButton rbQueryDefault;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTargetDirectory;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.RadioButton rbTFSUserQuery;
        private System.Windows.Forms.ComboBox cbTFSUserQuery;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectFolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog dlgOpenWiqFile;
        private System.Windows.Forms.Button btnSelectWiqFile;
        private System.Windows.Forms.TextBox txtWiqFile;
        private System.Windows.Forms.RadioButton rbSavedQueryFile;
    }
}

