//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV2Object : ODataObject
{

    [JsonProperty("@odata.context")]
    public string? ODataContext { get; protected set; }

    [JsonProperty("@odata.type")]
    public string? ODataType { get; protected set; }

    [JsonProperty("@odata.id")]
    public string? ODataId { get; protected set; }

}
