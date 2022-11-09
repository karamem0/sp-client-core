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

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [ClientObject(Name = "SP.Sharing.WebSharingManager", Id = "{a187f049-f067-42cd-977b-79e85ea2a9fa}")]
    [JsonObject()]
    public class WebSharingManager : ClientObject
    {

        public WebSharingManager()
        {
        }

    }

}
