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

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.UserIdInfo")]
    public class UserIdInfo : ClientObject
    {

        public UserIdInfo()
        {
        }

        [JsonProperty()]
        public string NameId { get; private set; }

        [JsonProperty()]
        public string NameIdIssuer { get; private set; }

    }

}
