using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VS2010TestResultPublisher
{
    public partial class TFSDialog : Form
    {
        public string Build = String.Empty;

        public TFSDialog(List<string> builds)
        {
            InitializeComponent();

            LoadBuildDropdown(builds);
        }

        private void LoadBuildDropdown(List<string> builds)
        {
            ddlBuilds.DataSource = builds;
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Build = ddlBuilds.SelectedValue.ToString();
            this.Close();
        }

    }
}
