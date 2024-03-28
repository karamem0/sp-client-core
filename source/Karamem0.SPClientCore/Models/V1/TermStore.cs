//
// Copyright (c) 2018-2024 karamem0
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

[ClientObject(Name = "SP.Taxonomy.TermStore", Id = "{9d8a8884-b1dc-4dbc-81c5-ddea8ad3184c}")]
[JsonObject()]
public class TermStore : ClientObject
{

    public TermStore()
    {
    }

    [JsonProperty()]
    public virtual string ContentTypePublishingHub { get; protected set; }

    [JsonProperty("DefaultLanguage")]
    public virtual uint DefaultLcid { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty()]
    public virtual bool IsOnline { get; protected set; }

    [JsonProperty("Languages")]
    public virtual IReadOnlyList<uint> Lcids { get; protected set; }

    [JsonProperty()]
    public virtual string Name { get; protected set; }

    [JsonProperty("WorkingLanguage")]
    public virtual uint WorkingLcid { get; protected set; }

}
