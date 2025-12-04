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

[ClientObject(Name = "SP.ChangeUser", Id = "{9bcb7adb-5a47-426e-886f-3ce841554cd9}")]
[JsonObject()]
public class ChangeUser : Change
{

    [JsonProperty()]
    public virtual bool Activate { get; protected set; }

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

    [JsonProperty()]
    public virtual int UserId { get; protected set; }

}
