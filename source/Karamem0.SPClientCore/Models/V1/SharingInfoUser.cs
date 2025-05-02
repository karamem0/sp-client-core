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

[ClientObject(Name = "SP.ObjectSharingInformationUser", Id = "{f7b7fe66-58a7-4843-882d-99af0d97992b}")]
[JsonObject()]
public class SharingInforUser : ClientObject
{

    [JsonProperty()]
    public virtual string? CustomRoleNames { get; set; }

    [JsonProperty()]
    public virtual string? Department { get; set; }

    [JsonProperty()]
    public virtual string? Email { get; set; }

    [JsonProperty()]
    public virtual bool HasEditPermission { get; set; }

    [JsonProperty()]
    public virtual bool HasReviewPermission { get; set; }

    [JsonProperty()]
    public virtual bool HasViewPermission { get; set; }

    [JsonProperty()]
    public virtual int Id { get; set; }

    [JsonProperty()]
    public virtual bool IsDomainGroup { get; set; }

    [JsonProperty()]
    public virtual bool IsExternalUser { get; set; }

    [JsonProperty()]
    public virtual bool IsMemberOfGroup { get; set; }

    [JsonProperty()]
    public virtual bool IsSiteAdmin { get; set; }

    [JsonProperty()]
    public virtual string? JobTitle { get; set; }

    [JsonProperty()]
    public virtual string? LoginName { get; set; }

    [JsonProperty()]
    public virtual string? Name { get; set; }

    [JsonProperty()]
    public virtual string? Picture { get; set; }

    [JsonProperty()]
    public virtual Principal? Principal { get; set; }

    [JsonProperty()]
    public virtual string? SipAddress { get; set; }

    [JsonProperty()]
    public virtual User? User { get; set; }

}
