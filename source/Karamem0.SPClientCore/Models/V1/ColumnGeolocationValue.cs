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

[ClientObject(Name = "SP.FieldGeolocationValue", Id = "{97650aff-7e7b-44be-ac6e-d559f7f897a2}")]
[JsonObject()]
public class ColumnGeolocationValue(
    double altitude = 0,
    double latitude = 0,
    double longitude = 0,
    double measure = 0
) : ClientValueObject
{

    [JsonProperty()]
    public virtual double Altitude { get; protected set; } = altitude;

    [JsonProperty()]
    public virtual double Latitude { get; protected set; } = latitude;

    [JsonProperty()]
    public virtual double Longitude { get; protected set; } = longitude;

    [JsonProperty()]
    public virtual double Measure { get; protected set; } = measure;

}
