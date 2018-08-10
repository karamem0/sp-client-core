//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "Microsoft.SharePoint.Marketplace.CorporateCuratedGallery.TenantCorporateCatalogAccessor")]
    public class TenantCorporateCatalogAccessor : ClientObject
    {

        public TenantCorporateCatalogAccessor()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<CorporateCatalogAppMetadata> AvailableApps { get; private set; }

        [JsonProperty(PropertyName = "SiteCollectionAppCatalogsSites")]
        public ClientObjectCollection<SiteCollectionAppCatalogAllowedItem> SiteCollectionAppCatalogsSites { get; private set; }

    }

}
