//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

public enum ColumnType
{

    Invalid = 0,

    Integer = 1,

    Text = 2,

    Note = 3,

    DateTime = 4,

    Counter = 5,

    Choice = 6,

    Lookup = 7,

    Boolean = 8,

    Number = 9,

    Currency = 10,

    URL = 11,

    Computed = 12,

    Threading = 13,

    Guid = 14,

    MultiChoice = 15,

    GridChoice = 16,

    Calculated = 17,

    File = 18,

    Attachments = 19,

    User = 20,

    Recurrence = 21,

    CrossProjectLink = 22,

    ModStat = 23,

    Error = 24,

    ContentTypeId = 25,

    PageSeparator = 26,

    ThreadIndex = 27,

    WorkflowStatus = 28,

    AllDayEvent = 29,

    WorkflowEventType = 30,

    Geolocation = 31,

    OutcomeChoice = 32,

    Location = 33,

    Thumbnail = 34,

    MaxItems = 35,

}
