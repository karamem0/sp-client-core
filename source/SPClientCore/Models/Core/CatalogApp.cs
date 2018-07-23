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

    [JsonObject()]
    public class CatalogApp : ClientObject
    {

        public CatalogApp()
        {
        }

        [JsonProperty()]
        public string AppCatalogVersion { get; private set; }

        [JsonProperty()]
        public bool? CanUpgrade { get; private set; }

        [JsonProperty()]
        public bool? CurrentVersionDeployed { get; private set; }

        [JsonProperty()]
        public bool? Deployed { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public string InstalledVersion { get; private set; }

        [JsonProperty()]
        public bool? IsClientSideSolution { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

    }

}
