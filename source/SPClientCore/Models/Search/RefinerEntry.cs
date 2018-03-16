//
// Copyright (c) 2018 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.Search
{

    [JsonObject(Id = "Microsoft.Office.Server.Search.REST.RefinerEntry")]
    public class RefinerEntry
    {

        public RefinerEntry()
        {
        }

        [JsonProperty()]
        public long? RefinementCount { get; private set; }

        [JsonProperty()]
        public string RefinementName { get; private set; }

        [JsonProperty()]
        public string RefinementToken { get; private set; }

        [JsonProperty()]
        public string RefinementValue { get; private set; }

    }

}
