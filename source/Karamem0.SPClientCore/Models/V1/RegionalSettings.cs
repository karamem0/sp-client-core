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

[ClientObject(Name = "SP.RegionalSettings", Id = "{84c424a9-a1d6-46ba-8398-c46257ecd25b}")]
[JsonObject()]
public class RegionalSettings : ClientObject
{

    [JsonProperty()]
    public virtual short? AdjustHijriDays { get; set; }

    [JsonProperty()]
    public virtual short? AlternateCalendarType { get; set; }

    [JsonProperty()]
    public virtual string? AM { get; set; }

    [JsonProperty()]
    public virtual short? CalendarType { get; set; }

    [JsonProperty()]
    public virtual short? Collation { get; set; }

    [JsonProperty("CollationLCID")]
    public virtual uint CollationLcid { get; set; }

    [JsonProperty()]
    public virtual uint DateFormat { get; set; }

    [JsonProperty()]
    public virtual string? DateSeparator { get; set; }

    [JsonProperty()]
    public virtual string? DecimalSeparator { get; set; }

    [JsonProperty()]
    public virtual string? DigitGrouping { get; set; }

    [JsonProperty()]
    public virtual uint FirstDayOfWeek { get; set; }

    [JsonProperty()]
    public virtual short? FirstWeekOfYear { get; set; }

    [JsonProperty()]
    public virtual bool IsEastAsia { get; set; }

    [JsonProperty()]
    public virtual bool IsRightToLeft { get; set; }

    [JsonProperty()]
    public virtual bool IsUIRightToLeft { get; set; }

    [JsonProperty()]
    public virtual string? ListSeparator { get; set; }

    [JsonProperty("LocaleId")]
    public virtual uint Lcid { get; set; }

    [JsonProperty()]
    public virtual string? NegativeSign { get; set; }

    [JsonProperty()]
    public virtual uint NegNumberMode { get; set; }

    [JsonProperty()]
    public virtual string? PM { get; set; }

    [JsonProperty()]
    public virtual string? PositiveSign { get; set; }

    [JsonProperty()]
    public virtual bool ShowWeeks { get; set; }

    [JsonProperty()]
    public virtual string? ThousandSeparator { get; set; }

    [JsonProperty()]
    public virtual bool Time24 { get; set; }

    [JsonProperty()]
    public virtual uint TimeMarkerPosition { get; set; }

    [JsonProperty()]
    public virtual string? TimeSeparator { get; set; }

    [JsonProperty()]
    public virtual TimeZone? TimeZone { get; set; }

    [JsonProperty()]
    public virtual TimeZoneEnumerable? TimeZones { get; set; }

    [JsonProperty()]
    public virtual short? WorkDayEndHour { get; set; }

    [JsonProperty()]
    public virtual short? WorkDays { get; set; }

    [JsonProperty()]
    public virtual short? WorkDayStartHour { get; set; }

}
