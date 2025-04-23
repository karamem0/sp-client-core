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

[ClientObject(Name = "SP.FieldLookupValue", Id = "{f1d34cc0-9b50-4a78-be78-d5facfcccfb7}")]
[JsonObject()]
public class ColumnLookupValue(int lookupId = 0, string lookupValue = null) : ClientValueObject
{

    [JsonProperty()]
    public virtual int LookupId { get; protected set; } = lookupId;

    [JsonProperty()]
    public virtual string LookupValue { get; protected set; } = lookupValue;

}
