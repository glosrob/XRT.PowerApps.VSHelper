using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using XRT.PowerApps.VSHelper.Dialogs;
using XRT.PowerApps.VSHelper.Models;
using Task = System.Threading.Tasks.Task;

namespace XRT.PowerApps.VSHelper
{
    /// <summary>
    /// Sets config options for the extension.
    /// </summary>
    internal sealed class ConfigCommand
    {
        // Properties
        
        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ConfigCommand Instance
        {
            get;
            private set;
        }

        // Methods

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ConfigCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new ConfigCommand(commandService);
        }

        private ConfigCommand(OleMenuCommandService commandService)
        {
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(Refs.CommandSet, Refs.ConfigCommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var solutionPath = new DteHelper().GetSolutionPath();
            if (string.IsNullOrEmpty(solutionPath))
            {
                MessageBox.Show("Please use the extension within the context of a solution.");
                return;
            }

            var form = new Config(solutionPath);
            form.ShowDialog();
        }
    }
}
