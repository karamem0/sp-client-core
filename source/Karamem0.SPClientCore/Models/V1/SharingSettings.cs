//
// Copyright (c) 2018-2025 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ObjectSharingSettings", Id = "{9ca08afe-29fa-4faf-86af-5bcb06e41969}")]
[JsonObject()]
public class SharingSettings : ClientObject
{

    [JsonProperty()]
    public virtual bool AccessRequestMode { get; protected set; }

    [JsonProperty()]
    public virtual bool BlockPeoplePickerAndSharing { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageOrganizationReadonlyLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageOrganizationReadWriteLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageReadonlyLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageReadWriteLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveOrganizationReadonlyLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveOrganizationReadWriteLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveReadonlyLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveReadWriteLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserShareExternally { get; protected set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserShareInternally { get; protected set; }

    [JsonProperty()]
    public virtual bool CanSendEmail { get; protected set; }

    [JsonProperty()]
    public virtual bool CanSendLink { get; protected set; }

    [JsonProperty()]
    public virtual bool CanShareFolder { get; protected set; }

    [JsonProperty()]
    public virtual RoleType DefaultShareLinkPermission { get; protected set; }

    [JsonProperty()]
    public virtual SharingLinkKind DefaultShareLinkType { get; protected set; }

    [JsonProperty("EnforceIBSegmentFiltering")]
    public virtual bool EnforceInformationBarriersSegmentFiltering { get; protected set; }

    [JsonProperty("EnforceSPOSearch")]
    public virtual bool EnforceSharePointOnlineSearch { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string> GroupsList { get; protected set; }

    [JsonProperty()]
    public virtual bool HasEditRole { get; protected set; }

    [JsonProperty()]
    public virtual bool HasReadRole { get; protected set; }

    [JsonProperty()]
    public virtual string InheritingWebLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsGuestUser { get; protected set; }

    [JsonProperty()]
    public virtual bool IsPictureLibrary { get; protected set; }

    [JsonProperty()]
    public virtual bool IsUserSiteAdmin { get; protected set; }

    [JsonProperty()]
    public virtual string ItemId { get; protected set; }

    [JsonProperty()]
    public virtual string ItemName { get; protected set; }

    [JsonProperty()]
    public virtual string ItemUrl { get; protected set; }

    [JsonProperty()]
    public virtual Guid ListId { get; protected set; }

    [JsonProperty()]
    public virtual bool PermissionsOnlyMode { get; protected set; }

    [JsonProperty()]
    public virtual int RequiredAnonymousLinkExpirationInDays { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string> Roles { get; protected set; }

    [JsonProperty()]
    public virtual bool ShareByEmailEnabled { get; protected set; }

    [JsonProperty()]
    public virtual SharePointSharingSettings SharePointSettings { get; protected set; }

    [JsonProperty("ObjectSharingInformation")]
    public virtual SharingInfo SharingInfo { get; protected set; }

    [JsonProperty()]
    public virtual SharingPermissionInfoEnumerable SharingPermissions { get; protected set; }

    [JsonProperty()]
    public virtual bool ShowExternalSharingWarning { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string> SimplifiedRoles { get; protected set; }

    [JsonProperty("SiteIBMode")]
    public virtual string SiteInformationBarriersMode { get; protected set; }

    [JsonProperty("SiteIBSegmentIDs")]
    public virtual IReadOnlyCollection<string> SiteInformationBarriersSegmentIDs { get; protected set; }

    [JsonProperty()]
    public virtual bool SupportsAclPropagation { get; protected set; }

    [JsonProperty()]
    public virtual string WebUrl { get; protected set; }

}
