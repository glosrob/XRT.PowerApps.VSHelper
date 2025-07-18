using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Threading.Tasks;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class VSMessagingHelper
    {
        private Guid PaneGuid = new Guid("B9AA57E5-0209-4F74-9B53-91CE2F070B2E");
        private const string PaneTitle = "PowerApps VS Helper";
        
        internal VSMessagingHelper(AsyncPackage package)
        {
            Package = package;
        }

        internal AsyncPackage Package { get; }

        private IVsOutputWindowPane Pane { get; set; }

        internal async Task DisplayMessageAsync(string message)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var statusBar = await Package.GetServiceAsync(typeof(SVsStatusbar)) as IVsStatusbar;
            statusBar?.SetText(message);
        }

        internal async Task WriteToOuputWindowAsync(string text)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            if (Pane == null)
            {
                var outputWindow = await Package.GetServiceAsync(typeof(SVsOutputWindow)) as IVsOutputWindow;
                if (outputWindow == null) return;

                // Create (or get) the pane
                outputWindow.CreatePane(ref PaneGuid, PaneTitle, fInitVisible: 1, fClearWithSolution: 1);
                outputWindow.GetPane(ref PaneGuid, out IVsOutputWindowPane pane);
                Pane = pane;
            }

            var prefix = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ";
            Pane.OutputStringThreadSafe(prefix + text + Environment.NewLine);
        }
    }
}
