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
    public virtual string? AppPrincipalId { get; protected set; }

    [JsonProperty()]
    public virtual Uri? AppWebFullUrl { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual Uri? ImageFallbackUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? ImageUrl { get; protected set; }

    [JsonProperty()]
    public virtual bool InError { get; protected set; }

    [JsonProperty()]
    public virtual byte[]? PackageFingerprint { get; protected set; }

    [JsonProperty()]
    public virtual Guid ProductId { get; protected set; }

    [JsonProperty()]
    public virtual Uri? RemoteAppUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? SettingsPageUrl { get; protected set; }

    [JsonProperty("SiteId")]
    public virtual Guid SiteCollectionId { get; protected set; }

    [JsonProperty()]
    public virtual string? StartPage { get; protected set; }

    [JsonProperty()]
    public virtual AppStatus Status { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty("WebId")]
    public virtual Guid SiteId { get; protected set; }

}
