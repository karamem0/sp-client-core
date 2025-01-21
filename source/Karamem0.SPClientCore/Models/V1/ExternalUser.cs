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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantManagement.ExternalUser", Id = "{22a8d517-a1e7-4755-ab3f-3743e3a8f682}")]
[JsonObject()]
public class ExternalUser : ClientObject
{

    public ExternalUser()
    {
    }

    [JsonProperty()]
    public virtual string AcceptedAs { get; protected set; }

    [JsonProperty()]
    public virtual string DisplayName { get; protected set; }

    [JsonProperty()]
    public virtual string InvitedAs { get; protected set; }

    [JsonProperty()]
    public virtual string InvitedBy { get; protected set; }

    [JsonProperty()]
    public virtual bool IsCrossTenant { get; protected set; }

    [JsonProperty()]
    public virtual string LoginName { get; protected set; }

    [JsonProperty()]
    public virtual string UniqueId { get; protected set; }

    [JsonProperty()]
    public virtual int UserId { get; protected set; }

    [JsonProperty()]
    public virtual DateTime WhenCreated { get; protected set; }

}
