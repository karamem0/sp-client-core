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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.CamlQuery", Id = "{3d248d7b-fc86-40a3-aa97-02a75d69fb8a}")]
[JsonObject()]
public class CamlQuery : ClientValueObject
{

    [JsonProperty()]
    [DefaultValue(true)]
    public virtual bool DatesInUtc { get; protected set; }

    [JsonProperty()]
    public virtual Uri? FolderServerRelativeUrl { get; protected set; }

    [JsonProperty()]
    public virtual ListItemCollectionPosition? ListItemCollectionPosition { get; protected set; }

    [JsonProperty()]
    public virtual string? ViewXml { get; protected set; }

}
