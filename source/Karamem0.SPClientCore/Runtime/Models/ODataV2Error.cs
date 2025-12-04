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
public class ODataV2Error : ValueObject
{

    [JsonProperty("code")]
    public string? Code { get; protected set; }

    [JsonProperty("message")]
    public string? Message { get; protected set; }

}
