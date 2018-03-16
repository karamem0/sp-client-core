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

    [JsonObject(Id = "Microsoft.Office.Server.Search.REST.SearchResult")]
    public class SearchResult : ClientObject
    {

        public SearchResult()
        {
        }

        [JsonProperty()]
        public int? ElapsedTime { get; private set; }

        [JsonProperty()]
        public QueryResult PrimaryQueryResult { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<KeyValue> Properties { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<QueryResult> SecondaryQueryResults { get; private set; }

        [JsonProperty()]
        public string SpellingSuggestion { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Guid?> TriggeredRules { get; private set; }

    }

}
