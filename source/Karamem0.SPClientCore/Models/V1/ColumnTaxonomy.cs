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

[ClientObject(Name = "SP.Taxonomy.TaxonomyField", Id = "{0831c0f3-c1b9-4d8a-a339-0160f42257b4}")]
[JsonObject()]
public class ColumnTaxonomy : Column
{

    [JsonProperty()]
    public virtual bool AllowMultipleValues { get; set; }

    [JsonProperty()]
    public virtual Guid AnchorId { get; set; }

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

    [JsonProperty()]
    public virtual bool CreateValuesInEditForm { get; set; }

    [JsonProperty()]
    public override string? CustomFormatter { get; set; }

    [JsonProperty()]
    public override string? DefaultFormula { get; set; }

    [JsonProperty()]
    public override string? DefaultValue { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? DependentLookupInternalNames { get; set; }

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

    [JsonProperty("TextField")]
    public virtual Guid HiddenColumnId { get; set; }

    [JsonProperty()]
    public override Guid Id { get; set; }

    [JsonProperty()]
    public override bool Indexed { get; set; }

    [JsonProperty()]
    public virtual bool IsAnchorValid { get; set; }

    [JsonProperty()]
    public virtual bool IsDependentLookup { get; set; }

    [JsonProperty()]
    public virtual bool IsKeyword { get; set; }

    [JsonProperty()]
    public virtual bool IsPathRendered { get; set; }

    [JsonProperty()]
    public virtual bool IsRelationship { get; set; }

    [JsonProperty()]
    public virtual bool IsTermSetValid { get; set; }

    [JsonProperty()]
    public override string? JSLink { get; set; }

    [JsonProperty("LookupField")]
    public virtual string? LookupColumnName { get; set; }

    [JsonProperty("LookupList")]
    public virtual Guid LookupListId { get; set; }

    [JsonProperty("LookupWebId")]
    public virtual Guid LookupSiteId { get; set; }

    [JsonProperty("InternalName")]
    public override string? Name { get; set; }

    [JsonProperty()]
    public override bool NoCrawl { get; set; }

    [JsonProperty()]
    public virtual bool Open { get; set; }

    [JsonProperty()]
    public override bool PinnedToFiltersPane { get; set; }

    [JsonProperty("PrimaryFieldId")]
    public virtual string? PrimaryColumnId { get; set; }

    [JsonProperty("ReadOnlyField")]
    public override bool ReadOnly { get; set; }

    [JsonProperty()]
    public virtual RelationshipDeleteBehaviorType? RelationshipDeleteBehavior { get; set; }

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
    public virtual string? TargetTemplate { get; set; }

    [JsonProperty()]
    public virtual Guid TermSetId { get; set; }

    [JsonProperty("SspId")]
    public virtual Guid TermStoreId { get; set; }

    [JsonProperty()]
    public override string? Title { get; set; }

    [JsonProperty()]
    public override string? TypeAsString { get; set; }

    [JsonProperty()]
    public override string? TypeDisplayName { get; set; }

    [JsonProperty()]
    public override string? TypeShortDescription { get; set; }

    [JsonProperty()]
    public virtual bool UnlimitedLengthInDocumentLibrary { get; set; }

    [JsonProperty()]
    public virtual bool UserCreated { get; set; }

    [JsonProperty()]
    public override string? ValidationFormula { get; set; }

    [JsonProperty()]
    public override string? ValidationMessage { get; set; }

}
