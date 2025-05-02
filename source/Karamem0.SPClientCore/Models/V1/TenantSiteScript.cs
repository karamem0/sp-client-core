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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteScript", Id = "{717c203d-a629-47df-80bb-cdeda6592aa4}")]
[JsonObject()]
public class TenantSiteScript : ClientObject
{

    [JsonProperty()]
    public virtual string? Content { get; set; }

    [JsonProperty()]
    public virtual System.IO.Stream? ContentStream { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual bool IsSiteScriptPackage { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual int Version { get; set; }

}
