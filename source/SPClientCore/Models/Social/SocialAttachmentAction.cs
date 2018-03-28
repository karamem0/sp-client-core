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

    [JsonObject(Id = "SP.Social.SocialAttachmentAction")]
    public class SocialAttachmentAction : ClientObject
    {

        public SocialAttachmentAction()
        {
        }

        [JsonProperty()]
        public SocialAttachmentActionKind? ActionKind { get; private set; }

        [JsonProperty("ActionUri")]
        public string ActionUrl { get; private set; }

    }

}
