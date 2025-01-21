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

[ClientObject(Name = "SP.RoleDefinition", Id = "{aa7ecb4a-9c7e-4ad9-bd20-58a2775e5ad7}")]
[JsonObject()]
public class RoleDefinition : ClientObject
{

    public RoleDefinition()
    {
    }

    [JsonProperty("BasePermissions")]
    public virtual BasePermission BasePermission { get; protected set; }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual bool Hidden { get; protected set; }

    [JsonProperty()]
    public virtual int Id { get; protected set; }

    [JsonProperty()]
    public virtual string Name { get; protected set; }

    [JsonProperty()]
    public virtual int Order { get; protected set; }

    [JsonProperty()]
    public virtual RoleTypeKind RoleTypeKind { get; protected set; }

}
