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

namespace Karamem0.SharePoint.PowerShell.Models.Social
{

    [JsonObject(Id = "SP.Social.SocialPostActorInfo")]
    public class SocialPostActorInfo : ClientObject
    {

        public SocialPostActorInfo()
        {
        }

        [JsonProperty()]
        public bool? IncludesCurrentUser { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<int?> Indexes { get; private set; }

        [JsonProperty()]
        public int? TotalCount { get; private set; }

    }

}
