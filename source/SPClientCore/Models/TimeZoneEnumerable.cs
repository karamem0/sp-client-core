//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.Taxonomy.TimeZoneCollection", Id = "{117cbf47-7e74-4165-b26b-c24180ab2095}")]
    [JsonObject()]
    public class TimeZoneEnumerable : ClientObjectEnumerable<TimeZone>
    {

        public TimeZoneEnumerable()
        {
        }

    }

}
