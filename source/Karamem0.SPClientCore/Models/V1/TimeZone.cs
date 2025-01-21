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

[ClientObject(Name = "SP.TimeZone", Id = "{5519d02c-ce37-4b91-b61d-a1cefe0fc85e}")]
[JsonObject()]
public class TimeZone : ClientObject
{

    public TimeZone()
    {
    }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual int Id { get; protected set; }

    [JsonProperty("Information")]
    public virtual TimeZoneInfo TimeZoneInfo { get; protected set; }

}
