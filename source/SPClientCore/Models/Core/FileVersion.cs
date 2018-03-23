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

    [JsonObject(Id = "SP.FileVersion")]
    public class FileVersion : ClientObject
    {

        public FileVersion()
        {
        }

        [JsonProperty()]
        public string CheckInComment { get; private set; }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public User CreatedBy { get; private set; }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public bool? IsCurrentVersion { get; private set; }

        [JsonProperty()]
        public int? Size { get; private set; }

        [JsonProperty()]
        public string Url { get; private set; }

        [JsonProperty()]
        public string VersionLabel { get; private set; }

    }

}
