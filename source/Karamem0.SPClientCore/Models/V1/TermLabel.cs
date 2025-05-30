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

[ClientObject(Name = "SP.Taxonomy.Label", Id = "{81503ae1-8747-4684-a172-163c7e009ef9}")]
[JsonObject()]
public class TermLabel : ClientObject
{

    [JsonProperty("IsDefaultForLanguage")]
    public virtual bool IsDefault { get; protected set; }

    [JsonProperty("Language")]
    public virtual uint Lcid { get; protected set; }

    [JsonProperty("Value")]
    public virtual string? Name { get; protected set; }

}
