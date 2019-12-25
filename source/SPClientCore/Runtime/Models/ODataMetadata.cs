//
// Copyright (c) 2020 karamem0
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
    public class ODataMetadata
    {

        public ODataMetadata()
        {
        }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("uri")]
        public Uri Uri { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

    }

}
