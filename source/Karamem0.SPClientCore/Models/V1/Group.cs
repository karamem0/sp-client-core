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

[ClientObject(Name = "SP.Group", Id = "{e54ad5f1-ce4e-453b-b7f7-aea6556c9c40}")]
[JsonObject()]
public class Group : Principal
{

    [JsonProperty()]
    public virtual bool AllowMembersEditMembership { get; set; }

    [JsonProperty()]
    public virtual bool AllowRequestToJoinLeave { get; set; }

    [JsonProperty()]
    public virtual bool AutoAcceptRequestToJoinLeave { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserEditMembership { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageGroup { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserViewMembership { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public override int Id { get; set; }

    [JsonProperty()]
    public virtual bool IsHiddenInUI { get; set; }

    [JsonProperty()]
    public override string? LoginName { get; set; }

    [JsonProperty()]
    public virtual string? OwnerTitle { get; set; }

    [JsonProperty()]
    public virtual bool OnlyAllowMembersViewMembership { get; set; }

    [JsonProperty()]
    public override PrincipalType? PrincipalType { get; set; }

    [JsonProperty()]
    public virtual string? RequestToJoinLeaveEmailSetting { get; set; }

    [JsonProperty()]
    public override string? Title { get; set; }

}
