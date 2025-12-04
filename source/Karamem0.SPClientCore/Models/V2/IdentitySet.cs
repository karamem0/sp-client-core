//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V2;

[JsonObject()]
public class IdentitySet : ODataV2Object
{

    [JsonProperty("application")]
    public virtual Identity? Application { get; protected set; }

    [JsonProperty("device")]
    public virtual Identity? Device { get; protected set; }

    [JsonProperty("group")]
    public virtual Identity? Group { get; protected set; }

    [JsonProperty("user")]
    public virtual Identity? User { get; protected set; }

}
