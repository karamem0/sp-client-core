//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("New", "SPCatalogApp")]
    [OutputType(typeof(CatalogApp))]
    public class NewCatalogAppCommand : PSCmdlet
    {

        public NewCatalogAppCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public string Name { get; private set; }

        [Parameter(Mandatory = true)]
        public System.IO.Stream Content { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false)]
        public CatalogAppScope? Scope { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var catalogAppService = ClientObjectService.ServiceProvider.GetService<ICatalogAppService>();
            var catalogAppQuery = ODataQuery.Create<File>(this.MyInvocation.BoundParameters);
            if (this.Scope == CatalogAppScope.Tenant)
            {
                var catalogAppFile = catalogAppService.CreateTenantCatalogApp(this.Name, this.Content, this.Overwrite, "$expand=ListItemAllFields/UniqueId");
                var catalogAppId = (string)catalogAppFile.ListItemAllFields["UniqueId"];
                this.WriteObject(catalogAppService.GetTenantCatalogApp(new CatalogAppPipeBind(catalogAppId), catalogAppQuery));
            }
            if (this.Scope == CatalogAppScope.Site)
            {
                var catalogAppFile = catalogAppService.CreateSiteCatalogApp(this.Name, this.Content, this.Overwrite, "$expand=ListItemAllFields/UniqueId");
                var catalogAppId = (string)catalogAppFile.ListItemAllFields["UniqueId"];
                this.WriteObject(catalogAppService.GetSiteCatalogApp(new CatalogAppPipeBind(catalogAppId), catalogAppQuery));
            }
        }

    }

}
