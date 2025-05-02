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

[ClientObject(Name = "SP.HubSiteCreationInformation", Id = "{3e543825-fbf3-483a-be67-55a70dd9b992}")]
[JsonObject()]
public class HubSiteCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual bool EnablePermissionsSync { get; set; }

    [JsonProperty()]
    public virtual bool HideNameInNavigation { get; set; }

    [JsonProperty()]
    public virtual string? LogoUrl { get; set; }

    [JsonProperty()]
    public virtual Guid ParentHubSiteId { get; set; }

    [JsonProperty("SiteId")]
    public virtual Guid SiteCollectionId { get; set; }

    [JsonProperty("SiteUrl")]
    public virtual string? SiteCollectionUrl { get; set; }

    [JsonProperty()]
    public virtual string? Targets { get; set; }

    [JsonProperty()]
    public virtual Guid TenantInstanceId { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

}
