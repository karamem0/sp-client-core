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

    [JsonObject(Id = "SP.UsageInfo")]
    public class UsageInfo : ClientObject
    {

        public UsageInfo()
        {
        }

        [JsonProperty()]
        public string Bandwidth { get; private set; }

        [JsonProperty()]
        public long? DiscussionStorage { get; private set; }

        [JsonProperty()]
        public long? Hits { get; private set; }

        [JsonProperty()]
        public long? Storage { get; private set; }

        [JsonProperty()]
        public double? StoragePercentageUsed { get; private set; }

        [JsonProperty()]
        public long? Visits { get; private set; }

    }

}
