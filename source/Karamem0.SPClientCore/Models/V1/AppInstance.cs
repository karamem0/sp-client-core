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

[ClientObject(Name = "SP.AppInstance", Id = "{211a55df-058b-4917-ac93-2b5e08b1a9fd}")]
[JsonObject()]
public class AppInstance : ClientObject
{

    [JsonProperty()]
    public virtual string? AppPrincipalId { get; set; }

    [JsonProperty()]
    public virtual string? AppWebFullUrl { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual string? ImageFallbackUrl { get; set; }

    [JsonProperty()]
    public virtual string? ImageUrl { get; set; }

    [JsonProperty()]
    public virtual bool InError { get; set; }

    [JsonProperty()]
    public virtual byte[]? PackageFingerprint { get; set; }

    [JsonProperty()]
    public virtual Guid ProductId { get; set; }

    [JsonProperty()]
    public virtual string? RemoteAppUrl { get; set; }

    [JsonProperty()]
    public virtual string? SettingsPageUrl { get; set; }

    [JsonProperty("SiteId")]
    public virtual Guid SiteCollectionId { get; set; }

    [JsonProperty()]
    public virtual string? StartPage { get; set; }

    [JsonProperty()]
    public virtual AppStatus? Status { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty("WebId")]
    public virtual Guid SiteId { get; set; }

}
