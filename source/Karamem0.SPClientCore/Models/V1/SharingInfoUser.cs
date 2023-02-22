//
// Copyright (c) 2023 karamem0
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

    [ClientObject(Name = "SP.ObjectSharingInformationUser", Id = "{f7b7fe66-58a7-4843-882d-99af0d97992b}")]
    [JsonObject()]
    public class SharingInforUser : ClientObject
    {

        public SharingInforUser()
        {
        }

        [JsonProperty()]
        public virtual string CustomRoleNames { get; protected set; }

        [JsonProperty()]
        public virtual string Department { get; protected set; }

        [JsonProperty()]
        public virtual string Email { get; protected set; }

        [JsonProperty()]
        public virtual bool HasEditPermission { get; protected set; }

        [JsonProperty()]
        public virtual bool HasReviewPermission { get; protected set; }

        [JsonProperty()]
        public virtual bool HasViewPermission { get; protected set; }

        [JsonProperty()]
        public virtual int Id { get; protected set; }

        [JsonProperty()]
        public virtual bool IsDomainGroup { get; protected set; }

        [JsonProperty()]
        public virtual bool IsExternalUser { get; protected set; }

        [JsonProperty()]
        public virtual bool IsMemberOfGroup { get; protected set; }

        [JsonProperty()]
        public virtual bool IsSiteAdmin { get; protected set; }

        [JsonProperty()]
        public virtual string JobTitle { get; protected set; }

        [JsonProperty()]
        public virtual string LoginName { get; protected set; }

        [JsonProperty()]
        public virtual string Name { get; protected set; }

        [JsonProperty()]
        public virtual string Picture { get; protected set; }

        [JsonProperty()]
        public virtual Principal Principal { get; protected set; }

        [JsonProperty()]
        public virtual string SipAddress { get; protected set; }

        [JsonProperty()]
        public virtual User User { get; protected set; }

    }

}
