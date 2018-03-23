//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.RegionalSettings")]
    public class RegionalSettings : ClientObject
    {

        public RegionalSettings()
        {
        }

        [JsonProperty()]
        public short? AdjustHijriDays { get; private set; }

        [JsonProperty()]
        public short? AlternateCalendarType { get; private set; }

        [JsonProperty()]
        public string AM { get; private set; }

        [JsonProperty()]
        public short? CalendarType { get; private set; }

        [JsonProperty()]
        public short? Collation { get; private set; }

        [JsonProperty()]
        public uint? CollationLCID { get; private set; }

        [JsonProperty()]
        public uint? DateFormat { get; private set; }

        [JsonProperty()]
        public string DateSeparator { get; private set; }

        [JsonProperty()]
        public string DecimalSeparator { get; private set; }

        [JsonProperty()]
        public string DigitGrouping { get; private set; }

        [JsonProperty()]
        public uint? FirstDayOfWeek { get; private set; }

        [JsonProperty()]
        public short? FirstWeekOfYear { get; private set; }

        [JsonProperty()]
        public bool? IsEastAsia { get; private set; }

        [JsonProperty()]
        public bool? IsRightToLeft { get; private set; }

        [JsonProperty()]
        public bool? IsUIRightToLeft { get; private set; }

        [JsonProperty()]
        public string ListSeparator { get; private set; }

        [JsonProperty("LocaleId")]
        public uint? LCID { get; private set; }

        [JsonProperty()]
        public string NegativeSign { get; private set; }

        [JsonProperty()]
        public uint? NegNumberMode { get; private set; }

        [JsonProperty()]
        public string PM { get; private set; }

        [JsonProperty()]
        public string PositiveSign { get; private set; }

        [JsonProperty()]
        public bool? ShowWeeks { get; private set; }

        [JsonProperty()]
        public string ThousandSeparator { get; private set; }

        [JsonProperty()]
        public bool? Time24 { get; private set; }

        [JsonProperty()]
        public string TimeMarkerPosition { get; private set; }

        [JsonProperty()]
        public string TimeSeparator { get; private set; }

        [JsonProperty()]
        public TimeZone TimeZone { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<TimeZone> TimeZones { get; private set; }

        [JsonProperty()]
        public short? WorkDayEndHour { get; private set; }

        [JsonProperty()]
        public short? WorkDays { get; private set; }

        [JsonProperty()]
        public short? WorkDayStartHour { get; private set; }

    }

}
