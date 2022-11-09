//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V2
{

    [JsonObject()]
    public class Quota : ODataV2Object
    {

        public Quota()
        {
        }

        [JsonProperty("deleted")]
        public virtual long Deleted { get; protected set; }

        [JsonProperty("fileCount")]
        public virtual long FileCount { get; protected set; }

        [JsonProperty("remaining")]
        public virtual long Remaining { get; protected set; }

        [JsonProperty("state")]
        public virtual QuotaState State { get; protected set; }

        [JsonProperty("total")]
        public virtual long Total { get; protected set; }

        [JsonProperty("used")]
        public virtual long Used { get; protected set; }

    }

}
