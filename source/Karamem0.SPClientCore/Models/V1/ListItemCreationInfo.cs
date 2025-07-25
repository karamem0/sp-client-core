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

[ClientObject(Name = "SP.ListItemCreationInformation", Id = "{54cdbee5-0897-44ac-829f-411557fa11be}")]
[JsonObject()]
public class ListItemCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual Uri? FolderUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? LeafName { get; protected set; }

    [JsonProperty()]
    public virtual FileSystemObjectType UnderlyingObjectType { get; protected set; }

}
