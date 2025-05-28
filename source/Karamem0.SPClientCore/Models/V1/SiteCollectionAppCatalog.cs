//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(
    Name = "Microsoft.SharePoint.Marketplace.CorporateCuratedGallery.SiteCollectionAppCatalogAllowedItem",
    Id = "{9ff9bee6-14bf-490a-adb3-6897e9bd592e}"
)]
[JsonObject()]
public class SiteCollectionAppCatalog : ClientObject
{

    [JsonProperty()]
    public virtual Uri? AbsoluteUrl { get; protected set; }

    [JsonProperty("SiteID")]
    public virtual Guid SiteCollectionId { get; protected set; }

}
