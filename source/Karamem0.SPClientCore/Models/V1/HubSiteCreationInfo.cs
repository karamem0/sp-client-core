//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.HubSiteCreationInformation", Id = "{3e543825-fbf3-483a-be67-55a70dd9b992}")]
[JsonObject()]
public class HubSiteCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual bool EnablePermissionsSync { get; protected set; }

    [JsonProperty()]
    public virtual bool HideNameInNavigation { get; protected set; }

    [JsonProperty()]
    public virtual Uri? LogoUrl { get; protected set; }

    [JsonProperty()]
    public virtual Guid ParentHubSiteId { get; protected set; }

    [JsonProperty("SiteId")]
    public virtual Guid SiteCollectionId { get; protected set; }

    [JsonProperty("SiteUrl")]
    public virtual Uri? SiteCollectionUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? Targets { get; protected set; }

    [JsonProperty()]
    public virtual Guid TenantInstanceId { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
