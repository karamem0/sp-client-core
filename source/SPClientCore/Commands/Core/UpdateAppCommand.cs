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

    [Cmdlet("Update", "SPApp")]
    [OutputType(typeof(CorporateCatalogAppMetadata))]
    public class UpdateAppCommand : PSCmdlet
    {

        public UpdateAppCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public AppPipeBind App { get; private set; }

        [Parameter(Mandatory = false)]
        public AppScope Scope { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var appService = ClientObjectService.ServiceProvider.GetService<IAppService>();
            var appQuery = ODataQuery.Create<CorporateCatalogAppMetadata>(this.MyInvocation.BoundParameters);
            if (this.Scope == AppScope.Tenant)
            {
                appService.UpgradeTenantApp(this.App);
                if (this.PassThru)
                {
                    this.WriteObject(appService.GetTenantApp(this.App, appQuery));
                }
            }
            if (this.Scope == AppScope.SiteCollection)
            {
                appService.UpgradeSiteCollectionApp(this.App);
                if (this.PassThru)
                {
                    this.WriteObject(appService.GetSiteCollectionApp(this.App, appQuery));
                }
            }
        }

    }

}
