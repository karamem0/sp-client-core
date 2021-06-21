//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataError
    {

        public ODataError()
        {
        }

        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("message")]
        public ODataErrorMessage Message { get; private set; }

    }

}
