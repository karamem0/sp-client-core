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

[ClientObject(Name = "SP.SharedWithUser", Id = "{01d693d9-72c2-4531-9fb9-105c88b6706b}")]
[JsonObject()]
public class SharedWithUser : ClientValueObject
{

    [JsonProperty()]
    public virtual string Email { get; protected set; }

    [JsonProperty()]
    public virtual string Name { get; protected set; }

}
