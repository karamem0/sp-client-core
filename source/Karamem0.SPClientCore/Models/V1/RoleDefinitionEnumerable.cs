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

    [ClientObject(Name = "SP.RoleDefinitionCollection", Id = "{964b9ab0-d026-4487-99d1-e06450963cc9}")]
    [JsonObject()]
    public class RoleDefinitionEnumerable : ClientObjectEnumerable<RoleDefinition>
    {

        public RoleDefinitionEnumerable()
        {
        }

    }

}
