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
    public virtual bool AccessRequestMode { get; set; }

    [JsonProperty()]
    public virtual bool BlockPeoplePickerAndSharing { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageOrganizationReadonlyLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageOrganizationReadWriteLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageReadonlyLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserManageReadWriteLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveOrganizationReadonlyLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveOrganizationReadWriteLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveReadonlyLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserRetrieveReadWriteLink { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserShareExternally { get; set; }

    [JsonProperty()]
    public virtual bool CanCurrentUserShareInternally { get; set; }

    [JsonProperty()]
    public virtual bool CanSendEmail { get; set; }

    [JsonProperty()]
    public virtual bool CanSendLink { get; set; }

    [JsonProperty()]
    public virtual bool CanShareFolder { get; set; }

    [JsonProperty()]
    public virtual RoleType? DefaultShareLinkPermission { get; set; }

    [JsonProperty()]
    public virtual SharingLinkKind? DefaultShareLinkType { get; set; }

    [JsonProperty("EnforceIBSegmentFiltering")]
    public virtual bool EnforceInformationBarriersSegmentFiltering { get; set; }

    [JsonProperty("EnforceSPOSearch")]
    public virtual bool EnforceSharePointOnlineSearch { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? GroupsList { get; set; }

    [JsonProperty()]
    public virtual bool HasEditRole { get; set; }

    [JsonProperty()]
    public virtual bool HasReadRole { get; set; }

    [JsonProperty()]
    public virtual string? InheritingWebLink { get; set; }

    [JsonProperty()]
    public virtual bool IsGuestUser { get; set; }

    [JsonProperty()]
    public virtual bool IsPictureLibrary { get; set; }

    [JsonProperty()]
    public virtual bool IsUserSiteAdmin { get; set; }

    [JsonProperty()]
    public virtual string? ItemId { get; set; }

    [JsonProperty()]
    public virtual string? ItemName { get; set; }

    [JsonProperty()]
    public virtual string? ItemUrl { get; set; }

    [JsonProperty()]
    public virtual Guid ListId { get; set; }

    [JsonProperty()]
    public virtual bool PermissionsOnlyMode { get; set; }

    [JsonProperty()]
    public virtual int RequiredAnonymousLinkExpirationInDays { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? Roles { get; set; }

    [JsonProperty()]
    public virtual bool ShareByEmailEnabled { get; set; }

    [JsonProperty()]
    public virtual SharePointSharingSettings? SharePointSettings { get; set; }

    [JsonProperty("ObjectSharingInformation")]
    public virtual SharingInfo? SharingInfo { get; set; }

    [JsonProperty()]
    public virtual SharingPermissionInfoEnumerable? SharingPermissions { get; set; }

    [JsonProperty()]
    public virtual bool ShowExternalSharingWarning { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? SimplifiedRoles { get; set; }

    [JsonProperty("SiteIBMode")]
    public virtual string? SiteInformationBarriersMode { get; set; }

    [JsonProperty("SiteIBSegmentIDs")]
    public virtual IReadOnlyCollection<string>? SiteInformationBarriersSegmentIDs { get; set; }

    [JsonProperty()]
    public virtual bool SupportsAclPropagation { get; set; }

    [JsonProperty()]
    public virtual string? WebUrl { get; set; }

}
