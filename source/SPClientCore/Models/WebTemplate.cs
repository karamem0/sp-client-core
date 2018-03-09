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

    [JsonObject(Id = "SP.WebTemplate")]
    public class WebTemplate : ClientObject
    {

        public WebTemplate()
        {
        }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string DisplayCategory { get; private set; }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public bool? IsHidden { get; private set; }

        [JsonProperty()]
        public bool? IsRootWebOnly { get; private set; }

        [JsonProperty()]
        public bool? IsSubWebOnly { get; private set; }

        [JsonProperty()]
        public uint? LCID { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

    }

}
