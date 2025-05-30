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

[ClientObject(Name = "SP.FileDeleteParameters", Id = "{7faa52e2-2ea9-48c0-b211-f929e55f82bf}")]
[JsonObject()]
public class FileDeleteParameters : ClientValueObject
{

    [JsonProperty()]
    public virtual bool BypassSharedLock { get; protected set; }

    [JsonProperty()]
    public virtual string? ETagMatch { get; protected set; }

}
