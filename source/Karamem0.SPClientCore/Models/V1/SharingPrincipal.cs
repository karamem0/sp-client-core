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

[JsonObject()]
public class SharingPrincipal : ODataV1Object
{

    [JsonProperty("email")]
    public virtual string? Email { get; set; }

    [JsonProperty("expiration")]
    public virtual string? Expiration { get; set; }

    [JsonProperty("id")]
    public virtual int Id { get; set; }

    [JsonProperty("isActive")]
    public virtual bool IsActive { get; set; }

    [JsonProperty("isExternal")]
    public virtual bool IsExternal { get; set; }

    [JsonProperty("jobTitle")]
    public virtual string? JobTitle { get; set; }

    [JsonProperty("loginName")]
    public virtual string? LoginName { get; set; }

    [JsonProperty("name")]
    public virtual string? Name { get; set; }

    [JsonProperty("principalType")]
    public virtual PrincipalType? PrincipalType { get; set; }

    [JsonProperty("userId")]
    public virtual string? UserId { get; set; }

    [JsonProperty("userPrincipalName")]
    public virtual string? UserPrincipalName { get; set; }

}
