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

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.WebInformation")]
    public class WebInformation : ClientObject
    {

        public WebInformation()
        {
        }

        [JsonProperty()]
        public short? Configuration { get; private set; }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string Id { get; private set; }

        [JsonProperty()]
        public int? Language { get; private set; }

        [JsonProperty()]
        public DateTime? LastItemModifiedDate { get; private set; }

        [JsonProperty()]
        public string ServerRelativeUrl { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public WebTemplate WebTemplate { get; private set; }

        [JsonProperty()]
        public int? WebTemplateId { get; private set; }

    }

}
