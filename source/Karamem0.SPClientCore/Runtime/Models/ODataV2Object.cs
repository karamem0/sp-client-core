//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV2Object : ODataObject
{

    public ODataV2Object()
    {
    }

    [JsonProperty("@odata.context")]
    public string ODataContext { get; private set; }

    [JsonProperty("@odata.type")]
    public string ODataType { get; private set; }

    [JsonProperty("@odata.id")]
    public string ODataId { get; private set; }

}
