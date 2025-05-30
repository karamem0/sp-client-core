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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.DeletedSiteProperties", Id = "{550d568e-79ff-484b-b957-e08eb256e1dc}")]
[JsonObject()]
public class TenantDeletedSiteCollection : ClientObject
{

    [JsonProperty()]
    public virtual int DaysRemaining { get; protected set; }

    [JsonProperty()]
    public virtual DateTime DeletionTime { get; protected set; }

    [JsonProperty("SiteId")]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual string? Status { get; protected set; }

    [JsonProperty()]
    public virtual int StorageMaximumLevel { get; protected set; }

    [JsonProperty()]
    public virtual Uri? Url { get; protected set; }

    [JsonProperty()]
    public virtual int UserCodeMaximumLevel { get; protected set; }

}
