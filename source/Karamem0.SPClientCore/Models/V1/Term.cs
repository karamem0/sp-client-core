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

[ClientObject(Name = "SP.Taxonomy.Term", Id = "{5b8c81b7-7cd2-40dc-8525-5eca12a4eb73}")]
[JsonObject()]
public class Term : TermSetItem
{

    [JsonProperty("CreatedDate")]
    public override DateTime Created { get; set; }

    [JsonProperty()]
    public override IReadOnlyDictionary<string, string>? CustomProperties { get; set; }

    [JsonProperty()]
    public override string? CustomSortOrder { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public override Guid Id { get; set; }

    [JsonProperty()]
    public override bool IsAvailableForTagging { get; set; }

    [JsonProperty()]
    public virtual bool IsDeprecated { get; set; }

    [JsonProperty()]
    public virtual bool IsKeyword { get; set; }

    [JsonProperty()]
    public virtual bool IsPinned { get; set; }

    [JsonProperty()]
    public virtual bool IsPinnedRoot { get; set; }

    [JsonProperty()]
    public virtual bool IsReused { get; set; }

    [JsonProperty()]
    public virtual bool IsRoot { get; set; }

    [JsonProperty()]
    public virtual bool IsSourceTerm { get; set; }

    [JsonProperty("LastModifiedDate")]
    public override DateTime LastModified { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyDictionary<string, string>? LocalCustomProperties { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyList<Guid>? MergedTermIds { get; set; }

    [JsonProperty()]
    public override string? Name { get; set; }

    [JsonProperty()]
    public virtual string? PathOfTerm { get; set; }

    [JsonProperty()]
    public override string? Owner { get; set; }

    [JsonProperty()]
    public virtual int TermsCount { get; set; }

    [JsonProperty()]
    public override TermStore? TermStore { get; set; }

}
