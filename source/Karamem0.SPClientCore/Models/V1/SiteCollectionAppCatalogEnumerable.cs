//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(
    Name = "Microsoft.SharePoint.Marketplace.CorporateCuratedGallery.SiteCollectionAppCatalogAllowedCollection",
    Id = "{e6a14f02-4a7b-4bd2-b869-23a0a63283db}"
)]
[JsonObject()]
public class SiteCollectionAppCatalogEnumerable : ClientObjectEnumerable<SiteCollectionAppCatalog>;
