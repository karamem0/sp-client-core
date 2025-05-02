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

[ClientObject(Name = "SP.RoleDefinitionCreationInformation", Id = "{59eddf82-1018-4677-8067-69e16efd3495}")]
[JsonObject()]
public class RoleDefinitionCreationInfo : ClientValueObject
{

    [JsonProperty("BasePermissions")]
    public virtual BasePermission? BasePermission { get; protected set; }

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

    [JsonProperty()]
    public virtual int Order { get; protected set; }

}
