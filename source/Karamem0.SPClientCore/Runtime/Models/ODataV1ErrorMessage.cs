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
public class ODataV1ErrorMessage : ValueObject
{

    [JsonProperty("lang")]
    public string? Language { get; protected set; }

    [JsonProperty("value")]
    public string? Value { get; protected set; }

}
