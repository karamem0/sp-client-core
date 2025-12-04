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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteScript", Id = "{717c203d-a629-47df-80bb-cdeda6592aa4}")]
[JsonObject()]
public class TenantSiteScript : ClientObject
{

    [JsonProperty()]
    public virtual string? Content { get; protected set; }

    [JsonProperty()]
    public virtual System.IO.Stream? ContentStream { get; protected set; }

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual bool IsSiteScriptPackage { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual int Version { get; protected set; }

}
