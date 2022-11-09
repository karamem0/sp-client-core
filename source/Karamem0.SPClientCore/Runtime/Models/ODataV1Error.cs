//
// Copyright (c) 2022 karamem0
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
    public class ODataV1Error
    {

        public ODataV1Error()
        {
        }

        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("message")]
        public ODataV1ErrorMessage Message { get; private set; }

    }

}
