//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject()]
    public class App : ODataObject
    {

        public App()
        {
        }

        [JsonProperty()]
        public virtual string AadAppId { get; protected set; }

        [JsonProperty()]
        public virtual string AadPermissions { get; protected set; }

        [JsonProperty()]
        public virtual string AppCatalogVersion { get; protected set; }

        [JsonProperty()]
        public virtual bool CanUpgrade { get; protected set; }

        [JsonProperty()]
        public virtual string CDNLocation { get; protected set; }

        [JsonProperty()]
        public virtual bool CurrentVersionDeployed { get; protected set; }

        [JsonProperty()]
        public virtual bool Deployed { get; protected set; }

        [JsonProperty()]
        public virtual Guid Id { get; protected set; }

        [JsonProperty()]
        public virtual bool IsEnabled { get; protected set; }

        [JsonProperty()]
        public virtual string InstalledVersion { get; protected set; }

        [JsonProperty()]
        public virtual bool IsClientSideSolution { get; protected set; }

        [JsonProperty()]
        public virtual string ProductId { get; protected set; }

        [JsonProperty()]
        public virtual string ShortDescription { get; protected set; }

        [JsonProperty()]
        public virtual bool SkipDeploymentFeature { get; protected set; }

        [JsonProperty()]
        public virtual string Title { get; protected set; }

        [JsonProperty()]
        public virtual string ThumbnailUrl { get; protected set; }

    }

}
