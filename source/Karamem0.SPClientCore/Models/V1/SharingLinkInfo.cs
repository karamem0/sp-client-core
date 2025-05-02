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

[ClientObject(Name = "SP.SharingLinkInfo", Id = "{43647532-53c0-489a-a800-b51f5a3804a2}")]
[JsonObject()]
public class SharingLinkInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual bool AllowsAnonymousAccess { get; set; }

    [JsonProperty()]
    public virtual string? ApplicationId { get; set; }

    [JsonProperty()]
    public virtual bool BlocksDownload { get; set; }

    [JsonProperty()]
    public virtual string? Created { get; set; }

    [JsonProperty()]
    public virtual SharingPrincipal? CreatedBy { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual bool Embeddable { get; set; }

    [JsonProperty()]
    public virtual string? Expiration { get; set; }

    [JsonProperty()]
    public virtual bool HasExternalGuestInvitees { get; set; }

    [JsonProperty()]
    public virtual string? Invitations { get; set; }

    [JsonProperty()]
    public virtual bool IsActive { get; set; }

    [JsonProperty()]
    public virtual bool IsAddressBarLink { get; set; }

    [JsonProperty()]
    public virtual bool IsCreateOnlyLink { get; set; }

    [JsonProperty()]
    public virtual bool IsDefault { get; set; }

    [JsonProperty()]
    public virtual bool IsEditLink { get; set; }

    [JsonProperty()]
    public virtual bool IsFormsLink { get; set; }

    [JsonProperty()]
    public virtual bool IsManageListLink { get; set; }

    [JsonProperty()]
    public virtual bool IsReviewLink { get; set; }

    [JsonProperty()]
    public virtual bool IsUnhealthy { get; set; }

    [JsonProperty()]
    public virtual string? LastModified { get; set; }

    [JsonProperty()]
    public virtual SharingPrincipal? LastModifiedBy { get; set; }

    [JsonProperty()]
    public virtual bool LimitUseToApplication { get; set; }

    [JsonProperty()]
    public virtual SharingLinkKind? LinkKind { get; set; }

    [JsonProperty()]
    public virtual string? PasswordLastModified { get; set; }

    [JsonProperty()]
    public virtual SharingPrincipal? PasswordLastModifiedBy { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<SharingPrincipal>? RedeemedUsers { get; set; }

    [JsonProperty()]
    public virtual bool RequiresPassword { get; set; }

    [JsonProperty()]
    public virtual bool RestrictedShareMembership { get; set; }

    [JsonProperty()]
    public virtual SharingScope? Scope { get; set; }

    [JsonProperty()]
    public virtual Guid ShareId { get; set; }

    [JsonProperty()]
    public virtual string? ShareTokenString { get; set; }

    [JsonProperty()]
    public virtual SharingLinkStatus? SharingLinkStatus { get; set; }

    [JsonProperty()]
    public virtual bool TrackLinkUsers { get; set; }

    [JsonProperty()]
    public virtual string? Url { get; set; }

}
