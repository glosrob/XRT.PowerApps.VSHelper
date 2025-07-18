using Microsoft.Crm.Sdk.Messages;
using Microsoft.Rest;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XRT.PowerApps.VSHelper.Models
{
    internal class PowerAppsHelper
    {
        // Constructors

        internal PowerAppsHelper()
        {

        }

        // Methods

        internal void TestConnection()
        {
            var config = GetConfig();
            TestConnection(config);
        }

        internal Entity GetWebResource(string path, bool includeContent = true)
        {
            var config = GetConfig();
            var serviceClient = GetServiceClient(config);

            var convertedPath = path.Replace("\\", "/");
            var fetch = "<fetch nolock='true'>" +
                             "<entity name='webresource'>" +
                               "<attribute name='displayname' />" +
                               "<attribute name='name' />" +
                               (includeContent ? "<attribute name='content' />" : "") +
                               "<attribute name='webresourcetype' />" +
                               "<filter type='or'>" +
                                 $"<condition attribute='name' operator='eq' value='{convertedPath}' />" +
                               "</filter>" +
                             "</entity>" +
                           "</fetch>";
            var results = serviceClient.RetrieveMultiple(new FetchExpression(fetch));
            return results.Entities.FirstOrDefault();
        }

        internal List<WebResourceItem> GetWebResources(PowerAppsVSHelperConfig config)
        {
            var serviceClient = GetServiceClient(config);
            var results = new List<Entity>();

            var webResourceType = 61;
            var fetch = string.Empty;

            if (config.FilterBySolutions)
            {
                // Get solution components for the selected solutions
                // And then retrieve the web resources
                fetch =
                    "<fetch nolock='true' page='[PAGE]' count='5000'>" +
                    "<entity name='solutioncomponent' >" +
                    "<attribute name='componenttype' />" +
                    "<attribute name='objectid' />" +
                    "<attribute name='rootcomponentbehavior' />" +
                    "<attribute name='rootsolutioncomponentid' />" +
                    "<attribute name='solutioncomponentid' />" +
                    "<attribute name='solutionid' />" +
                    "<filter type='and' >" +
                    $"<condition attribute='componenttype' operator='eq' value='{webResourceType}' />" +
                    "<filter type='or' >" +
                    "[SOLUTIONS]" +
                    "</filter>" +
                    "</filter>" +
                    "<link-entity name='solution' from='solutionid' to='solutionid' link-type='inner' alias='s' >" +
                    "<attribute name='friendlyname' />" +
                    "<attribute name='solutionid' />" +
                    "<attribute name='uniquename' />" +
                    "</link-entity>" +
                    "</entity>" +
                    "</fetch>";
                var solutions = config.FilterValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var solutionFilter = string.Join("", solutions.Select(s => $"<condition entityname='s' attribute='uniquename' operator='eq' value='{s}' />"));
                fetch = fetch.Replace("[SOLUTIONS]", solutionFilter);

                // Retrieve in groups of 20 to speed up the process
                var solutionComponents = PagedFetch(fetch, serviceClient);
                var groupedComponents = 
                    solutionComponents
                    .Select((entity, index) => new { entity, index })
                    .GroupBy(x => x.index / 20)
                    .Select(g => g.Select(x => x.entity).ToList())
                    .ToList();
                var itemResults = new List<WebResourceItem>();
                foreach (var group in groupedComponents)
                {
                    var webResourceIds = group.Select(e => e.GetAttributeValue<Guid>("objectid"));
                    var webResourceFetch =
                        "<fetch nolock='true'>" +
                        "<entity name='webresource'>" +
                        "<attribute name='displayname' />" +
                        "<attribute name='name' />" +
                        "<attribute name='content' />" +
                        "<attribute name='webresourcetype' />" +
                        "<filter type='or'>" +
                        "[WEBRESOURCE FETCH]" +
                        "</filter>" +
                        "</entity>" +
                        "</fetch>";
                    var webResourceFilter = string.Join("", webResourceIds.Select(id => $"<condition attribute='webresourceid' operator='eq' value='{id}' />"));
                    webResourceFetch = webResourceFetch.Replace("[WEBRESOURCE FETCH]", webResourceFilter);
                    var webResources = serviceClient.RetrieveMultiple(new FetchExpression(webResourceFetch)).Entities;

                    // Add each web resource to the results with the corresponding solution unique name
                    foreach (var webResource in webResources)
                    {
                        var solutionComponent = group.FirstOrDefault(e => e.GetAttributeValue<Guid>("objectid") == webResource.Id);
                        var solutionUniqueName = solutionComponent.GetAttributeValue<AliasedValue>("s.uniquename").Value as string ?? string.Empty;
                        itemResults.Add(new WebResourceItem(webResource, solutionUniqueName));
                    }
                }
                return itemResults;
            }
            else
            {
                // Retrieve by publisher prefix
                fetch =
                    "<fetch nolock='true' page='[PAGE]' count='5000'>" +
                    "<entity name='webresource'>" +
                    "<attribute name='displayname' />" +
                    "<attribute name='name' />" +
                    "<attribute name='content' />" +
                    "<attribute name='webresourcetype' />" +
                    "<filter type='and'>" +
                    $"<condition attribute='name' operator='like' value='{config.FilterValue}%' />" +
                    "</filter>" +
                    "</entity>" +
                    "</fetch>";
                results = PagedFetch(fetch, serviceClient);
                return results.Select(e => new WebResourceItem(e)).ToList();
            }
        }

        internal void UpdateWebResource(Entity webRes, string data)
        {
            var serviceClient = GetServiceClient(GetConfig());

            var upd = new Entity(webRes.LogicalName, webRes.Id);
            upd.Attributes.Add("content", data);
            serviceClient.Update(upd);
         }

        internal void PublishWebResource(Guid id)
        {
            var serviceClient = GetServiceClient(GetConfig());

            var xml = $"<importexportxml><webresources><webresource>{id}</webresource></webresources></importexportxml>";
            var request = new PublishXmlRequest
            {
                ParameterXml = xml
            };
            serviceClient.Execute(request);
        }

        // Helpers

        private PowerAppsVSHelperConfig GetConfig()
        {
            var configHelper = new ConfigHelper();
            var config = configHelper.LoadConfigFromFile();
            return config ?? throw new Exception("Please configure the extension.");
        }

        private CrmServiceClient GetServiceClient(PowerAppsVSHelperConfig config)
        {
            var connString = $"AuthType=ClientSecret;Url={config.EnvironmentUrl};ClientId={config.ClientId};ClientSecret={config.ClientSecret};";
            return new CrmServiceClient(connString);
        }

        private void TestConnection(PowerAppsVSHelperConfig config)
        {
            if (config == null)
            {
                throw new Exception("Config is null.");
            }

            if (string.IsNullOrEmpty(config.EnvironmentUrl) || string.IsNullOrEmpty(config.ClientId) || string.IsNullOrEmpty(config.ClientSecret))
            {
                throw new Exception("Please provide all connection details.");
            }
        }

        private List<Entity> PagedFetch(string fetch, CrmServiceClient serviceClient)
        {
            var pageNum = 1;
            var results = new List<Entity>();
            while (true)
            {
                var fetchXml = fetch.Replace("[PAGE]", pageNum.ToString());
                var result = serviceClient.RetrieveMultiple(new FetchExpression(fetchXml));
                if (result.Entities.Count == 0)
                {
                    break;
                }

                results.AddRange(result.Entities);
                pageNum++;
            }
            return results;
        }
    }
}
