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

[ClientObject(Name = "SP.User", Id = "{ae70d2a4-ec46-4ed9-9b1e-9d0245754463}")]
[JsonObject()]
public class User : Principal
{

    [JsonProperty()]
    public virtual string? Email { get; protected set; }

    [JsonProperty()]
    public virtual string? Expiration { get; protected set; }

    [JsonProperty()]
    public override int Id { get; protected set; }

    [JsonProperty()]
    public virtual bool IsEmailAuthenticationGuestUser { get; protected set; }

    [JsonProperty()]
    public virtual bool IsHiddenInUI { get; protected set; }

    [JsonProperty()]
    public virtual bool IsShareByEmailGuestUser { get; protected set; }

    [JsonProperty("IsSiteAdmin")]
    public virtual bool IsSiteCollectionAdmin { get; protected set; }

    [JsonProperty()]
    public override string? LoginName { get; protected set; }

    [JsonProperty()]
    public override PrincipalType PrincipalType { get; protected set; }

    [JsonProperty()]
    public override string? Title { get; protected set; }

    [JsonProperty()]
    public virtual UserIdInfo? UserId { get; protected set; }

    [JsonProperty()]
    public virtual string? UserPrincipalName { get; protected set; }

}
