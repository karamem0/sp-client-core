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

[ClientObject(Name = "SP.ObjectSharingInformation", Id = "{e7dae9f6-8ca5-4286-92c8-61941d774c44}")]
[JsonObject()]
public class SharingInfo : ClientObject
{

    [JsonProperty()]
    public virtual string? AnonymousEditLink { get; set; }

    [JsonProperty()]
    public virtual string? AnonymousViewLink { get; set; }

    [JsonProperty()]
    public virtual bool CanBeShared { get; set; }

    [JsonProperty()]
    public virtual bool CanBeUnshared { get; set; }

    [JsonProperty()]
    public virtual bool CanManagePermissions { get; set; }

    [JsonProperty()]
    public virtual bool HasPendingAccessRequests { get; set; }

    [JsonProperty()]
    public virtual bool HasPermissionLevels { get; set; }

    [JsonProperty()]
    public virtual bool IsFolder { get; set; }

    [JsonProperty()]
    public virtual bool IsSharedWithCurrentUser { get; set; }

    [JsonProperty()]
    public virtual bool IsSharedWithGuest { get; set; }

    [JsonProperty()]
    public virtual bool IsSharedWithMany { get; set; }

    [JsonProperty()]
    public virtual bool IsSharedWithSecurityGroup { get; set; }

    [JsonProperty()]
    public virtual string? PendingAccessRequestsLink { get; set; }

    [JsonProperty("SharedWithUsersCollection")]
    public virtual SharingInfoUserEnumerable? SharedWithUsers { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<SharingLinkInfo>? SharingLinks { get; set; }

    [JsonProperty()]
    public virtual int TotalFileCount { get; set; }

}
