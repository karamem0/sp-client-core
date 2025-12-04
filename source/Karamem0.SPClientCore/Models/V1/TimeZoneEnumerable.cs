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

[ClientObject(Name = "SP.Taxonomy.TimeZoneCollection", Id = "{117cbf47-7e74-4165-b26b-c24180ab2095}")]
[JsonObject()]
public class TimeZoneEnumerable : ClientObjectEnumerable<TimeZone>;
