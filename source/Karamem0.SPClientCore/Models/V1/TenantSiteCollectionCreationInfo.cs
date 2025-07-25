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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.SiteCreationProperties", Id = "{11f84fff-b8cf-47b6-8b50-34e692656606}")]
[JsonObject()]
public class TenantSiteCollectionCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual int CompatibilityLevel { get; protected set; }

    [JsonProperty()]
    public virtual uint Lcid { get; protected set; }

    [JsonProperty()]
    public virtual string? Owner { get; protected set; }

    [JsonProperty("StorageMaximumLevel")]
    public virtual long StorageMaxLevel { get; protected set; }

    [JsonProperty()]
    public virtual long StorageWarningLevel { get; protected set; }

    [JsonProperty()]
    public virtual string? Template { get; protected set; }

    [JsonProperty()]
    public virtual int TimeZoneId { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual Uri? Url { get; protected set; }

    [JsonProperty("UserCodeMaximumLevel")]
    public virtual double UserCodeMaxLevel { get; protected set; }

    [JsonProperty()]
    public virtual double UserCodeWarningLevel { get; protected set; }

}
