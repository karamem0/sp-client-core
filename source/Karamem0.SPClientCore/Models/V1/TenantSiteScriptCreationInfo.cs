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
[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteScriptCreationInfo", Id = "{7cce1194-93c4-44a2-9a2a-92094fd345e5}")]
public class TenantSiteScriptCreationInfo : ClientValueObject
{

    public TenantSiteScriptCreationInfo()
    {
    }

    public TenantSiteScriptCreationInfo(IReadOnlyDictionary<string, object> parameters) : base(parameters)
    {
    }

    [JsonProperty()]
    public virtual string Content { get; protected set; }

    [JsonProperty()]
    public virtual System.IO.Stream ContentStream { get; protected set; }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual string Title { get; protected set; }

}
