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

    [JsonObject(Id = "SP.Social.SocialThread")]
    public class SocialThread : ClientObject
    {

        public SocialThread()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<SocialActor> Actors { get; private set; }

        [JsonProperty()]
        public SocialThreadAttributes? Attributes { get; private set; }

        [JsonProperty()]
        public string Id { get; private set; }

        [JsonProperty()]
        public int? OwnerIndex { get; private set; }

        [JsonProperty()]
        public string Permalink { get; private set; }

        [JsonProperty()]
        public SocialPostReference PostReference { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<SocialPost> Replies { get; private set; }

        [JsonProperty()]
        public SocialPost RootPost { get; private set; }

        [JsonProperty()]
        public SocialStatusCode? Status { get; private set; }

        [JsonProperty()]
        public SocialThreadType? ThreadType { get; private set; }

        [JsonProperty()]
        public int? TotalReplyCount { get; private set; }

    }

}
