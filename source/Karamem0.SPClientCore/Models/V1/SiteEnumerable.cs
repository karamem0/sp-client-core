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

    [ClientObject(Name = "SP.WebCollection", Id = "{c197d59e-d070-43bf-ad5e-10d6152e38a6}")]
    [JsonObject()]
    public class SiteEnumerable : ClientObjectEnumerable<Site>
    {

        public SiteEnumerable()
        {
        }

    }

}
