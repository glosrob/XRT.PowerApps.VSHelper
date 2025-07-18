using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Activities.Statements;
using System.IO;
using System.IO.Packaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XRT.PowerApps.VSHelper.Models;

namespace XRT.PowerApps.VSHelper.Controllers
{
    internal class CommandController
    {
        internal CommandController(AsyncPackage package)
        {
            Package = package;
            Messaging = new VSMessagingHelper(package);
        }

        internal AsyncPackage Package { get; }

        internal VSMessagingHelper Messaging { get; }

        // Methods

        internal async Task ExecuteRetrieveCommandAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(Package.DisposalToken);
            await Messaging.WriteToOuputWindowAsync("Retrieve started");

            try
            {
                await Messaging.WriteToOuputWindowAsync("| Setup");
                var configHelper = new ConfigHelper();
                var config = configHelper.LoadConfigFromFile();
                var relativePath = GetRelativePath(config);

                // Get the web resource
                await Messaging.WriteToOuputWindowAsync($"| Get WebResource {relativePath}");
                var powerAppsHelper = new PowerAppsHelper();
                var webResource = powerAppsHelper.GetWebResource(relativePath, true);
                if (webResource == null)
                {
                    await Messaging.WriteToOuputWindowAsync($"| Web resource not found for the path '{relativePath}'");
                    await Messaging.DisplayMessageAsync($"Web resource not found for the path '{relativePath}'");
                    return;
                }

                // Save the file on disk
                await Messaging.WriteToOuputWindowAsync($"| Saving to disk");
                var savePath = Path.Combine(config.Root, webResource.GetAttributeValue<string>("name"));
                var base64 = webResource.GetAttributeValue<string>("content");
                var decodedBytes = Convert.FromBase64String(base64);
                await Messaging.WriteToOuputWindowAsync($"| Saving..");
                File.WriteAllBytes(savePath, decodedBytes);
                await Messaging.WriteToOuputWindowAsync($"| Saved");
                await Messaging.WriteToOuputWindowAsync($"| Retrieved");
                await Messaging.DisplayMessageAsync($"Retrieved {webResource.GetAttributeValue<string>("displayname")}");
            }
            catch (Exception ex)
            {
                await Messaging.WriteToOuputWindowAsync($"| Exception - {ex.Message}{Environment.NewLine}{ex}");
                await Messaging.DisplayMessageAsync($"An error occurred while retrieving the web resource: {ex.Message}");
                throw ex;
            }
        }

        internal async Task ExecutePublishCommandAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(Package.DisposalToken);
            await Messaging.WriteToOuputWindowAsync($"Publish started");

