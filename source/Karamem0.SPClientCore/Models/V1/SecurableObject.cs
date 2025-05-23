//
// Copyright (c) 2018-2025 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.SecurableObject", Id = "{1b1bf348-994e-44fd-823f-0748f5ad94c8}")]
[JsonObject()]
public class SecurableObject : ClientObject
{

    [JsonProperty()]
    public virtual bool HasUniqueRoleAssignments { get; protected set; }

}
