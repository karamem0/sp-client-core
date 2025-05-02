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

[ClientObject(Name = "SP.FieldCurrency", Id = "{e03ca5f6-5f18-47f3-8ab4-74caba56ee1e}")]
[JsonObject()]
public class ColumnCurrency : Column
{

    [JsonProperty()]
    public override bool AutoIndexed { get; set; }

    [JsonProperty()]
    public override bool CanBeDeleted { get; set; }

    [JsonProperty()]
    public override string? ClientSideComponentId { get; set; }

    [JsonProperty()]
    public override string? ClientSideComponentProperties { get; set; }

    [JsonProperty("FieldTypeKind")]
    public override ColumnType? ColumnType { get; set; }

    [JsonProperty("CurrencyLocaleId")]
    public virtual uint CurrencyLcid { get; set; }

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

    [JsonProperty("MaximumValue")]
    public virtual double? MaxValue { get; set; }

    [JsonProperty("MinimumValue")]
    public virtual double? MinValue { get; set; }

    [JsonProperty("InternalName")]
    public override string? Name { get; set; }

    [JsonProperty()]
    public override bool NoCrawl { get; set; }

    [JsonProperty("DisplayFormat")]
    public virtual int NumberFormat { get; set; }

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
    public virtual bool ShowAsPercentage { get; set; }

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
