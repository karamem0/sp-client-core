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

[ClientObject(Name = "SP.ViewFieldCollection", Id = "{af975f76-8a94-4e6d-8325-bd1e20b7c301}")]
[JsonObject()]
public class ViewColumnEnumerable : ClientObjectEnumerable<string>
{

    [JsonProperty()]
    public virtual string? SchemaXml { get; protected set; }

}
