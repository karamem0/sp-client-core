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

[ClientObject(Name = "SP.ChangeSite", Id = "{81aff0de-302e-4d01-91d5-96192f77bc29}")]
[JsonObject()]
public class ChangeSiteCollection : Change
{

    [JsonProperty()]
    public override ChangeToken? ChangeToken { get; protected set; }

    [JsonProperty()]
    public override ChangeType ChangeType { get; protected set; }

    [JsonProperty()]
    public override string? RelativeTime { get; protected set; }

    [JsonProperty("SiteId")]
    public override Guid SiteCollectionId { get; protected set; }

    [JsonProperty()]
    public override DateTime Time { get; protected set; }

}
