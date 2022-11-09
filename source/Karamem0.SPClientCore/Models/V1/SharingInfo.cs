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

    [ClientObject(Name = "SP.ObjectSharingInformation", Id = "{e7dae9f6-8ca5-4286-92c8-61941d774c44}")]
    [JsonObject()]
    public class SharingInfo : ClientObject
    {

        public SharingInfo()
        {
        }

        [JsonProperty()]
        public virtual string AnonymousEditLink { get; protected set; }

        [JsonProperty()]
        public virtual string AnonymousViewLink { get; protected set; }

        [JsonProperty()]
        public virtual bool CanBeShared { get; protected set; }

        [JsonProperty()]
        public virtual bool CanBeUnshared { get; protected set; }

        [JsonProperty()]
        public virtual bool CanManagePermissions { get; protected set; }

        [JsonProperty()]
        public virtual bool HasPendingAccessRequests { get; protected set; }

        [JsonProperty()]
        public virtual bool HasPermissionLevels { get; protected set; }

        [JsonProperty()]
        public virtual bool IsFolder { get; protected set; }

        [JsonProperty()]
        public virtual bool IsSharedWithCurrentUser { get; protected set; }

        [JsonProperty()]
        public virtual bool IsSharedWithGuest { get; protected set; }

        [JsonProperty()]
        public virtual bool IsSharedWithMany { get; protected set; }

        [JsonProperty()]
        public virtual bool IsSharedWithSecurityGroup { get; protected set; }

        [JsonProperty()]
        public virtual string PendingAccessRequestsLink { get; protected set; }

        [JsonProperty("SharedWithUsersCollection")]
        public virtual SharingInfoUserEnumerable SharedWithUsers { get; protected set; }

        [JsonProperty()]
        public virtual IReadOnlyCollection<SharingLinkInfo> SharingLinks { get; protected set; }

        [JsonProperty()]
        public virtual int TotalFileCount { get; protected set; }

    }

}
