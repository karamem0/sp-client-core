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

    [JsonObject(Id = "SP.Group")]
    public class Group : Principal
    {

        public Group()
        {
        }

        [JsonProperty()]
        public bool? AllowMembersEditMembership { get; private set; }

        [JsonProperty()]
        public bool? AllowRequestToJoinLeave { get; private set; }

        [JsonProperty()]
        public bool? AutoAcceptRequestToJoinLeave { get; private set; }

        [JsonProperty()]
        public bool? CanCurrentUserEditMembership { get; private set; }

        [JsonProperty()]
        public bool? CanCurrentUserManageGroup { get; private set; }

        [JsonProperty()]
        public bool? CanCurrentUserViewMembership { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public bool? OnlyAllowMembersViewMembership { get; private set; }

        [JsonProperty()]
        public Principal Owner { get; private set; }

        [JsonProperty()]
        public string OwnerTitle { get; private set; }

        [JsonProperty()]
        public string RequestToJoinLeaveEmailSetting { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<User> Users { get; private set; }

    }

}
