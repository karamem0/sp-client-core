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

[ClientObject(Name = "SP.ContentTypeCreationInformation", Id = "{168f3091-4554-4f14-8866-b20d48e45b54}")]
[JsonObject()]
public class ContentTypeCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual string Description { get; protected set; }

    [JsonProperty()]
    public virtual string Group { get; protected set; }

    [JsonProperty()]
    public virtual string Name { get; protected set; }

    [JsonProperty("ParentContentType")]
    public virtual ContentType ContentType { get; protected set; }

}
