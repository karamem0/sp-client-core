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

[ClientObject(Name = "SP.Taxonomy.TaxonomyItem", Id = "{5f6011b8-fae0-4784-8882-85765261d951}")]
[JsonObject()]
public class TaxonomyItem : ClientObject
{

    [JsonProperty("CreatedDate")]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty()]
    public virtual Guid Id { get; protected set; }

    [JsonProperty("LastModifiedDate")]
    public virtual DateTime LastModified { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

    [JsonProperty()]
    public virtual TermStore? TermStore { get; protected set; }

}
