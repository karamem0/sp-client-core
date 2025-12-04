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

[ClientObject(Name = "SP.FieldUrlValue", Id = "{fa8b44af-7b43-43f2-904a-bd319497011e}")]
[JsonObject()]
public class ColumnUrlValue(Uri? url = null, string? description = null) : ClientValueObject
{

    [JsonProperty()]
    public virtual string? Description { get; protected set; } = description;

    [JsonProperty()]
    public virtual Uri? Url { get; protected set; } = url;

}
