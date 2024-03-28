//
// Copyright (c) 2018-2024 karamem0
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

    public SharingLinkInfo()
    {
    }

    [JsonProperty()]
    public virtual bool AllowsAnonymousAccess { get; protected set; }

    [JsonProperty()]
    public virtual string ApplicationId { get; protected set; }

    [JsonProperty()]
    public virtual bool BlocksDownload { get; protected set; }

    [JsonProperty()]
    public virtual string Created { get; protected set; }

    [JsonProperty()]
    public virtual SharingPrincipal CreatedBy { get; protected set; }

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual bool Embeddable { get; protected set; }

    [JsonProperty()]
    public virtual string Expiration { get; protected set; }

    [JsonProperty()]
    public virtual bool HasExternalGuestInvitees { get; protected set; }

    [JsonProperty()]
    public virtual string Invitations { get; protected set; }

    [JsonProperty()]
    public virtual bool IsActive { get; protected set; }

    [JsonProperty()]
    public virtual bool IsAddressBarLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsCreateOnlyLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsDefault { get; protected set; }

    [JsonProperty()]
    public virtual bool IsEditLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsFormsLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsManageListLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsReviewLink { get; protected set; }

    [JsonProperty()]
    public virtual bool IsUnhealthy { get; protected set; }

    [JsonProperty()]
    public virtual string LastModified { get; protected set; }

    [JsonProperty()]
    public virtual SharingPrincipal LastModifiedBy { get; protected set; }

    [JsonProperty()]
    public virtual bool LimitUseToApplication { get; protected set; }

    [JsonProperty()]
    public virtual SharingLinkKind LinkKind { get; protected set; }

    [JsonProperty()]
    public virtual string PasswordLastModified { get; protected set; }

    [JsonProperty()]
    public virtual SharingPrincipal PasswordLastModifiedBy { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<SharingPrincipal> RedeemedUsers { get; protected set; }

    [JsonProperty()]
    public virtual bool RequiresPassword { get; protected set; }

    [JsonProperty()]
    public virtual bool RestrictedShareMembership { get; protected set; }

    [JsonProperty()]
    public virtual SharingScope Scope { get; protected set; }

    [JsonProperty()]
    public virtual Guid ShareId { get; protected set; }

    [JsonProperty()]
    public virtual string ShareTokenString { get; protected set; }

    [JsonProperty()]
    public virtual SharingLinkStatus SharingLinkStatus { get; protected set; }

    [JsonProperty()]
    public virtual bool TrackLinkUsers { get; protected set; }

    [JsonProperty()]
    public virtual string Url { get; protected set; }

}
