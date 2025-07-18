using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using XRT.PowerApps.VSHelper.Controllers;
using XRT.PowerApps.VSHelper.Models;
using Task = System.Threading.Tasks.Task;

namespace XRT.PowerApps.VSHelper
{
    /// <summary>
    /// Retrieves all files from the configured PowerApps environment.
    /// </summary>
    internal sealed class RetrieveAllCommand
    {
        // Properties

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static RetrieveAllCommand Instance
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
            // Switch to the main thread - the call to AddCommand in RetrieveAllCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new RetrieveAllCommand(package, commandService);
        }

        private RetrieveAllCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.Package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(Refs.CommandSet, Refs.RetrieveAllCommandId);
            var menuItem = new MenuCommand((s, e) =>
            {
                _ = ThreadHelper.JoinableTaskFactory.RunAsync(async () =>
                {
                    await ExecuteAsync(s, e);
                });
            }, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private async Task ExecuteAsync(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(Package.DisposalToken);
            await new CommandController(Package).ExecuteRetrieveAllCommandAsync();
        }
    }
}
