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

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.NavigationNode")]
    public class NavigationNode : ClientObject
    {

        public NavigationNode()
        {
        }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public bool? IsDocLib { get; private set; }

        [JsonProperty()]
        public bool? IsExternal { get; private set; }

        [JsonProperty()]
        public bool? IsVisible { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

    }

}
