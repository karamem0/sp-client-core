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

    [JsonObject(Id = "SP.Social.SocialFeed")]
    public class SocialFeed : ClientObject
    {

        public SocialFeed()
        {
        }

        [JsonProperty()]
        public SocialFeedAttributes Attributes { get; private set; }

        [JsonProperty()]
        public DateTime? NewestProcessed { get; private set; }

        [JsonProperty()]
        public DateTime? OldestProcessed { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<SocialThread> Threads { get; private set; }

        [JsonProperty()]
        public int? UnreadMentionCount { get; private set; }

    }

}
