//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.Attachment", Id = "{abd102de-1731-4be2-ae7e-3515371cc5c7}")]
    [JsonObject()]
    public class AttachmentFile : ClientObject
    {

        public AttachmentFile()
        {
        }

        [JsonProperty()]
        public string FileName { get; private set; }

        [JsonProperty()]
        public ResourcePath FileNameAsPath { get; private set; }

        [JsonProperty()]
        public ResourcePath ServerRelativePath { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

    }

}
