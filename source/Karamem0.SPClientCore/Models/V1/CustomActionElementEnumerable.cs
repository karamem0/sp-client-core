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

    [ClientObject(Name = "SP.CustomActionElementCollection", Id = "{8085c8a0-ac08-44c8-ac9f-8a35540b34d1}")]
    [JsonObject()]
    public class CustomActionElementEnumerable : ClientObjectEnumerable<CustomActionElement>
    {

        public CustomActionElementEnumerable()
        {
        }

    }

}
