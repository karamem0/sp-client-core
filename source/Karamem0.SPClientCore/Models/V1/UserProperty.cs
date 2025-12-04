//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.UserProfiles.PersonProperties", Id = "{9a467bf8-bbfb-4a76-9c41-0753ecf7218f}")]
[JsonObject()]
public class UserProperty : ClientObject
{

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? DirectReports { get; protected set; }

    [JsonProperty()]
    public virtual string? DisplayName { get; protected set; }

    [JsonProperty()]
    public virtual string? Email { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExtendedManagers { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? ExtendedReports { get; protected set; }

    [JsonProperty()]
    public virtual bool IsFollowed { get; protected set; }

    [JsonProperty()]
    public virtual string? LatestPost { get; protected set; }

    [JsonProperty("AccountName")]
    public virtual string? LoginName { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? Peers { get; protected set; }

    [JsonProperty()]
    public virtual Uri? PersonalSiteHostUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? PersonalUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? PictureUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? UserProfileProperties { get; protected set; }

    [JsonProperty()]
    public virtual Uri? UserUrl { get; protected set; }

}
