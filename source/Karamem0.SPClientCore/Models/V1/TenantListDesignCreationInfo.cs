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

[JsonObject()]
[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantListDesignCreationInfo", Id = "{4039ef3a-3ca7-4ce2-8164-e52b1215bc79}")]
public class TenantListDesignCreationInfo : ClientValueObject
{

    public TenantListDesignCreationInfo()
    {
    }

    public TenantListDesignCreationInfo(IReadOnlyDictionary<string, object> parameters) : base(parameters)
    {
    }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual TenantListDesignColor ListColor { get; protected set; }

    [JsonProperty()]
    public virtual TenantListDesignIcon ListIcon { get; protected set; }

    [JsonProperty()]
    public virtual Guid[] SiteScriptIds { get; protected set; }

    [JsonProperty()]
    public virtual string[] TemplateFeatures { get; protected set; }

    [JsonProperty()]
    public virtual string ThumbnailUrl { get; protected set; }

    [JsonProperty()]
    public virtual string Title { get; protected set; }

}
