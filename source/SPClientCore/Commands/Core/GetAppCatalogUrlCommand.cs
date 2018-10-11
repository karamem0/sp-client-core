//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
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

    [Cmdlet("Get", "SPAppCatalogUrl")]
    [OutputType(typeof(string[]))]
    public class GetAppCatalogUrlCommand : ClientObjectCmdlet
    {

        public GetAppCatalogUrlCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public AppScope Scope { get; private set; }

        protected override void ProcessRecord()
        {
            if (this.Scope == AppScope.Tenant)
            {
                var tenantSettingsService = ClientObjectService.ServiceProvider.GetService<ITenantSettingsService>();
                var tenantSettings = tenantSettingsService.GetTenantSettings();
                this.WriteObject(tenantSettings.CorporateCatalogUrl);
            }
            if (this.Scope == AppScope.SiteCollection)
            {
                var siteCollectionAppCatalogService = ClientObjectService.ServiceProvider.GetService<ISiteCollectionAppCatalogService>();
                var siteCollectionAppCatalogs = siteCollectionAppCatalogService.FindSiteCollectionAppCatalogs();
                this.WriteObject(siteCollectionAppCatalogs.Select(item => item.AbsoluteUrl), true);
            }
        }

    }

}
