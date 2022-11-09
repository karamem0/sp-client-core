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

    [ClientObject(Name = "SP.AppCatalog", Id = "{79cdee9f-257e-423b-9e94-e6404659f7ea}")]
    [JsonObject()]
    public class AppCatalog : ClientObject
    {

        public AppCatalog()
        {
        }

    }

}
