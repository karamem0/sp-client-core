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

    [Cmdlet("New", "SPApp")]
    [OutputType(typeof(CorporateCatalogAppMetadata))]
    public class NewAppCommand : PSCmdlet
    {

        public NewAppCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public string Name { get; private set; }

        [Parameter(Mandatory = true)]
        public System.IO.Stream Content { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false)]
        public AppScope Scope { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var appService = ClientObjectService.ServiceProvider.GetService<IAppService>();
            var appQuery = ODataQuery.Create<File>(this.MyInvocation.BoundParameters);
            if (this.Scope == AppScope.Tenant)
            {
                var appFile = appService.CreateTenantApp(this.Name, this.Content, this.Overwrite, "$expand=ListItemAllFields/UniqueId");
                var appId = (string)appFile.ListItemAllFields["UniqueId"];
                this.WriteObject(appService.GetTenantApp(new AppPipeBind(appId), appQuery));
            }
            if (this.Scope == AppScope.SiteCollection)
            {
                var appFile = appService.CreateSiteCollectionApp(this.Name, this.Content, this.Overwrite, "$expand=ListItemAllFields/UniqueId");
                var appId = (string)appFile.ListItemAllFields["UniqueId"];
                this.WriteObject(appService.GetSiteCollectionApp(new AppPipeBind(appId), appQuery));
            }
        }

    }

}
