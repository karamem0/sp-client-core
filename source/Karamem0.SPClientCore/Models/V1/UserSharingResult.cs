//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [ClientObject(Name = "SP.Sharing.UserSharingResult", Id = "{782142b7-1bb8-495f-8a60-9940982de38e}")]
    [JsonObject()]
    public class UserSharingResult : ClientValueObject
    {

        public UserSharingResult()
        {
        }

        [JsonProperty()]
        public virtual IReadOnlyCollection<RoleType> AllowedRoles { get; protected set; }

        [JsonProperty()]
        public virtual RoleType CurrentRole { get; protected set; }

        [JsonProperty()]
        public virtual string DisplayName { get; protected set; }

        [JsonProperty()]
        public virtual string Email { get; protected set; }

        [JsonProperty()]
        public virtual string InvitationLink { get; protected set; }

        [JsonProperty()]
        public virtual bool IsUserKnown { get; protected set; }

        [JsonProperty()]
        public virtual string Message { get; protected set; }

        [JsonProperty()]
        public virtual bool Status { get; protected set; }

        [JsonProperty("User")]
        public virtual string UserId { get; protected set; }

    }

}
