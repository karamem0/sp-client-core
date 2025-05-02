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

[ClientObject(Name = "SP.NavigationNodeCreationInformation", Id = "{7aaaa605-79a9-4fda-ae1e-db952e5083e0}")]
[JsonObject()]
public class NavigationNodeCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual bool AsLastNode { get; protected set; }

    [JsonProperty()]
    public virtual bool IsExternal { get; protected set; }

    [JsonProperty()]
    public virtual NavigationNode? PreviousNode { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual string? Url { get; protected set; }

}
