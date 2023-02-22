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

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [ClientObject(Name = "SP.RoleAssignmentCollection", Id = "{2690207a-e174-4d49-b2ca-cff663225dc1}")]
    [JsonObject()]
    public class RoleAssignmentEnumerable : ClientObjectEnumerable<RoleAssignment>
    {

        public RoleAssignmentEnumerable()
        {
        }

    }

}
