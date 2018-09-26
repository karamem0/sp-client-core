//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.SecurableObject")]
    public class SecurableObject : ClientObject
    {

        public SecurableObject()
        {
        }

        [JsonProperty()]
        public SecurableObject FirstUniqueAncestorSecurableObject { get; private set; }

        [JsonProperty()]
        public bool? HasUniqueRoleAssignments { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<RoleAssignment> RoleAssignments { get; private set; }

    }

}
