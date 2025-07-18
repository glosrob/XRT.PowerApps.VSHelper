using Microsoft.Xrm.Sdk;
using System;
using System.IO;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class WebResourceItem
    {
        // Properties

        internal string Name { get; }

        internal string Content { get; }

        internal string SchemaName { get; }

        internal Guid WebResourceId { get; }

        internal string WebResourceType { get; }

        internal string SolutionName { get; }

        // Constructors

        internal WebResourceItem(Entity e)
        {
            Name = e.GetAttributeValue<string>("displayname");
            Content = e.GetAttributeValue<string>("content");
            SchemaName = e.GetAttributeValue<string>("name");
            WebResourceId = e.Id;
            WebResourceType = e.FormattedValues.ContainsKey("webresourcetype") ? e.FormattedValues["webresourcetype"] : "Unknown Type";
        }

        internal WebResourceItem(Entity e, string solutionName): this(e)
        {
            SolutionName = solutionName;
        }

        // Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(SolutionName))
            {
                return Name;
            }
            return $"{Name} ({SolutionName})";
        }
    }
}
