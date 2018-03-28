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

    [JsonObject(Id = "SP.Social.SocialAttachment")]
    public class SocialAttachment
    {

        public SocialAttachment()
        {
        }

        [JsonProperty()]
        public SocialAttachmentKind? AttachmentKind { get; private set; }

        [JsonProperty()]
        public SocialAttachmentAction ClickAction { get; private set; }

        [JsonProperty("ContentUri")]
        public string ContentUrl { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public int? Height { get; private set; }

        [JsonProperty()]
        public int? Length { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty("PreviewUri")]
        public string PreviewUrl { get; private set; }

        [JsonProperty("Uri")]
        public string Url { get; private set; }

        [JsonProperty()]
        public int? Width { get; private set; }

    }

}
