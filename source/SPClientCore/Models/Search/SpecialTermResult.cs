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

    [JsonObject(Id = "Microsoft.Office.Server.Search.REST.SpecialTermResult")]
    public class SpecialTermResult : ClientObject
    {

        public SpecialTermResult()
        {
        }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public bool? IsVisualBestBet { get; private set; }

        [JsonProperty()]
        public string PiSearchResultId { get; private set; }

        [JsonProperty()]
        public string RenderTemplateId { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

    }

}
