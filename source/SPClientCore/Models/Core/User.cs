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

    [JsonObject(Id = "SP.User")]
    public class User : Principal
    {

        public User()
        {
        }

        [JsonProperty()]
        public ClientObjectCollection<Alert> Alerts { get; private set; }

        [JsonProperty()]
        public string Email { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Group> Groups { get; private set; }

        [JsonProperty()]
        public bool? IsEmailAuthenticationGuestUser { get; private set; }

        [JsonProperty()]
        public bool? IsShareByEmailGuestUser { get; private set; }

        [JsonProperty()]
        public bool? IsSiteAdmin { get; private set; }

        [JsonProperty()]
        public UserIdInfo UserId { get; private set; }

    }

}
