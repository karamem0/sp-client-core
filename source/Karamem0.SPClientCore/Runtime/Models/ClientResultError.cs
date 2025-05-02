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

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ClientResultError
{

    [JsonProperty()]
    public string? ErrorMessage { get; protected set; }

    [JsonProperty()]
    public string? ErrorValue { get; protected set; }

    [JsonProperty()]
    public string? TraceCorrelationId { get; protected set; }

    [JsonProperty()]
    public int ErrorCode { get; protected set; }

    [JsonProperty()]
    public string? ErrorTypeName { get; protected set; }

}
