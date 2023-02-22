//
// Copyright (c) 2023 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V2
{

    [JsonObject()]
    public class SharePointIds : ODataV2Object
    {

        public SharePointIds()
        {
        }

        [JsonProperty("listId")]
        public virtual string ListId { get; protected set; }

        [JsonProperty("listItemId")]
        public virtual string ListItemId { get; protected set; }

        [JsonProperty("listItemUniqueId")]
        public virtual string ListItemUniqueId { get; protected set; }

        [JsonProperty("siteId")]
        public virtual string SiteCollectionId { get; protected set; }

        [JsonProperty("siteUrl")]
        public virtual string SiteCollectionUrl { get; protected set; }

        [JsonProperty("webId")]
        public virtual string SiteId { get; protected set; }

        [JsonProperty("tenantId")]
        public virtual string TenantId { get; protected set; }

    }

}
