//
// Copyright (c) 2023 karamem0
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
    public class FileSystemInfo : ODataV2Object
    {

        public FileSystemInfo()
        {
        }

        [JsonProperty("createdDateTime")]
        public virtual DateTime Created { get; protected set; }

        [JsonProperty("lastModifiedDateTime")]
        public virtual DateTime LastModified { get; protected set; }

    }

}
