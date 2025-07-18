using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System.IO;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class DteHelper
    {
        internal string GetSolutionPath()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null)
            {
                return null;
            }
            if (dte.Solution != null && !string.IsNullOrEmpty(dte.Solution.FullName))
            {
                return Path.GetDirectoryName(dte.Solution.FullName);
            }
            return null;
        }

        internal string GetSelectedFileName()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null)
            {
                return null;
            }

            // check only one item is selected
            if (dte.SelectedItems.Count != 1)
            {
                return null;
            }

            // return file name
            var selectedItem = dte.SelectedItems.Item(1);
            if (selectedItem.ProjectItem != null)
            {
                return selectedItem.ProjectItem.FileNames[1];
            }

            return null;
        }

        internal string GetPathRelativeToSourceRoot(string sourceRoot, string fullFilePath)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var solutionPath = GetSolutionPath();
            var thisFullFilePath = fullFilePath ?? string.Empty;

            // Combine root and sourceRoot
            var combinedSourceRoot = Path.Combine(solutionPath, sourceRoot);
            combinedSourceRoot = combinedSourceRoot.Replace("/", "\\");
            var filePath = thisFullFilePath.Replace(combinedSourceRoot, string.Empty);

            // Get the part of the file path that comes after the combined sourceRoot
            return filePath.Replace(combinedSourceRoot, string.Empty);
        }
    }
}
