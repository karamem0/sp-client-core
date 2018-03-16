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

    [JsonObject(Id = "Microsoft.Office.Server.Search.REST.QueryResult")]
    public class QueryResult : ClientObject
    {

        public QueryResult()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<CustomResult> CustomResults { get; private set; }

        [JsonProperty()]
        public string QueryId { get; private set; }

        [JsonProperty()]
        public Guid? QueryRuleId { get; private set; }

        [JsonProperty()]
        public RefinementResults RefinementResults { get; private set; }

        [JsonProperty()]
        public RelevantResults RelevantResults { get; private set; }

        [JsonProperty()]
        public SpecialTermResults SpecialTermResults { get; private set; }

    }

}
