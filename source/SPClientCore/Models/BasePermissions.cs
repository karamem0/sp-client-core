//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.BasePermissions", Id = "{db780e5a-6bc6-41ad-8e64-9dfa761afb6d}")]
    [JsonObject()]
    public class BasePermissions : ClientValueObject
    {

        public BasePermissions()
        {
        }

        [JsonProperty()]
        public virtual int High { get; protected set; }

        [JsonProperty()]
        public virtual int Low { get; protected set; }

    }

}
