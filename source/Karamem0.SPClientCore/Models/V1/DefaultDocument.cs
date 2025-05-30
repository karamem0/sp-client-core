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

[ClientObject(Name = "SP.DocumentSet.DefaultDocument", Id = "{7295eb25-e721-42b6-aac9-cbb6c39afc54}")]
[JsonObject()]
public class DefaultDocument : ClientObject
{

    [JsonProperty()]
    public virtual ContentTypeId? ContentTypeId { get; protected set; }

    [JsonProperty()]
    public virtual ResourcePath? DocumentPath { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

}
