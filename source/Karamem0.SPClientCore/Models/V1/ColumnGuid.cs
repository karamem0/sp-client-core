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

[ClientObject(Name = "SP.FieldGuid", Id = "{768b27aa-a4e0-4cfb-9956-1f7f0e93fb42}")]
[JsonObject()]
public class ColumnGuid : Column
{

    [JsonProperty()]
    public override string? AutofillInfo { get; protected set; }

    [JsonProperty()]
    public override bool AutoIndexed { get; protected set; }

    [JsonProperty()]
    public override bool CanBeDeleted { get; protected set; }

    [JsonProperty()]
    public override string? ClientSideComponentId { get; protected set; }

    [JsonProperty()]
    public override string? ClientSideComponentProperties { get; protected set; }

    [JsonProperty("FieldTypeKind")]
    public override ColumnType ColumnType { get; protected set; }

    [JsonProperty()]
    public override string? CustomFormatter { get; protected set; }

    [JsonProperty()]
    public override string? DefaultFormula { get; protected set; }

    [JsonProperty()]
    public override string? DefaultValue { get; protected set; }

    [JsonProperty()]
    public override string? Description { get; protected set; }

    [JsonProperty()]
    public override string? Direction { get; protected set; }

    [JsonProperty()]
    public override bool EnforceUniqueValues { get; protected set; }

    [JsonProperty()]
    public override string? EntityPropertyName { get; protected set; }

    [JsonProperty()]
    public override bool Filterable { get; protected set; }

    [JsonProperty()]
    public override bool FromBaseType { get; protected set; }

    [JsonProperty()]
    public override string? Group { get; protected set; }

    [JsonProperty()]
    public override bool Hidden { get; protected set; }

    [JsonProperty()]
    public override Guid Id { get; protected set; }

    [JsonProperty()]
    public override bool Indexed { get; protected set; }

    [JsonProperty()]
    public override string? JSLink { get; protected set; }

    [JsonProperty("InternalName")]
    public override string? Name { get; protected set; }

    [JsonProperty()]
    public override bool NoCrawl { get; protected set; }

    [JsonProperty()]
    public override bool PinnedToFiltersPane { get; protected set; }

    [JsonProperty("ReadOnlyField")]
    public override bool ReadOnly { get; protected set; }

    [JsonProperty()]
    public override bool Required { get; protected set; }

    [JsonProperty()]
    public override string? SchemaXml { get; protected set; }

    [JsonProperty()]
    public override string? SchemaXmlWithResourceTokens { get; protected set; }

    [JsonProperty()]
    public override string? Scope { get; protected set; }

    [JsonProperty()]
    public override bool Sealed { get; protected set; }

    [JsonProperty()]
    public override bool ShowInFiltersPane { get; protected set; }

    [JsonProperty()]
    public override bool Sortable { get; protected set; }

    [JsonProperty()]
    public override string? StaticName { get; protected set; }

    [JsonProperty()]
    public override string? Title { get; protected set; }

    [JsonProperty()]
    public override string? TypeAsString { get; protected set; }

    [JsonProperty()]
    public override string? TypeDisplayName { get; protected set; }

    [JsonProperty()]
    public override string? TypeShortDescription { get; protected set; }

    [JsonProperty()]
    public override string? ValidationFormula { get; protected set; }

    [JsonProperty()]
    public override string? ValidationMessage { get; protected set; }

}
