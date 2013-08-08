namespace VS2010TestResultPublisher
{
    partial class MainPublisherForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtResultsFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkLstTrxFiles = new System.Windows.Forms.CheckedListBox();
            this.publishFailures = new System.Windows.Forms.CheckBox();
            this.publishErrorInfo = new System.Windows.Forms.CheckBox();
            this.publishInconclusive = new System.Windows.Forms.CheckBox();
            this.ddlProvider = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxCreateTestRun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the test run results you would like to publish";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Test results folder:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(8, 424);
            this.label4.MaximumSize = new System.Drawing.Size(0, 2);
            this.label4.MinimumSize = new System.Drawing.Size(420, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 2);
            this.label4.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(308, 490);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 29);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtResultsFolder
            // 
            this.txtResultsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResultsFolder.Location = new System.Drawing.Point(20, 375);
            this.txtResultsFolder.Name = "txtResultsFolder";
            this.txtResultsFolder.ReadOnly = true;
            this.txtResultsFolder.Size = new System.Drawing.Size(310, 20);
            this.txtResultsFolder.TabIndex = 9;
            this.txtResultsFolder.TextChanged += new System.EventHandler(this.txtResultsFolder_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.Location = new System.Drawing.Point(336, 370);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(158, 29);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkLstTrxFiles
            // 
            this.chkLstTrxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLstTrxFiles.CheckOnClick = true;
            this.chkLstTrxFiles.FormattingEnabled = true;
            this.chkLstTrxFiles.Location = new System.Drawing.Point(14, 34);
            this.chkLstTrxFiles.Name = "chkLstTrxFiles";
            this.chkLstTrxFiles.Size = new System.Drawing.Size(474, 289);
            this.chkLstTrxFiles.TabIndex = 12;
            this.chkLstTrxFiles.MouseLeave += new System.EventHandler(this.chkLstTrxFiles_MouseLeave);
            // 
            // publishFailures
            // 
            this.publishFailures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.publishFailures.AutoSize = true;
            this.publishFailures.Checked = true;
            this.publishFailures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.publishFailures.Location = new System.Drawing.Point(20, 401);
            this.publishFailures.Name = "publishFailures";
            this.publishFailures.Size = new System.Drawing.Size(99, 17);
            this.publishFailures.TabIndex = 13;
            this.publishFailures.Text = "Publish Failures";
            this.publishFailures.UseVisualStyleBackColor = true;
            // 
            // publishErrorInfo
            // 
            this.publishErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.publishErrorInfo.AutoSize = true;
            this.publishErrorInfo.Enabled = false;
            this.publishErrorInfo.Location = new System.Drawing.Point(254, 401);
            this.publishErrorInfo.Name = "publishErrorInfo";
            this.publishErrorInfo.Size = new System.Drawing.Size(140, 17);
            this.publishErrorInfo.TabIndex = 16;
            this.publishErrorInfo.Text = "Publish Error Information";
            this.publishErrorInfo.UseVisualStyleBackColor = true;
            // 
            // publishInconclusive
            // 
            this.publishInconclusive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.publishInconclusive.AutoSize = true;
            this.publishInconclusive.Enabled = false;
            this.publishInconclusive.Location = new System.Drawing.Point(125, 401);
            this.publishInconclusive.Name = "publishInconclusive";
            this.publishInconclusive.Size = new System.Drawing.Size(123, 17);
            this.publishInconclusive.TabIndex = 20;
            this.publishInconclusive.Text = "Publish Inconclusive";
            this.publishInconclusive.UseVisualStyleBackColor = true;
            // 
            // ddlProvider
            // 
            this.ddlProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlProvider.FormattingEnabled = true;
            this.ddlProvider.Items.AddRange(new object[] {
            "TFS",
            "Mercury"});
            this.ddlProvider.Location = new System.Drawing.Point(70, 442);
            this.ddlProvider.Name = "ddlProvider";
            this.ddlProvider.Size = new System.Drawing.Size(260, 21);
            this.ddlProvider.TabIndex = 21;
            this.ddlProvider.SelectedIndexChanged += new System.EventHandler(this.ddlProvider_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Publish to:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(8, 479);
            this.label5.MaximumSize = new System.Drawing.Size(0, 2);
            this.label5.MinimumSize = new System.Drawing.Size(420, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(420, 2);
            this.label5.TabIndex = 23;
            // 
            // cbxCreateTestRun
            // 
            this.cbxCreateTestRun.AutoSize = true;
            this.cbxCreateTestRun.Enabled = false;
            this.cbxCreateTestRun.Location = new System.Drawing.Point(336, 444);
            this.cbxCreateTestRun.Name = "cbxCreateTestRun";
            this.cbxCreateTestRun.Size = new System.Drawing.Size(110, 17);
            this.cbxCreateTestRun.TabIndex = 24;
            this.cbxCreateTestRun.Text = "Reset Test Cases";
            this.cbxCreateTestRun.UseVisualStyleBackColor = true;
            // 
            // MainPublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(506, 538);
            this.Controls.Add(this.cbxCreateTestRun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ddlProvider);
            this.Controls.Add(this.publishInconclusive);
            this.Controls.Add(this.publishErrorInfo);
            this.Controls.Add(this.publishFailures);
            this.Controls.Add(this.chkLstTrxFiles);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtResultsFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(470, 499);
            this.Name = "MainPublisherForm";
            this.ShowIcon = false;
            this.Text = "Publish Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtResultsFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckedListBox chkLstTrxFiles;
        private System.Windows.Forms.CheckBox publishFailures;
        private System.Windows.Forms.CheckBox publishErrorInfo;
        private System.Windows.Forms.CheckBox publishInconclusive;
        private System.Windows.Forms.ComboBox ddlProvider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxCreateTestRun;
    }
}