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

[JsonObject()]
[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteScriptCreationInfo", Id = "{7cce1194-93c4-44a2-9a2a-92094fd345e5}")]
public class TenantSiteScriptCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Content { get; protected set; }

    [JsonProperty()]
    public virtual System.IO.Stream? ContentStream { get; protected set; }

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
