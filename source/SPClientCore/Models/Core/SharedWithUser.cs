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

    [JsonObject(Id = "SP.SharedWithUser")]
    public class SharedWithUser
    {

        public SharedWithUser()
        {
        }

        [JsonProperty()]
        public string Email { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

    }

}
