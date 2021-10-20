//
// Copyright (c) 2021 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataV1ErrorMessage
    {

        public ODataV1ErrorMessage()
        {
        }

        [JsonProperty("lang")]
        public string Language { get; private set; }

        [JsonProperty("value")]
        public string Value { get; private set; }

    }

}
