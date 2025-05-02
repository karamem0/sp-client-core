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
public class App : ODataV1Object
{

    [JsonProperty()]
    public virtual Guid AadAppId { get; set; }

    [JsonProperty()]
    public virtual string? AadPermissions { get; set; }

    [JsonProperty()]
    public virtual string? AppCatalogVersion { get; set; }

    [JsonProperty()]
    public virtual bool CanUpgrade { get; set; }

    [JsonProperty()]
    public virtual bool ContainsTenantWideExtension { get; set; }

    [JsonProperty("CDNLocation")]
    public virtual string? CdnLocation { get; set; }

    [JsonProperty()]
    public virtual bool CurrentVersionDeployed { get; set; }

    [JsonProperty()]
    public virtual bool Deployed { get; set; }

    [JsonProperty()]
    public virtual string? ErrorMessage { get; set; }

    [JsonProperty("ID")]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual string? InstalledVersion { get; set; }

    [JsonProperty()]
    public virtual bool IsEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IsClientSideSolution { get; set; }

    [JsonProperty()]
    public virtual bool IsPackageDefaultSkipFeatureDeployment { get; set; }

    [JsonProperty()]
    public virtual bool IsValidAppPackage { get; set; }

    [JsonProperty()]
    public virtual Guid ProductId { get; set; }

    [JsonProperty()]
    public virtual string? ShortDescription { get; set; }

    [JsonProperty()]
    public virtual bool SkipDeploymentFeature { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual string? ThumbnailUrl { get; set; }

}
