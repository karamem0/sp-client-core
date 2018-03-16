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

    [JsonObject()]
    public class ResultTable : ClientObject
    {

        public ResultTable()
        {
        }

        [JsonProperty()]
        public string GroupTemplateId { get; private set; }

        [JsonProperty()]
        public string ItemTemplateId { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<KeyValue> Properties { get; private set; }

        [JsonProperty()]
        public string ResultTitle { get; private set; }

        [JsonProperty()]
        public string ResultTitleUrl { get; private set; }

    }

}
