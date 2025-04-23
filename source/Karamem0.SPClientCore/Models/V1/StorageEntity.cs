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

[ClientObject(Name = "Microsoft.SharePoint.ClientSideComponent.StorageEntity", Id = "{499cb725-3086-42f9-86d1-71594212a6ca}")]
[JsonObject()]
public class StorageEntity : ClientObject
{

    [JsonProperty()]
    public virtual string Comment { get; protected set; }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual string Value { get; protected set; }

}
