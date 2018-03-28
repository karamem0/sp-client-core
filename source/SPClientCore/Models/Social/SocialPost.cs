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

    [JsonObject(Id = "SP.Social.SocialPost")]
    public class SocialPost : ClientObject
    {

        public SocialPost()
        {
        }

        [JsonProperty()]
        public SocialAttachment Attachment { get; private set; }

        [JsonProperty()]
        public SocialPostAttributes Attributes { get; private set; }

        [JsonProperty()]
        public int? AuthorIndex { get; private set; }

        [JsonProperty()]
        public DateTime? CreatedTime { get; private set; }

        [JsonProperty()]
        public string Id { get; private set; }

        [JsonProperty()]
        public SocialPostActorInfo LikerInfo { get; private set; }

        [JsonProperty()]
        public DateTime? ModifiedTime { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<SocialDataOverlay> Overlays { get; private set; }

        [JsonProperty()]
        public SocialPostTyoe? PostType { get; private set; }

        [JsonProperty("PreferredImageUri")]
        public string PreferredImageUrl { get; private set; }

        [JsonProperty()]
        public SocialLink Source { get; private set; }

        [JsonProperty()]
        public string Text { get; private set; }

    }

}
