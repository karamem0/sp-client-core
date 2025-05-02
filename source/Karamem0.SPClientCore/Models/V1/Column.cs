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

[ClientObject(Name = "SP.Field", Id = "{c4121b04-0f57-4b1d-a145-d25426b16480}")]
[JsonObject()]
public class Column : ClientObject
{

    [JsonProperty()]
    public virtual bool AutoIndexed { get; set; }

    [JsonProperty()]
    public virtual bool CanBeDeleted { get; set; }

    [JsonProperty()]
    public virtual string? ClientSideComponentId { get; set; }

    [JsonProperty()]
    public virtual string? ClientSideComponentProperties { get; set; }

    [JsonProperty()]
    public virtual string? ClientValidationFormula { get; set; }

    [JsonProperty()]
    public virtual string? ClientValidationMessage { get; set; }

    [JsonProperty("FieldTypeKind")]
    public virtual ColumnType? ColumnType { get; set; }

    [JsonProperty()]
    public virtual string? CustomFormatter { get; set; }

    [JsonProperty()]
    public virtual string? DefaultFormula { get; set; }

    [JsonProperty()]
    public virtual string? DefaultValue { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual string? Direction { get; set; }

    [JsonProperty()]
    public virtual bool EnforceUniqueValues { get; set; }

    [JsonProperty()]
    public virtual string? EntityPropertyName { get; set; }

    [JsonProperty()]
    public virtual bool Filterable { get; set; }

    [JsonProperty()]
    public virtual bool FromBaseType { get; set; }

    [JsonProperty()]
    public virtual string? Group { get; set; }

    [JsonProperty()]
    public virtual bool Hidden { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual bool Indexed { get; set; }

    [JsonProperty()]
    public virtual IndexStatus? IndexStatus { get; set; }

    [JsonProperty()]
    public virtual bool IsModern { get; set; }

    [JsonProperty()]
    public virtual string? JSLink { get; set; }

    [JsonProperty("InternalName")]
    public virtual string? Name { get; set; }

    [JsonProperty()]
    public virtual bool NoCrawl { get; set; }

    [JsonProperty()]
    public virtual bool PinnedToFiltersPane { get; set; }

    [JsonProperty("ReadOnlyField")]
    public virtual bool ReadOnly { get; set; }

    [JsonProperty()]
    public virtual bool Required { get; set; }

    [JsonProperty()]
    public virtual string? SchemaXml { get; set; }

    [JsonProperty()]
    public virtual string? SchemaXmlWithResourceTokens { get; set; }

    [JsonProperty()]
    public virtual string? Scope { get; set; }

    [JsonProperty()]
    public virtual bool Sealed { get; set; }

    [JsonProperty()]
    public virtual bool ShowInFiltersPane { get; set; }

    [JsonProperty()]
    public virtual bool Sortable { get; set; }

    [JsonProperty()]
    public virtual string? StaticName { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual string? TypeAsString { get; set; }

    [JsonProperty()]
    public virtual string? TypeDisplayName { get; set; }

    [JsonProperty()]
    public virtual string? TypeShortDescription { get; set; }

    [JsonProperty()]
    public virtual string? ValidationFormula { get; set; }

    [JsonProperty()]
    public virtual string? ValidationMessage { get; set; }

}
