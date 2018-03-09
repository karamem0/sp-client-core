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

    [JsonObject(Id = "SP.ContextWebInformation")]
    public class ContextWebInformation : ClientObject
    {

        public ContextWebInformation()
        {
        }

        [JsonProperty()]
        public int? FormDigestTimeoutSeconds { get; private set; }

        [JsonProperty()]
        public string FormDigestValue { get; private set; }

        [JsonProperty()]
        public string LibraryVersion { get; private set; }

        [JsonProperty()]
        public string SiteFullUrl { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<string> SupportedSchemaVersions { get; private set; }

        [JsonProperty()]
        public string WebFullUrl { get; private set; }

    }

}
