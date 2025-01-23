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

[ClientObject(
    Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteDesign",
    Id = "{27e34aef-e54f-43d2-891e-ddc1faacb2d9}"
)]
[JsonObject()]
public class TenantSiteDesign : ClientObject
{

    public TenantSiteDesign()
    {
    }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual Guid DesignPackageId { get; protected set; }

    [JsonProperty()]
    public virtual TenantTemplateDesignType DesignType { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual bool IsDefault { get; protected set; }

    [JsonProperty()]
    public virtual string PreviewImageAltText { get; protected set; }

    [JsonProperty()]
    public virtual string PreviewImageUrl { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> SiteScriptIds { get; protected set; }

    [JsonProperty("WebTemplate")]
    public virtual string SiteTemplate { get; protected set; }

    [JsonProperty()]
    public virtual string ThumbnailUrl { get; protected set; }

    [JsonProperty()]
    public virtual string Title { get; protected set; }

    [JsonProperty()]
    public virtual int Version { get; protected set; }

}
