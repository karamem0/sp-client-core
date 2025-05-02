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
[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteDesignCreationInfo", Id = "{52bd24b0-327a-4fb4-8323-783645e48cf0}")]
public class TenantSiteDesignCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual Guid DesignPackageId { get; set; }

    [JsonProperty()]
    public virtual bool IsDefault { get; set; }

    [JsonProperty()]
    public virtual string? PreviewImageAltText { get; set; }

    [JsonProperty()]
    public virtual string? PreviewImageUrl { get; set; }

    [JsonProperty()]
    public virtual string[]? SiteScriptIds { get; set; }

    [JsonProperty("WebTemplate")]
    public virtual string? SiteTemplate { get; set; }

    [JsonProperty()]
    public virtual string? ThumbnailUrl { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

}
