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

    [JsonObject(Id = "SP.WebCreationInformation")]
    public class WebCreationInformation : ClientObject
    {

        public WebCreationInformation()
        {
        }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public int? Language { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

        [JsonProperty()]
        public bool? UseSamePermissionsAsParentSite { get; private set; }

        [JsonProperty()]
        public string WebTemplate { get; private set; }

    }

}