            try
            {
                await Messaging.WriteToOuputWindowAsync($"| Setup");
                var powerAppsHelper = new PowerAppsHelper();
                var configHelper = new ConfigHelper();
                var config = configHelper.LoadConfigFromFile();
                var relativePath = GetRelativePath(config);
                var fullPath = Path.GetFullPath(Path.Combine(config.Root, relativePath));
                if (!File.Exists(fullPath))
                {
                    await Messaging.WriteToOuputWindowAsync($"| Could not find Web Resource {relativePath} in the currently configured environment");
                    await Messaging.DisplayMessageAsync($"Could not find Web Resource {relativePath} in the currently configured environment");
                    return;
                }

                await Messaging.DisplayMessageAsync($"Retrieving..");
                await Messaging.WriteToOuputWindowAsync($"| Get WebResource {relativePath}");
                var webRes = powerAppsHelper.GetWebResource(relativePath, true);
                if (webRes == null)
                {
                    await Messaging.WriteToOuputWindowAsync($"| Could not find Web Resource in the currently configured environment");
                    await Messaging.DisplayMessageAsync($"Could not find Web Resource in the currently configured environment");
                    return;
                }

                await Messaging.WriteToOuputWindowAsync($"| Saving to disk");
                var fileContent = File.ReadAllText(fullPath);
                var binary = Convert.FromBase64String(webRes.GetAttributeValue<string>("content"));
                var webResourceContent = Encoding.UTF8.GetString(binary);
                if (webResourceContent == fileContent)
                {
                    await Messaging.WriteToOuputWindowAsync($"| Local content matches server content");
                    await Messaging.DisplayMessageAsync($"Local content matches server content");
                    return;
                }
                var data = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContent));

                await Messaging.DisplayMessageAsync($"Updating and publishing..");
                await Messaging.WriteToOuputWindowAsync($"| Saving..");
                powerAppsHelper.UpdateWebResource(webRes, data);
                await Messaging.WriteToOuputWindowAsync($"| Saved");
                await Messaging.WriteToOuputWindowAsync($"| Publishing..");
                powerAppsHelper.PublishWebResource(webRes.Id);
                await Messaging.WriteToOuputWindowAsync($"| Published");
                await Messaging.DisplayMessageAsync($"Published successfully");
            }
            catch (Exception ex)
            {
                await Messaging.WriteToOuputWindowAsync($"| Exception - {ex.Message}{Environment.NewLine}{ex}");
                await Messaging.DisplayMessageAsync($"An error occurred while retrieving the web resource: {ex.Message}");
                throw ex;
            }
        }

        internal async Task ExecuteRetrieveAllCommandAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(Package.DisposalToken);
            await Messaging.WriteToOuputWindowAsync($"Retrieve all started");

            try
            {
                await Messaging.WriteToOuputWindowAsync($"| Setup");
                var configHelper = new ConfigHelper();
                var config = configHelper.LoadConfigFromFile();
                var relativePath = GetRelativePath(config);
                var powerAppsHelper = new PowerAppsHelper();

                // Get all web resources
                await Messaging.DisplayMessageAsync($"Retrieving all..");
                await Messaging.WriteToOuputWindowAsync("| Get WebResources");
                var webResources = powerAppsHelper.GetWebResources(config);

                // Save the files on disk
                var total = webResources.Count;
                var ctr = 0;
                await Messaging.DisplayMessageAsync($"Writing..");
                await Messaging.WriteToOuputWindowAsync("| Writing");
                foreach (var webResource in webResources)
                {
                    ctr++;
                    await Messaging.WriteToOuputWindowAsync($"| Processing {ctr} of {total} - {webResource.Name}");
                    var name = webResource.SchemaName;

                    var savePath = Path.Combine(config.Root, name);
                    savePath = savePath.Replace("/", "\\");

                    bool fileExists = File.Exists(savePath);
                    if (!fileExists && !config.AllowCreate)
                    {
                        await Messaging.WriteToOuputWindowAsync($"- {webResource.Name} does not exist locally; skipping due to config");
                        await Messaging.DisplayMessageAsync($"{webResource.Name} does not exist locally; skipping due to config");
                        continue;
                    }

                    var directory = Path.GetDirectoryName(savePath);
                    if (!Directory.Exists(directory))
                    {
                        await Messaging.WriteToOuputWindowAsync($"- Creating directory {directory}");
                        Directory.CreateDirectory(directory);
                    }

                    await Messaging.WriteToOuputWindowAsync($"- Saving to disk");
                    var bytes = Convert.FromBase64String(webResource.Content);
                    File.WriteAllBytes(savePath, bytes);
                    await Messaging.WriteToOuputWindowAsync($"- Saved");
                }

                await Messaging.WriteToOuputWindowAsync($"| Retrieved {total} resource{(total == 1 ? string.Empty : "s")}");
                await Messaging.DisplayMessageAsync($"Retrieved {total} resource{(total == 1 ? string.Empty : "s")}");
            }
            catch (Exception ex)
            {
                await Messaging.WriteToOuputWindowAsync($"| Exception - {ex.Message}{Environment.NewLine}{ex}");
                await Messaging.DisplayMessageAsync($"An error occurred while retrieving all web resources: {ex.Message}");
                throw ex;
            }
        }

        // Helpers

        private string GetRelativePath(PowerAppsVSHelperConfig config)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var dteHelper = new DteHelper();
            var solutionPath = dteHelper.GetSolutionPath();
            if (string.IsNullOrEmpty(solutionPath))
            {
                return string.Empty;
            }

            var fileName = dteHelper.GetSelectedFileName();
            var relativePath = dteHelper.GetPathRelativeToSourceRoot(config.Root, fileName);

            // Normalize: trim leading slashes and ensure consistent path format
            return relativePath?.TrimStart('\\', '/');
        }
    }
}
