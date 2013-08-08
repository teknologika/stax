using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VS2010TestResultPublisher
{
    public partial class PublishResults : Form
    {
        public PublishResults()
        {
            InitializeComponent();
        }

        public void SetOutputText(string text)
        {
            txtOutput.AppendText(text);
            txtOutput.AppendText(Environment.NewLine);
        }

        public void AddResult(string result)
        {
            SetOutputText(result);
            txtOutput.Refresh();
            txtOutput.SelectionLength = 0;
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }

        public void FinishedPublishing()
        {
            btnOk.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
