namespace Stax.ControlGrabber
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            Stax.ControlGrabber.ControlSelection controlSelection2 = new Stax.ControlGrabber.ControlSelection();
            this.grbControlType = new System.Windows.Forms.GroupBox();
            this.chkTable = new System.Windows.Forms.CheckBox();
            this.chkLink = new System.Windows.Forms.CheckBox();
            this.chkLabel = new System.Windows.Forms.CheckBox();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.chkTextField = new System.Windows.Forms.CheckBox();
            this.chkSpan = new System.Windows.Forms.CheckBox();
            this.chkSelectList = new System.Windows.Forms.CheckBox();
            this.chkRadioButton = new System.Windows.Forms.CheckBox();
            this.chkDiv = new System.Windows.Forms.CheckBox();
            this.chkCheckBox = new System.Windows.Forms.CheckBox();
            this.chkButton = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkGeneratePhysicalAndData = new System.Windows.Forms.CheckBox();
            this.chkGenerateControls = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConvertOR = new System.Windows.Forms.Button();
            this.txtObjectRepository = new System.Windows.Forms.TextBox();
            this.BtnSelectOR = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chkSaveInClassFolders = new System.Windows.Forms.CheckBox();
            this.controlEye1 = new Stax.ControlGrabber.ControlEye.ControlEye();
            this.grbControlType.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbControlType
            // 
            this.grbControlType.Controls.Add(this.chkTable);
            this.grbControlType.Controls.Add(this.chkLink);
            this.grbControlType.Controls.Add(this.chkLabel);
            this.grbControlType.Controls.Add(this.chkImage);
            this.grbControlType.Controls.Add(this.chkTextField);
            this.grbControlType.Controls.Add(this.chkSpan);
            this.grbControlType.Controls.Add(this.chkSelectList);
            this.grbControlType.Controls.Add(this.chkRadioButton);
            this.grbControlType.Controls.Add(this.chkDiv);
            this.grbControlType.Controls.Add(this.chkCheckBox);
            this.grbControlType.Controls.Add(this.chkButton);
            this.grbControlType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbControlType.Location = new System.Drawing.Point(12, 210);
            this.grbControlType.Name = "grbControlType";
            this.grbControlType.Size = new System.Drawing.Size(254, 167);
            this.grbControlType.TabIndex = 1;
            this.grbControlType.TabStop = false;
            this.grbControlType.Text = "Select Control Type";
            // 
            // chkTable
            // 
            this.chkTable.AutoSize = true;
            this.chkTable.Checked = true;
            this.chkTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTable.Location = new System.Drawing.Point(146, 65);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(53, 17);
            this.chkTable.TabIndex = 10;
            this.chkTable.Text = "Table";
            this.chkTable.UseVisualStyleBackColor = true;
            // 
            // chkLink
            // 
            this.chkLink.AutoSize = true;
            this.chkLink.Checked = true;
            this.chkLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLink.Location = new System.Drawing.Point(7, 135);
            this.chkLink.Name = "chkLink";
            this.chkLink.Size = new System.Drawing.Size(46, 17);
            this.chkLink.TabIndex = 9;
            this.chkLink.Text = "Link";
            this.chkLink.UseVisualStyleBackColor = true;
            this.chkLink.CheckedChanged += new System.EventHandler(this.chkLink_CheckedChanged);
            // 
            // chkLabel
            // 
            this.chkLabel.AutoSize = true;
            this.chkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLabel.Location = new System.Drawing.Point(7, 112);
            this.chkLabel.Name = "chkLabel";
            this.chkLabel.Size = new System.Drawing.Size(52, 17);
            this.chkLabel.TabIndex = 8;
            this.chkLabel.Text = "Label";
            this.chkLabel.UseVisualStyleBackColor = true;
            this.chkLabel.CheckedChanged += new System.EventHandler(this.chkLabel_CheckedChanged);
            // 
            // chkImage
            // 
            this.chkImage.AutoSize = true;
            this.chkImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImage.Location = new System.Drawing.Point(7, 88);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(55, 17);
            this.chkImage.TabIndex = 7;
            this.chkImage.Text = "Image";
            this.chkImage.UseVisualStyleBackColor = true;
            this.chkImage.CheckedChanged += new System.EventHandler(this.chkImage_CheckedChanged);
            // 
            // chkTextField
            // 
            this.chkTextField.AutoSize = true;
            this.chkTextField.Checked = true;
            this.chkTextField.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTextField.Location = new System.Drawing.Point(146, 88);
            this.chkTextField.Name = "chkTextField";
            this.chkTextField.Size = new System.Drawing.Size(72, 17);
            this.chkTextField.TabIndex = 6;
            this.chkTextField.Text = "Text Field";
            this.chkTextField.UseVisualStyleBackColor = true;
            this.chkTextField.CheckedChanged += new System.EventHandler(this.chkTextField_CheckedChanged);
            // 
            // chkSpan
            // 
            this.chkSpan.AutoSize = true;
            this.chkSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpan.Location = new System.Drawing.Point(146, 42);
            this.chkSpan.Name = "chkSpan";
            this.chkSpan.Size = new System.Drawing.Size(51, 17);
            this.chkSpan.TabIndex = 5;
            this.chkSpan.Text = "Span";
            this.chkSpan.UseVisualStyleBackColor = true;
            this.chkSpan.CheckedChanged += new System.EventHandler(this.chkSpan_CheckedChanged);
            // 
            // chkSelectList
            // 
            this.chkSelectList.AutoSize = true;
            this.chkSelectList.Checked = true;
            this.chkSelectList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectList.Location = new System.Drawing.Point(146, 19);
            this.chkSelectList.Name = "chkSelectList";
            this.chkSelectList.Size = new System.Drawing.Size(75, 17);
            this.chkSelectList.TabIndex = 4;
            this.chkSelectList.Text = "Select List";
            this.chkSelectList.UseVisualStyleBackColor = true;
            this.chkSelectList.CheckedChanged += new System.EventHandler(this.chkSelectList_CheckedChanged);
            // 
            // chkRadioButton
            // 
            this.chkRadioButton.AutoSize = true;
            this.chkRadioButton.Checked = true;
            this.chkRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRadioButton.Location = new System.Drawing.Point(146, 112);
            this.chkRadioButton.Name = "chkRadioButton";
            this.chkRadioButton.Size = new System.Drawing.Size(88, 17);
            this.chkRadioButton.TabIndex = 3;
            this.chkRadioButton.Text = "Radio Button";
            this.chkRadioButton.UseVisualStyleBackColor = true;
            this.chkRadioButton.CheckedChanged += new System.EventHandler(this.chkRadioButton_CheckedChanged);
            // 
            // chkDiv
            // 
            this.chkDiv.AutoSize = true;
            this.chkDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDiv.Location = new System.Drawing.Point(7, 65);
            this.chkDiv.Name = "chkDiv";
            this.chkDiv.Size = new System.Drawing.Size(42, 17);
            this.chkDiv.TabIndex = 2;
            this.chkDiv.Text = "Div";
            this.chkDiv.UseVisualStyleBackColor = true;
            this.chkDiv.CheckedChanged += new System.EventHandler(this.chkDiv_CheckedChanged);
            // 
            // chkCheckBox
            // 
            this.chkCheckBox.AutoSize = true;
            this.chkCheckBox.Checked = true;
            this.chkCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckBox.Location = new System.Drawing.Point(7, 42);
            this.chkCheckBox.Name = "chkCheckBox";
            this.chkCheckBox.Size = new System.Drawing.Size(78, 17);
            this.chkCheckBox.TabIndex = 1;
            this.chkCheckBox.Text = "Check Box";
            this.chkCheckBox.UseVisualStyleBackColor = true;
            this.chkCheckBox.CheckedChanged += new System.EventHandler(this.chkCheckBox_CheckedChanged);
            // 
            // chkButton
            // 
            this.chkButton.AutoSize = true;
            this.chkButton.Checked = true;
            this.chkButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkButton.Location = new System.Drawing.Point(7, 19);
            this.chkButton.Name = "chkButton";
            this.chkButton.Size = new System.Drawing.Size(57, 17);
            this.chkButton.TabIndex = 0;
            this.chkButton.Text = "Button";
            this.chkButton.UseVisualStyleBackColor = true;
            this.chkButton.CheckedChanged += new System.EventHandler(this.chkButton_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(10, 56);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(256, 23);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(9, 95);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(238, 20);
            this.txtNamespace.TabIndex = 4;
            this.txtNamespace.TextChanged += new System.EventHandler(this.txtNamespace_TextChanged);
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamespace.Location = new System.Drawing.Point(6, 79);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(70, 13);
            this.lblNamespace.TabIndex = 5;
            this.lblNamespace.Text = "Namespace :";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(6, 118);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(67, 13);
            this.lblClassName.TabIndex = 6;
            this.lblClassName.Text = "Class name :";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(9, 134);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(238, 20);
            this.txtClassName.TabIndex = 7;
            this.txtClassName.TextChanged += new System.EventHandler(this.txtClassName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Drag to target window :";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkSaveInClassFolders);
            this.grpOptions.Controls.Add(this.chkGeneratePhysicalAndData);
            this.grpOptions.Controls.Add(this.chkGenerateControls);
            this.grpOptions.Controls.Add(this.txtClassName);
            this.grpOptions.Controls.Add(this.lblNamespace);
            this.grpOptions.Controls.Add(this.lblClassName);
            this.grpOptions.Controls.Add(this.txtNamespace);
            this.grpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.Location = new System.Drawing.Point(13, 40);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(253, 164);
            this.grpOptions.TabIndex = 9;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkGeneratePhysicalAndData
            // 
            this.chkGeneratePhysicalAndData.AutoSize = true;
            this.chkGeneratePhysicalAndData.Checked = true;
            this.chkGeneratePhysicalAndData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneratePhysicalAndData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGeneratePhysicalAndData.Location = new System.Drawing.Point(9, 38);
            this.chkGeneratePhysicalAndData.Name = "chkGeneratePhysicalAndData";
            this.chkGeneratePhysicalAndData.Size = new System.Drawing.Size(197, 17);
            this.chkGeneratePhysicalAndData.TabIndex = 9;
            this.chkGeneratePhysicalAndData.Text = "Generate Physical and Data classes";
            this.chkGeneratePhysicalAndData.UseVisualStyleBackColor = true;
            this.chkGeneratePhysicalAndData.CheckedChanged += new System.EventHandler(this.chkGeneratePhysicalAndData_CheckedChanged);
            // 
            // chkGenerateControls
            // 
            this.chkGenerateControls.AutoSize = true;
            this.chkGenerateControls.Checked = true;
            this.chkGenerateControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenerateControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGenerateControls.Location = new System.Drawing.Point(9, 20);
            this.chkGenerateControls.Name = "chkGenerateControls";
            this.chkGenerateControls.Size = new System.Drawing.Size(133, 17);
            this.chkGenerateControls.TabIndex = 8;
            this.chkGenerateControls.Text = "Generate Control class";
            this.chkGenerateControls.UseVisualStyleBackColor = true;
            this.chkGenerateControls.CheckedChanged += new System.EventHandler(this.chkGenerateControls_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConvertOR);
            this.groupBox1.Controls.Add(this.txtObjectRepository);
            this.groupBox1.Controls.Add(this.BtnSelectOR);
            this.groupBox1.Location = new System.Drawing.Point(12, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convert QTP Object Repository (ALPHA)";
            // 
            // btnConvertOR
            // 
            this.btnConvertOR.Enabled = false;
            this.btnConvertOR.Location = new System.Drawing.Point(159, 48);
            this.btnConvertOR.Name = "btnConvertOR";
            this.btnConvertOR.Size = new System.Drawing.Size(75, 23);
            this.btnConvertOR.TabIndex = 2;
            this.btnConvertOR.Text = "Convert";
            this.btnConvertOR.UseVisualStyleBackColor = true;
            this.btnConvertOR.Click += new System.EventHandler(this.btnConvertOR_Click);
            // 
            // txtObjectRepository
            // 
            this.txtObjectRepository.Location = new System.Drawing.Point(10, 21);
            this.txtObjectRepository.Name = "txtObjectRepository";
            this.txtObjectRepository.Size = new System.Drawing.Size(143, 20);
            this.txtObjectRepository.TabIndex = 1;
            this.txtObjectRepository.TextChanged += new System.EventHandler(this.txtObjectRepository_TextChanged);
            // 
            // BtnSelectOR
            // 
            this.BtnSelectOR.Location = new System.Drawing.Point(159, 19);
            this.BtnSelectOR.Name = "BtnSelectOR";
            this.BtnSelectOR.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectOR.TabIndex = 0;
            this.BtnSelectOR.Text = "Select";
            this.BtnSelectOR.UseVisualStyleBackColor = true;
            this.BtnSelectOR.Click += new System.EventHandler(this.BtnSelectOR_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // chkSaveInClassFolders
            // 
            this.chkSaveInClassFolders.AutoSize = true;
            this.chkSaveInClassFolders.Checked = true;
            this.chkSaveInClassFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveInClassFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveInClassFolders.Location = new System.Drawing.Point(9, 59);
            this.chkSaveInClassFolders.Name = "chkSaveInClassFolders";
            this.chkSaveInClassFolders.Size = new System.Drawing.Size(182, 17);
            this.chkSaveInClassFolders.TabIndex = 10;
            this.chkSaveInClassFolders.Text = "Save into individual class Folders";
            this.chkSaveInClassFolders.UseVisualStyleBackColor = true;
            this.chkSaveInClassFolders.CheckedChanged += new System.EventHandler(this.chkSaveInClassFolders_CheckedChanged);
            // 
            // controlEye1
            // 
            this.controlEye1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlEye1.BackgroundImage")));
            this.controlEye1.Location = new System.Drawing.Point(212, 2);
            this.controlEye1.Name = "controlEye1";
            controlSelection2.Button = true;
            controlSelection2.CheckBox = true;
            controlSelection2.Div = true;
            controlSelection2.GenerateControls = true;
            controlSelection2.GeneratePhysicalAndData = true;
            controlSelection2.Image = true;
            controlSelection2.Label = true;
            controlSelection2.Link = true;
            controlSelection2.RadioButton = true;
            controlSelection2.SelectList = true;
            controlSelection2.Span = true;
            controlSelection2.Table = false;
            controlSelection2.TextField = true;
            this.controlEye1.Selection = controlSelection2;
            this.controlEye1.Size = new System.Drawing.Size(34, 32);
            this.controlEye1.TabIndex = 0;
            this.controlEye1.GrabbingControl += new System.EventHandler(this.controlEye1_GrabbingControl);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlEye1);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grbControlType);
            this.Name = "MainWindow";
            this.Text = "Testing Stax Control Grabber";
            this.grbControlType.ResumeLayout(false);
            this.grbControlType.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        

        #endregion

        private System.Windows.Forms.GroupBox grbControlType;
        private System.Windows.Forms.CheckBox chkSpan;
        private System.Windows.Forms.CheckBox chkSelectList;
        private System.Windows.Forms.CheckBox chkRadioButton;
        private System.Windows.Forms.CheckBox chkDiv;
        private System.Windows.Forms.CheckBox chkCheckBox;
        private System.Windows.Forms.CheckBox chkButton;
        private System.Windows.Forms.CheckBox chkTextField;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.CheckBox chkLink;
        private System.Windows.Forms.CheckBox chkLabel;
        private System.Windows.Forms.CheckBox chkImage;
        private System.Windows.Forms.CheckBox chkTable;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private ControlEye.ControlEye controlEye1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkGeneratePhysicalAndData;
        private System.Windows.Forms.CheckBox chkGenerateControls;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConvertOR;
        private System.Windows.Forms.TextBox txtObjectRepository;
        private System.Windows.Forms.Button BtnSelectOR;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.CheckBox chkSaveInClassFolders;
    }
}

