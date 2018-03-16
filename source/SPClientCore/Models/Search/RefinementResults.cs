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

    [JsonObject(Id = "Microsoft.Office.Server.Search.REST.RefinementResults")]
    public class RefinementResults : ResultTable
    {

        public RefinementResults()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<Refiner> Refiners { get; private set; }

    }

}
