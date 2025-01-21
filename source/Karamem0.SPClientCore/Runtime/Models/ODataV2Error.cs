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
public class ODataV2Error : ValueObject
{

    public ODataV2Error()
    {
    }

    [JsonProperty("code")]
    public string Code { get; private set; }

    [JsonProperty("message")]
    public string Message { get; private set; }

}
