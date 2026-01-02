using Microsoft.Crm.Sdk.Messages;
using Microsoft.VisualStudio.Shell;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using XRT.PowerApps.VSHelper.Dialogs;
using XRT.PowerApps.VSHelper.Models;

namespace XRT.PowerApps.VSHelper.Controllers
{
    internal class ConfigController
    {
        // Properties

        private readonly Config View;

        private readonly string SolutionPath;

        // Constructor

        internal ConfigController(Config config, string solutionPath)
        {
            View = config;
            SolutionPath = solutionPath;
        }

        // Methods

        internal void TestConnection(PowerAppsVSHelperConfig conn)
        {
            try
            {
                if (conn == null)
                {
                    throw new ArgumentNullException(nameof(conn));
                }
                if (string.IsNullOrEmpty(conn.EnvironmentUrl) || string.IsNullOrEmpty(conn.ClientId) || string.IsNullOrEmpty(conn.ClientSecret))
                {
                    View.ShowErrorMessage("Please provide all connection details.");
                    return;
                }

                var connString = $"AuthType=ClientSecret;Url={conn.EnvironmentUrl};ClientId={conn.ClientId};ClientSecret={conn.ClientSecret};";
                var serviceClient = new CrmServiceClient(connString);

                var whoAmIResult = serviceClient.Execute(new WhoAmIRequest()) as WhoAmIResponse;
                if (whoAmIResult == null)
                {
                    View.ShowErrorMessage("Connection failed.");
                    return;
                }
                View.ShowInfoMessage("Connection succeeded.");
            }
            catch (Exception ex)
            {
                View.ShowErrorMessage($"Exception testing the connection - {ex.Message} [{ex.GetType().Name}]");
            }
        }

        internal void LoadConfig()
        {
            var configHelper = new ConfigHelper(SolutionPath);
            var config = configHelper.LoadConfigFromFile();
            if (config != null)
            {
                View.SetConfigDetails(config);
            }
        }

        internal void SaveConnection(PowerAppsVSHelperConfig conn)
        {
            // Save credentials to Windows Credential Manager
            var credentialHelper = new CredentialHelper();
            credentialHelper.SaveCredentials(conn.EnvironmentUrl, conn.ClientId, conn.ClientSecret);

            // Save non-sensitive config to JSON (ClientId and ClientSecret will be excluded due to [JsonIgnore])
            var jsonFile = JsonSerializer.Serialize(conn);
            File.WriteAllText(Path.Combine(SolutionPath, "powerapps-vs-helper-config.json"), jsonFile);

            View.ShowInfoMessage("Configuration saved securely to Windows Credential Manager.");
        }

        internal void OpenSourceRoot(string pathToOpen)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dteHelper = new DteHelper();
            var solutionPath = dteHelper.GetSolutionPath();

            var folderPath = Path.Combine(solutionPath, pathToOpen);

            if (Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                View.ShowErrorMessage("The source root path does not exist.");
            }
        }
    }
}
