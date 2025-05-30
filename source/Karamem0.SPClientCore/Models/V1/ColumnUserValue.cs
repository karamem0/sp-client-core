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

[ClientObject(Name = "SP.FieldUserValue", Id = "{c956ab54-16bd-4c18-89d2-996f57282a6f}")]
[JsonObject()]
public class ColumnUserValue(
    int lookupId = 0,
    string? lookupValue = null,
    string? email = null
) : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Email { get; protected set; } = email;

    [JsonProperty()]
    public virtual int LookupId { get; protected set; } = lookupId;

    [JsonProperty()]
    public virtual string? LookupValue { get; protected set; } = lookupValue;

}
