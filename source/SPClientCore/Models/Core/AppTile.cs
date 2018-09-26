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

    [JsonObject(Id = "SP.AppTile")]
    public class AppTile : ClientObject
    {

        public AppTile()
        {
        }


        [JsonProperty()]
        public Guid? AppId { get; private set; }

        [JsonProperty()]
        public string AppPrincipalId { get; private set; }

        [JsonProperty()]
        public AppSource? AppSource { get; private set; }

        [JsonProperty()]
        public AppStatus? AppStatus { get; private set; }

        [JsonProperty()]
        public AppType? AppType { get; private set; }

        [JsonProperty()]
        public string AssetId { get; private set; }

        [JsonProperty()]
        public int? BaseTemplate { get; private set; }

        [JsonProperty()]
        public int? ChildCount { get; private set; }

        [JsonProperty()]
        public string ContentMarket { get; private set; }

        [JsonProperty()]
        public string CustomSettingsUrl { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public bool? IsCorporateCatalogSite { get; private set; }

        [JsonProperty()]
        public string LastModified { get; private set; }

        [JsonProperty()]
        public DateTime? LastModifiedDate { get; private set; }

        [JsonProperty()]
        public Guid? ProductId { get; private set; }

        [JsonProperty()]
        public string Target { get; private set; }

        [JsonProperty()]
        public string Thumbnail { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string Version { get; private set; }

    }

}
