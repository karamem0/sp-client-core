//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataErrorMessage
    {

        public ODataErrorMessage()
        {
        }

        [JsonProperty("lang")]
        public string Language { get; private set; }

        [JsonProperty("value")]
        public string Value { get; private set; }

    }

}
