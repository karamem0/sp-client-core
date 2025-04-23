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

[ClientObject(Name = "SP.ResourcePath", Id = "{a265a356-274b-4e6c-b0ef-bbc22bd0969a}")]
[JsonObject()]
public class ResourcePath : ClientValueObject
{

    [JsonProperty()]
    public virtual string DecodedUrl { get; protected set; }

}
