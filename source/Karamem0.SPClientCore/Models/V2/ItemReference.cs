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
    public class ItemReference : ODataV2Object
    {

        public ItemReference()
        {
        }

        [JsonProperty("driveId")]
        public virtual string DriveId { get; protected set; }

        [JsonProperty("driveType")]
        public virtual DriveType DriveType { get; protected set; }

        [JsonProperty("id")]
        public virtual string Id { get; protected set; }

        [JsonProperty("path")]
        public virtual string Path { get; protected set; }

    }

}
