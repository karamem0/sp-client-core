//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.ListTemplateCollection", Id = "{23748d10-16a1-4946-a38b-98fdec0e0ec8}")]
    [JsonObject()]
    public class ListTemplateEnumerable : ClientObjectEnumerable<ListTemplate>
    {

        public ListTemplateEnumerable()
        {
        }

    }

}
