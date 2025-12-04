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

[ClientObject(Name = "SP.ContentTypeId", Id = "{da0f1e90-296f-480e-bc27-cefe51eff241}")]
[JsonObject()]
public class ContentTypeId(string? stringValue = null) : ClientValueObject
{

    [JsonProperty()]
    public virtual string? StringValue { get; protected set; } = stringValue;

}
