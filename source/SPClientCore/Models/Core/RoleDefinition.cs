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

    [JsonObject(Id = "SP.RoleDefinition")]
    public class RoleDefinition : ClientObject
    {

        public RoleDefinition()
        {
        }

        [JsonProperty()]
        public BasePermissions BasePermissions { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public bool? Hidden { get; private set; }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public int? Order { get; private set; }

        [JsonProperty()]
        public RoleTypeKind? RoleTypeKind { get; private set; }

    }

}
