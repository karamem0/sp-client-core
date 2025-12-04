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

[ClientObject(Name = "SP.Utilities.SpotlightResult", Id = "{49DC00D0-6338-4C4D-8827-2D82A867CD44}")]
[JsonObject()]
public class HighlightResult : ClientObject
{

    [JsonProperty()]
    public virtual IReadOnlyCollection<int>? Order { get; protected set; }

    [JsonProperty()]
    public virtual HighlightResultCode ResultCode { get; protected set; }

}
