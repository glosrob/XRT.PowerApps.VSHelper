using Microsoft.VisualStudio.Shell;
using System;
using System.Windows.Forms;
using XRT.PowerApps.VSHelper.Controllers;
using XRT.PowerApps.VSHelper.Models;

namespace XRT.PowerApps.VSHelper.Dialogs
{
    public partial class Config : Form
    {
        // Properties

        ConfigController Controller { get; set; }

        // Constructors

        public Config(string solutionPath)
        {
            InitializeComponent();
            Controller = new ConfigController(this, solutionPath);
            Controller.LoadConfig();

            btnTest.Click += BtnTest_Click;
            btnSave.Click += BtnSave_Click;
            llOpenSourceRoot.Click += LlOpenSourceRoot_Click;
            txtRoot.TextChanged += TxtRoot_TextChanged;
            chkIncludeSolutions.CheckedChanged += ChkIncludeSolutions_CheckedChanged;

            Load += Config_Load;
        }

        // Event handlers

        private void Config_Load(object sender, EventArgs e)
        {
            SetExamplePath();
        }

        private void ChkIncludeSolutions_CheckedChanged(object sender, EventArgs e)
        {
            SetExamplePath();
        }

        private void TxtRoot_TextChanged(object sender, EventArgs e)
        {
            SetExamplePath();
        }

        void BtnTest_Click(object sender, EventArgs e)
        {
            Controller.TestConnection(GetConfig());
        }

        void BtnSave_Click(object sender, EventArgs e)
        {
            Controller.SaveConnection(GetConfig());
        }

        void LlOpenSourceRoot_Click(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            Controller.OpenSourceRoot(txtRoot.Text);
        }

        // Methods

        internal void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "PowerApps VS Helper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "PowerApps VS Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void SetConfigDetails(PowerAppsVSHelperConfig conn)
        {
            txtClientId.Text = conn.ClientId ?? string.Empty;
            txtClientSecret.Text = conn.ClientSecret ?? string.Empty;
            txtURL.Text = conn.EnvironmentUrl ?? string.Empty;
            txtRoot.Text = conn.Root ?? string.Empty;
            txtFilterValue.Text = conn.FilterValue ?? string.Empty;
            radSolutions.Checked = conn.FilterBySolutions;
            radPublisher.Checked = !conn.FilterBySolutions;
            chkIncludeSolutions.Checked = conn.IncludeSolutions;
            chkAllowNew.Checked = conn.AllowCreate;
        }

        private PowerAppsVSHelperConfig GetConfig()
        {
            return new PowerAppsVSHelperConfig
            {
                AllowCreate = chkAllowNew.Checked,
                ClientId = txtClientId.Text,
                ClientSecret = txtClientSecret.Text,
                EnvironmentUrl = txtURL.Text,
                Root = txtRoot.Text,
                FilterBySolutions = radSolutions.Checked,
                FilterValue = txtFilterValue.Text,
                IncludeSolutions = chkIncludeSolutions.Checked
            };
        }

        private void SetExamplePath()
        {
            lblExamplePathDetail.Text = chkIncludeSolutions.Checked
                ? $"{txtRoot.Text}\\Solution Name\\" :
                $"{txtRoot.Text}\\";
        }
    }
}
