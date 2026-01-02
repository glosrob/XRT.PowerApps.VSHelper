using System.Text.Json.Serialization;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class PowerAppsVSHelperConfig
    {
        // Properties

        [JsonInclude]
        internal string Root { get; set; }

        // ClientId and ClientSecret are stored in Windows Credential Manager, not in JSON
        [JsonIgnore]
        internal string ClientId { get; set; }

        [JsonIgnore]
        internal string ClientSecret { get; set; }

        [JsonInclude]
        internal string EnvironmentUrl { get; set; }

        [JsonInclude]
        internal bool AllowCreate { get; set; }

        [JsonInclude]
        internal string FilterValue { get; set; }

        [JsonInclude]
        internal bool FilterBySolutions { get; set; }

        [JsonInclude]
        internal bool IncludeSolutions { get; set; }

        // Methods

        public override string ToString()
        {
            return EnvironmentUrl ?? base.ToString();
        }
    }
}
