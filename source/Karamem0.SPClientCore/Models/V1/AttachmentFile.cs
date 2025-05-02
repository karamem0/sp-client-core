//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.Attachment", Id = "{abd102de-1731-4be2-ae7e-3515371cc5c7}")]
[JsonObject()]
public class AttachmentFile : ClientObject
{

    [JsonProperty()]
    public virtual string? FileName { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? FileNameAsPath { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? ServerRelativePath { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

}
