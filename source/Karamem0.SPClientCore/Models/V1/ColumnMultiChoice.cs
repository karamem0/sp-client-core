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

[ClientObject(Name = "SP.FieldMultiChoice", Id = "84c160f-3783-4344-a471-80e032719f26")]
[JsonObject()]
public class ColumnMultiChoice : Column
{

    [JsonProperty()]
    public override bool AutoIndexed { get; set; }

    [JsonProperty()]
    public override bool CanBeDeleted { get; set; }

    [JsonProperty()]
    public override string? ClientSideComponentId { get; set; }

    [JsonProperty()]
    public override string? ClientSideComponentProperties { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<Column>? Columns { get; set; }

    [JsonProperty("FieldTypeKind")]
    public override ColumnType? ColumnType { get; set; }

    [JsonProperty()]
    public override string? CustomFormatter { get; set; }

    [JsonProperty()]
    public override string? DefaultFormula { get; set; }

    [JsonProperty()]
    public override string? DefaultValue { get; set; }

    [JsonProperty()]
    public override string? Description { get; set; }

    [JsonProperty()]
    public override string? Direction { get; set; }

    [JsonProperty()]
    public override bool EnforceUniqueValues { get; set; }

    [JsonProperty()]
    public override string? EntityPropertyName { get; set; }

    [JsonProperty()]
    public virtual bool FillInChoice { get; set; }

    [JsonProperty()]
    public override bool Filterable { get; set; }

    [JsonProperty()]
    public override bool FromBaseType { get; set; }

    [JsonProperty()]
    public override string? Group { get; set; }

    [JsonProperty()]
    public override bool Hidden { get; set; }

    [JsonProperty()]
    public override Guid Id { get; set; }

    [JsonProperty()]
    public override bool Indexed { get; set; }

    [JsonProperty()]
    public override string? JSLink { get; set; }

    [JsonProperty()]
    public virtual string? Mappings { get; set; }

    [JsonProperty("InternalName")]
    public override string? Name { get; set; }

    [JsonProperty()]
    public override bool NoCrawl { get; set; }

    [JsonProperty()]
    public override bool PinnedToFiltersPane { get; set; }

    [JsonProperty("ReadOnlyField")]
    public override bool ReadOnly { get; set; }

    [JsonProperty()]
    public override bool Required { get; set; }

    [JsonProperty()]
    public override string? SchemaXml { get; set; }

    [JsonProperty()]
    public override string? SchemaXmlWithResourceTokens { get; set; }

    [JsonProperty()]
    public override string? Scope { get; set; }

    [JsonProperty()]
    public override bool Sealed { get; set; }

    [JsonProperty()]
    public override bool ShowInFiltersPane { get; set; }

    [JsonProperty()]
    public override bool Sortable { get; set; }

    [JsonProperty()]
    public override string? StaticName { get; set; }

    [JsonProperty()]
    public override string? Title { get; set; }

    [JsonProperty()]
    public override string? TypeAsString { get; set; }

    [JsonProperty()]
    public override string? TypeDisplayName { get; set; }

    [JsonProperty()]
    public override string? TypeShortDescription { get; set; }

    [JsonProperty()]
    public override string? ValidationFormula { get; set; }

    [JsonProperty()]
    public override string? ValidationMessage { get; set; }

}
