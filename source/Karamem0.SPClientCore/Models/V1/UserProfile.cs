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
    public virtual string? AccountName { get; set; }

    [JsonProperty()]
    public virtual string? DisplayName { get; set; }

    [JsonProperty()]
    public virtual string? FollowPersonalSiteUrl { get; set; }

    [JsonProperty()]
    public virtual bool IsDefaultDocumentLibraryBlocked { get; set; }

    [JsonProperty()]
    public virtual bool IsPeopleListPublic { get; set; }

    [JsonProperty()]
    public virtual bool IsPrivacySettingOn { get; set; }

    [JsonProperty()]
    public virtual bool IsSelf { get; set; }

    [JsonProperty()]
    public virtual string? JobTitle { get; set; }

    [JsonProperty("MySiteFirstRunExperience")]
    public virtual int MySiteCollectionFirstRunExperience { get; set; }

    [JsonProperty("MySiteHostUrl")]
    public virtual string? MySiteCollectionHostUrl { get; set; }

    [JsonProperty()]
    public virtual int O15FirstRunExperience { get; set; }

    [JsonProperty()]
    public virtual SiteCollection? PersonalSite { get; set; }

    [JsonProperty()]
    public virtual PersonalSiteCapabilities? PersonalSiteCapabilities { get; set; }

    [JsonProperty()]
    public virtual string? PersonalSiteFirstCreationError { get; set; }

    [JsonProperty()]
    public virtual DateTime PersonalSiteFirstCreationTime { get; set; }

    [JsonProperty()]
    public virtual PersonalSiteInstantiationState? PersonalSiteInstantiationState { get; set; }

    [JsonProperty()]
    public virtual DateTime PersonalSiteLastCreationTime { get; set; }

    [JsonProperty()]
    public virtual int PersonalSiteNumberOfRetries { get; set; }

    [JsonProperty()]
    public virtual bool PictureImportEnabled { get; set; }

    [JsonProperty()]
    public virtual string? PictureUrl { get; set; }

    [JsonProperty()]
    public virtual string? PublicUrl { get; set; }

    [JsonProperty()]
    public virtual string? SipAddress { get; set; }

    [JsonProperty()]
    public virtual string? UrlToCreatePersonalSite { get; set; }

}
