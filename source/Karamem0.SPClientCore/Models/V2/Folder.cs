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
    public class Folder : ODataV2Object
    {

        public Folder()
        {
        }

        [JsonProperty("childCount")]
        public virtual int ChildCount { get; protected set; }

    }

}
