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

[ClientObject(Name = "SP.SPResourceEntry", Id = "{376ca521-1f79-4e53-b4b9-9ea9f24bb844}")]
[JsonObject()]
public class ResourceEntry(uint lcid = 0, string? value = null) : ClientValueObject
{

    [JsonProperty("LCID")]
    public virtual uint Lcid { get; protected set; } = lcid;

    [JsonProperty()]
    public virtual string? Value { get; protected set; } = value;

}
