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

    [JsonObject(Id = "SP.ListTemplate")]
    public class ListTemplate : ClientObject
    {

        public ListTemplate()
        {
        }

        [JsonProperty()]
        public bool? AllowsFolderCreation { get; private set; }

        [JsonProperty()]
        public BaseType BaseType { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public Guid? FeatureId { get; private set; }

        [JsonProperty()]
        public bool? Hidden { get; private set; }

        [JsonProperty()]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public string PublicName { get; private set; }

        [JsonProperty()]
        public bool? IsCustomTemplate { get; private set; }

        [JsonProperty()]
        public int? ListTemplateTypeKind { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public bool? OnQuickLaunch { get; private set; }

        [JsonProperty()]
        public bool? Unique { get; private set; }

    }

}
