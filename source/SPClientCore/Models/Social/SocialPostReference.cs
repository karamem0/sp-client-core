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

    [JsonObject(Id = "SP.Social.SocialPostReference")]
    public class SocialPostReference : ClientObject
    {

        public SocialPostReference()
        {
        }

        [JsonProperty()]
        public SocialThread Digest { get; private set; }

        [JsonProperty()]
        public SocialPost Post { get; private set; }

        [JsonProperty()]
        public string ThreadId { get; private set; }

        [JsonProperty()]
        public int? ThreadOwnerIndex { get; private set; }

    }

}
