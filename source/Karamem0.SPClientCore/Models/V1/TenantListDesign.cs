//
// Copyright (c) 2018-2024 karamem0
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

[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantListDesign", Id = "{7ad6be34-0e98-49f3-84eb-0d0366f2c0b0}")]
[JsonObject()]
public class TenantListDesign : ClientObject
{

    public TenantListDesign()
    {
    }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual TenantTemplateDesignType DesignType { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual TenantListDesignColor ListColor { get; protected set; }

    [JsonProperty()]
    public virtual TenantListDesignIcon ListIcon { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Guid> SiteScriptIds { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> TemplateFeatures { get; protected set; }

    [JsonProperty()]
    public virtual string ThumbnailUrl { get; protected set; }

    [JsonProperty()]
    public virtual string Title { get; protected set; }

    [JsonProperty()]
    public virtual int Version { get; protected set; }

}
