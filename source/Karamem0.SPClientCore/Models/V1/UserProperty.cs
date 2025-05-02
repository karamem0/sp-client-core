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

[ClientObject(Name = "SP.UserProfiles.PersonProperties", Id = "{9a467bf8-bbfb-4a76-9c41-0753ecf7218f}")]
[JsonObject()]
public class UserProperty : ClientObject
{

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? DirectReports { get; set; }

    [JsonProperty()]
    public virtual string? DisplayName { get; set; }

    [JsonProperty()]
    public virtual string? Email { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExtendedManagers { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExtendedReports { get; set; }

    [JsonProperty()]
    public virtual bool IsFollowed { get; set; }

    [JsonProperty()]
    public virtual string? LatestPost { get; set; }

    [JsonProperty("AccountName")]
    public virtual string? LoginName { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? Peers { get; set; }

    [JsonProperty()]
    public virtual string? PersonalSiteHostUrl { get; set; }

    [JsonProperty()]
    public virtual string? PersonalUrl { get; set; }

    [JsonProperty()]
    public virtual string? PictureUrl { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? UserProfileProperties { get; set; }

    [JsonProperty()]
    public virtual string? UserUrl { get; set; }

}
