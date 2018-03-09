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

    [JsonObject(Id = "SP.UpgradeInfo")]
    public class UpgradeInfo : ClientObject
    {

        public UpgradeInfo()
        {
        }

        [JsonProperty()]
        public string ErrorFile { get; private set; }

        [JsonProperty()]
        public int? Errors { get; private set; }

        [JsonProperty()]
        public DateTime? LastUpdated { get; private set; }

        [JsonProperty()]
        public string LogFile { get; private set; }

        [JsonProperty()]
        public DateTime? RequestDate { get; private set; }

        [JsonProperty()]
        public int? RetryCount { get; private set; }

        [JsonProperty()]
        public DateTime? startTime { get; private set; }

        [JsonProperty()]
        public UpgradeStatus? Status { get; private set; }

        [JsonProperty()]
        public UpgradeType? UpgradeType { get; private set; }

        [JsonProperty()]
        public string Warnings { get; private set; }

    }

}
