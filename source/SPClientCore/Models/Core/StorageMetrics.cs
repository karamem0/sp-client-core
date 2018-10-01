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

    [JsonObject(Id = "SP.StorageMetrics")]
    public class StorageMetrics : ClientObject
    {

        public StorageMetrics()
        {
        }

        [JsonProperty()]
        public DateTime? LastModified { get; private set; }

        [JsonProperty()]
        public int? TotalFileCount { get; private set; }

        [JsonProperty()]
        public int? TotalFileStreamSize { get; private set; }

        [JsonProperty()]
        public int? TotalSize { get; private set; }

    }

}
