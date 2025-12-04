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

[ClientObject(Name = "SP.FolderColoringInformation", Id = "{a5d5cda2-d935-4dd3-96df-aad071feb9aa}")]
[JsonObject()]
public class FolderColoringInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string? ColorHex { get; protected set; }

    [JsonProperty()]
    public virtual string? ColorTag { get; protected set; }

    [JsonProperty()]
    public virtual string? Emoji { get; protected set; }

}
