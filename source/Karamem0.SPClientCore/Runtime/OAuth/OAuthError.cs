//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

[JsonObject()]
public class OAuthError : OAuthMessage
{

    [JsonProperty("error")]
    public string? Error { get; protected set; }

    [JsonProperty("error_description")]
    public string? ErrorDescription { get; protected set; }

    [JsonProperty("error_codes")]
    public int[]? ErrorCodes { get; protected set; }

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; protected set; }

    [JsonProperty("trace_id")]
    public string? TraceId { get; protected set; }

    [JsonProperty("correlation_id")]
    public string? CorrelationId { get; protected set; }

}
