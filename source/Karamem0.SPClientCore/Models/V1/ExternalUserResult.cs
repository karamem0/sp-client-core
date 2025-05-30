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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantManagement.GetExternalUsersResults", Id = "{44d1d638-1204-4f42-98a6-85fdc13bdcf1}")]
[JsonObject()]
public class ExternalUserResult : ClientObject
{

    [JsonProperty("ExternalUserCollection")]
    public virtual ExternalUserEnumerable? ExternalUsers { get; protected set; }

    [JsonProperty("TotalUserCount")]
    public virtual int TotalCount { get; protected set; }

    [JsonProperty("UserCollectionPosition")]
    public virtual int Position { get; protected set; }

}
