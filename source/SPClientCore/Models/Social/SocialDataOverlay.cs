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

    [JsonObject(Id = "SP.Social.SocialDataOverlay")]
    public class SocialDataOverlay : ClientObject
    {

        public SocialDataOverlay()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<int?> ActorIndexes { get; private set; }

        [JsonProperty()]
        public int? Index { get; private set; }

        [JsonProperty()]
        public int? Length { get; private set; }

        [JsonProperty("LinkUri")]
        public string LinkUrl { get; private set; }

        [JsonProperty()]
        public SocialDataOverlayType? OverlayType { get; private set; }

    }

}
