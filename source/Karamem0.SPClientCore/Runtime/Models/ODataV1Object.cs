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
public class ODataV1Object : ODataObject
{

    public ODataV1Object()
    {
        this.Metadata = ODataV1Metadata.Create(this.GetType());
    }

    [JsonProperty("__deferred")]
    public ODataV1Deferred Deferred { get; private set; }

    [JsonProperty("__metadata")]
    public ODataV1Metadata Metadata { get; private set; }

}
