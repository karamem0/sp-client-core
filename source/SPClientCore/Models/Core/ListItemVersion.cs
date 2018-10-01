//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.ListItemVersion")]
    public class ListItemVersion : ClientObject
    {

        public ListItemVersion()
        {
        }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public User CreatedBy { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Field> Fields { get; private set; }

        [JsonProperty()]
        public FileVersion FileVersion { get; private set; }

        [JsonProperty()]
        public bool? IsCurrentVersion { get; private set; }

        [JsonProperty()]
        public int? VersionId { get; private set; }

        [JsonProperty()]
        public string VersionLabel { get; private set; }

    }

}
