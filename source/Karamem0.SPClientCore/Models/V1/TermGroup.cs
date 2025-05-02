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

[ClientObject(Name = "SP.Taxonomy.TermGroup", Id = "{65d76872-0b65-42de-8ebd-d76f6d3491c6}")]
[JsonObject()]
public class TermGroup : TaxonomyItem
{

    [JsonProperty("ContributorPrincipalNames")]
    public virtual IReadOnlyList<string>? Contributors { get; set; }

    [JsonProperty("CreatedDate")]
    public override DateTime Created { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty("GroupManagerPrincipalNames")]
    public virtual IReadOnlyList<string>? GroupManagers { get; set; }

    [JsonProperty()]
    public override Guid Id { get; set; }

    [JsonProperty()]
    public virtual bool IsSiteCollectionGroup { get; set; }

    [JsonProperty()]
    public virtual bool IsSystemGroup { get; set; }

    [JsonProperty("LastModifiedDate")]
    public override DateTime LastModified { get; set; }

    [JsonProperty()]
    public override string? Name { get; set; }

    [JsonProperty()]
    public override TermStore? TermStore { get; set; }

}
