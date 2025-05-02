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

[ClientObject(Name = "SP.UserCreationInformation", Id = "{6ecd8af6-bed3-4a74-be76-1ec981b350e1}")]
[JsonObject()]
public class UserCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Email { get; protected set; }

    [JsonProperty()]
    public virtual string? LoginName { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
