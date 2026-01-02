using Microsoft.VisualStudio.Shell;
using System.IO;
using System.Text.Json;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class ConfigHelper
    {
        // Properties

        internal string SolutionPath { get; set; }

        // Constructors

        internal ConfigHelper()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dteHelper = new DteHelper();
            SolutionPath = dteHelper.GetSolutionPath();
        }

        internal ConfigHelper(string solutionPath)
        {
            SolutionPath = solutionPath;
        }

        // Methods

        internal PowerAppsVSHelperConfig LoadConfigFromFile()
        {
            var path = Path.Combine(SolutionPath, "powerapps-vs-helper-config.json");
            if (!File.Exists(path))
            {
                return null;
            }

            var config = JsonSerializer.Deserialize<PowerAppsVSHelperConfig>(File.ReadAllText(path));

            // Load credentials from Windows Credential Manager
            if (config != null && !string.IsNullOrWhiteSpace(config.EnvironmentUrl))
            {
                var credentialHelper = new CredentialHelper();
                var (clientId, clientSecret) = credentialHelper.LoadCredentials(config.EnvironmentUrl);
                config.ClientId = clientId;
                config.ClientSecret = clientSecret;
            }

            return config;
        }
    }
}
