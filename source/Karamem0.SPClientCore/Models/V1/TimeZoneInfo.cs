//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.TimeZoneInformation", Id = "{09e18222-7e4d-488b-811d-6ef43f31d17f}")]
[JsonObject()]
public class TimeZoneInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual int Bias { get; protected set; }

    [JsonProperty()]
    public virtual int DaylightBias { get; protected set; }

    [JsonProperty()]
    public virtual int StandardBias { get; protected set; }

}
