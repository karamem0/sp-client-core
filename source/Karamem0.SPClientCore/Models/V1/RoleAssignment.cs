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

    [ClientObject(Name = "SP.RoleAssignment", Id = "{07da03be-4d19-48f3-9c5f-7c67b134a93b}")]
    [JsonObject()]
    public class RoleAssignment : ClientObject
    {

        public RoleAssignment()
        {
        }

        [JsonProperty()]
        public virtual Principal Member { get; protected set; }

        [JsonProperty()]
        public virtual int PrincipalId { get; protected set; }

        [JsonProperty()]
        public virtual RoleDefinitionBindingEnumerable RoleDefinitionBindings { get; protected set; }

    }

}
