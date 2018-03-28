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

    [JsonObject(Id = "SP.Social.SocialRestActor")]
    public class SocialRestActor : ClientObject
    {

        public SocialRestActor()
        {
        }

        [JsonProperty()]
        public string FollowableItem { get; private set; }

        [JsonProperty()]
        public SocialActor FollowableItemActor { get; private set; }

        [JsonProperty()]
        public SocialActor Me { get; private set; }

    }

}
