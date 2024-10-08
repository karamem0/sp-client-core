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
[ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.TenantSiteScriptSerializationResult", Id = "{71513b8b-a638-4407-81a5-3b3354c53848}")]
public class TenantSiteScriptSerializationResult : ClientValueObject
{

    public TenantSiteScriptSerializationResult()
    {
    }

    public TenantSiteScriptSerializationResult(IReadOnlyDictionary<string, object> parameters) : base(parameters)
    {
    }

    [JsonProperty("JSON")]
    public virtual string Json { get; protected set; }

    [JsonProperty()]
    public virtual string[] Warnings { get; protected set; }

}
