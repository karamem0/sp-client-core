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

[ClientObject(Name = "SP.UserProfiles.UserProfile", Id = "{a3b3b313-df8c-4192-b623-57b8fa3872d9}")]
[JsonObject()]
public class UserProfile : ClientObject
{

    [JsonProperty()]
    public virtual string? AccountName { get; protected set; }

    [JsonProperty()]
    public virtual string? DisplayName { get; protected set; }

    [JsonProperty()]
    public virtual Uri? FollowPersonalSiteUrl { get; protected set; }

    [JsonProperty()]
    public virtual bool IsDefaultDocumentLibraryBlocked { get; protected set; }

    [JsonProperty()]
    public virtual bool IsPeopleListPublic { get; protected set; }

    [JsonProperty()]
    public virtual bool IsPrivacySettingOn { get; protected set; }

    [JsonProperty()]
    public virtual bool IsSelf { get; protected set; }

    [JsonProperty()]
    public virtual string? JobTitle { get; protected set; }

    [JsonProperty("MySiteFirstRunExperience")]
    public virtual int MySiteCollectionFirstRunExperience { get; protected set; }

    [JsonProperty("MySiteHostUrl")]
    public virtual Uri? MySiteCollectionHostUrl { get; protected set; }

    [JsonProperty()]
    public virtual int O15FirstRunExperience { get; protected set; }

    [JsonProperty()]
    public virtual SiteCollection? PersonalSite { get; protected set; }

    [JsonProperty()]
    public virtual PersonalSiteCapabilities? PersonalSiteCapabilities { get; protected set; }

    [JsonProperty()]
    public virtual string? PersonalSiteFirstCreationError { get; protected set; }

    [JsonProperty()]
    public virtual DateTime PersonalSiteFirstCreationTime { get; protected set; }

    [JsonProperty()]
    public virtual PersonalSiteInstantiationState? PersonalSiteInstantiationState { get; protected set; }

    [JsonProperty()]
    public virtual DateTime PersonalSiteLastCreationTime { get; protected set; }

    [JsonProperty()]
    public virtual int PersonalSiteNumberOfRetries { get; protected set; }

    [JsonProperty()]
    public virtual bool PictureImportEnabled { get; protected set; }

    [JsonProperty()]
    public virtual Uri? PictureUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? PublicUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? SipAddress { get; protected set; }

    [JsonProperty()]
    public virtual Uri? UrlToCreatePersonalSite { get; protected set; }

}
