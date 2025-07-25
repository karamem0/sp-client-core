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

[ClientObject(Name = "SP.Sharing.UserRoleAssignment", Id = "{74485063-e2b5-424b-950c-4b62e816e31f}")]
[JsonObject()]
public class UserRoleAssignment(string? userId = null, RoleType role = RoleType.None) : ClientValueObject
{
    [JsonProperty()]
    public virtual RoleType Role { get; protected set; } = role;

    [JsonProperty()]
    public virtual string? UserId { get; protected set; } = userId;

}
