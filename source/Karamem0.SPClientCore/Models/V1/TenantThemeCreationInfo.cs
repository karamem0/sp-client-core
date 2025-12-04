//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System.Collections;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[JsonObject()]
public class TenantThemeCreationInfo : ClientValueObject
{

    [JsonProperty("isInverted")]
    public virtual bool IsInverted { get; protected set; }

    [JsonProperty("name")]
    public virtual string? Name { get; protected set; }

    [JsonProperty("palette")]
    public virtual Hashtable? Palette { get; protected set; }

}
