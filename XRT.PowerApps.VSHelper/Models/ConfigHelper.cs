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
            var conn = JsonSerializer.Deserialize<PowerAppsVSHelperConfig>(File.ReadAllText(path));
            return conn;
        }
    }
}
