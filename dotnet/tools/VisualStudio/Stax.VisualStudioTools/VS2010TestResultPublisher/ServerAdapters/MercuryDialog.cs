using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace VS2010TestResultPublisher
{
    public partial class MercuryDialog : Form
    {
        public MercuryDialog()
        {
            InitializeComponent();
            txtServerUrl.Enabled = true;
            btnConnect.Enabled = true;
            LoadMercuryConfiguration();
        }

        public string ServerUrl { get; set; }
        public string DomainName { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FolderNodeId { get; set; }

        private void DisableAllFields()
        {
            txtServerUrl.Enabled = false;
            btnConnect.Enabled = false;
            ddlProject.Enabled = false;
            ddlDomain.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
        }

        #if HPQC
        private List<string> ConvertList(TDAPIOLELib.List oldList)
        {
            List<string> newList = new List<string>();
            newList.Add(String.Empty);
            foreach (object listItem in oldList)
            {
                newList.Add(listItem.ToString());
            }
            return newList;
        }
        #endif

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RetrieveDomainList();
        }

        private void btnGetTestSets_Click(object sender, EventArgs e)
        {
            RetrieveTestSets();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            ServerUrl = txtServerUrl.Text;
            DomainName = ddlDomain.Text;
            ProjectName = ddlProject.Text;            
            UserName = txtUsername.Text;
            Password = txtPassword.Text;
            FolderNodeId = Convert.ToInt32(ddlFolderList.SelectedValue);
            SaveConfiguration();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RetrieveDomainList()
        {
            #if HPQC
            ddlDomain.Enabled = true;
            TDAPIOLELib.TDConnection connection = new TDAPIOLELib.TDConnection();
            connection.InitConnectionEx(txtServerUrl.Text);
            ddlDomain.DataSource = ConvertList(connection.DomainsList);
            #endif
        }

        private void RetrieveProjectList()
        {
            #if HPQC
            TDAPIOLELib.TDConnection connection = new TDAPIOLELib.TDConnection();
            connection.InitConnectionEx(txtServerUrl.Text);
            ddlProject.DataSource = ConvertList(connection.get_ProjectsListEx(ddlDomain.Text));
            ddlProject.Enabled = true;
            #endif
        }

        private void RetrieveTestSets()
        {
            #if HPQC
            TDAPIOLELib.TDConnection connection = new TDAPIOLELib.TDConnection();
            try
            {
                connection.InitConnectionEx(txtServerUrl.Text);
                connection.ConnectProjectEx(ddlDomain.Text, ddlProject.Text, txtUsername.Text, txtPassword.Text);

                TDAPIOLELib.TestSetTreeManager testFolders = (TDAPIOLELib.TestSetTreeManager)connection.TestSetTreeManager;
                TDAPIOLELib.TestSetFolder testFolder = (TDAPIOLELib.TestSetFolder)testFolders.Root;
                
                List<FolderStructure> testSets = new List<FolderStructure>();
                foreach (TDAPIOLELib.TestSetFolder set in testFolder.FindChildren("", false, ""))
                {
                    testSets.Add(new FolderStructure(DisplayName(set.Name, set.Path), set.NodeID, set.Path));
                }
                testSets.Sort(new FolderStructureComparer());

                ddlFolderList.DataSource = testSets;
                ddlFolderList.DisplayMember = "Name";
                ddlFolderList.ValueMember = "Value";
                ddlFolderList.Enabled = true;
            }
            catch (Exception ex)
            {
                ErrorReportingForm ef = new ErrorReportingForm();
                ef.txtErrorDetails.Text = ex.Message + ex.StackTrace;
                ef.Show();
            }
            finally
            {
                if (connection.ProjectConnected)
                {
                    connection.DisconnectProject();
                }
            }
            #endif
        }

        private void LoadMercuryConfiguration()
        {
            #if HPQC
            try
            {
                string server = ConfigurationManager.AppSettings["MercuryServer"];
                string domain = ConfigurationManager.AppSettings["MercuryDomain"];
                string project = ConfigurationManager.AppSettings["MercuryProject"];
                if (!String.IsNullOrEmpty(server))
                {
                    txtServerUrl.Text = server;
                    RetrieveDomainList();
                    ddlDomain.Text = domain;
                    RetrieveProjectList();
                    ddlProject.Text = project;
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                    btnGetTestSets.Enabled = true;
                }
            }
            catch { }
            #endif
        }

        private void SaveConfiguration()
        {
            #if HPQC
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("MercuryServer");
            config.AppSettings.Settings.Remove("MercuryDomain");
            config.AppSettings.Settings.Remove("MercuryProject");
            config.AppSettings.Settings.Add("MercuryServer", txtServerUrl.Text);
            config.AppSettings.Settings.Add("MercuryDomain", ddlDomain.Text);
            config.AppSettings.Settings.Add("MercuryProject", ddlProject.Text);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            #endif
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ddlDomain_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlDomain.Text))
            {
                RetrieveProjectList();
            }
        }

        private void ddlProject_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlProject.Text))
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                btnGetTestSets.Enabled = true;
            }
            else
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                btnGetTestSets.Enabled = false;
            }
        }

        private string DisplayName(string value, string path)
        {
            int depth = 0;

            depth = path.Split('\\').Length - 1;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                sb.Append("-");
            }
            sb.Append(" " + value);
            return sb.ToString();
        }

        public class FolderStructureComparer : IComparer<FolderStructure>
        {

            #region IComparer<FolderStructure> Members

            public int Compare(FolderStructure x, FolderStructure y)
            {
                return String.Compare(x.Path, y.Path);
            }

            #endregion
        }

        public class FolderStructure : IComparable<FolderStructure>
        {
            public FolderStructure(string name, int value, string path)
            {
                this.Name = name;
                this.Value = value;
                this.Path = path;
            }

            public string Name { get; set; }
            public int Value { get; set; }
            public string Path { get; set; }

            #region IComparable<FolderStructure> Members

            public int CompareTo(FolderStructure other)
            {
                return Path.CompareTo(other.Path);
            }

            #endregion
        }

    }
}
