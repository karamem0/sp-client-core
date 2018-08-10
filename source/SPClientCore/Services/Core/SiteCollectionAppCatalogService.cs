//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface ISiteCollectionAppCatalogService
    {

        IEnumerable<SiteCollectionAppCatalogAllowedItem> FindSiteCollectionAppCatalogs(string siteCollectionAppCatalogQuery = null);

    }

    public class SiteCollectionAppCatalogService : ClientObjectService, ISiteCollectionAppCatalogService
    {

        public SiteCollectionAppCatalogService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<SiteCollectionAppCatalogAllowedItem> FindSiteCollectionAppCatalogs(string siteCollectionAppCatalogQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/sitecollectionappcatalogssites")
                .ConcatQuery(siteCollectionAppCatalogQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<SiteCollectionAppCatalogAllowedItem>>(requestUrl);
        }

    }

}
