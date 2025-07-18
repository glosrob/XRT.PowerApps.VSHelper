using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using XRT.PowerApps.VSHelper.Controllers;
using XRT.PowerApps.VSHelper.Models;
using Task = System.Threading.Tasks.Task;

namespace XRT.PowerApps.VSHelper
{
    /// <summary>
    /// Retrieves a file from the configured PowerApps environment.
    /// </summary>
    internal sealed class RetrieveCommand
    {
        // Properties

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static RetrieveCommand Instance
        {
            get;
            private set;
        }

        private readonly AsyncPackage Package;

        // Methods

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in RetrieveCommand's constructor requires the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new RetrieveCommand(package, commandService);
        }

        private RetrieveCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.Package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(Refs.CommandSet, Refs.RetrieveCommandId);

            var menuItem = new OleMenuCommand((s, e) =>
            {
                _ = ThreadHelper.JoinableTaskFactory.RunAsync(async () =>
                {
                    await ExecuteAsync(s, e);
                });
            }, menuCommandID);

            menuItem.BeforeQueryStatus += BeforeQueryStatus;
            commandService.AddCommand(menuItem);
        }

        private async Task ExecuteAsync(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(Package.DisposalToken);
            var commandController = new CommandController(Package);
            await commandController.ExecuteRetrieveCommandAsync();
        }

        private void BeforeQueryStatus(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var command = (OleMenuCommand)sender;
            var dte = ServiceProvider.GlobalProvider.GetService(typeof(SDTE)) as EnvDTE.DTE;
            if (dte == null)
            {
                command.Visible = false;
                return;
            }
            if (dte.SelectedItems.Count != 1)
            {
                command.Visible = false;
                return;
            }

            // Check if the selected item is a project item (a file)
            var selectedItem = dte.SelectedItems.Item(1);
            if (selectedItem != null && selectedItem.ProjectItem != null)
            {
                var fileName = selectedItem.ProjectItem.FileNames[1];
                var fileExtension = Path.GetExtension(fileName).ToLower();

                var validExtensions = new[] { ".js", ".html", ".xml", ".css", ".svg", ".png", ".jpeg", ".jpg" };
                command.Visible = validExtensions.Contains(fileExtension);
            }
            else
            {
                command.Visible = false;
            }
        }
    }
}
