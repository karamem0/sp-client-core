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

    [Cmdlet("Remove", "SPCatalogApp")]
    [OutputType(typeof(void))]
    public class RemoveCatalogAppCommand : PSCmdlet
    {

        public RemoveCatalogAppCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public CatalogAppPipeBind CatalogApp { get; private set; }

        [Parameter(Mandatory = false)]
        public CatalogAppScope Scope { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var catalogAppService = ClientObjectService.ServiceProvider.GetService<ICatalogAppService>();
            if (this.Scope == CatalogAppScope.Tenant)
            {
               catalogAppService.RemoveTenantCatalogApp(this.CatalogApp);
            }
            if (this.Scope == CatalogAppScope.Site)
            {
                catalogAppService.RemoveSiteCatalogApp(this.CatalogApp);
            }
        }

    }

}
