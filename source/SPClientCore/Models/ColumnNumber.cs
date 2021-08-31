//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.FieldNumber", Id = "{e03ca5f6-5f18-47f3-8ab4-74caba56ee1e}")]
    [JsonObject()]
    public class ColumnNumber : Column
    {

        public ColumnNumber()
        {
        }

        [JsonProperty()]
        public override bool AutoIndexed { get; protected set; }

        [JsonProperty()]
        public override bool CanBeDeleted { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentId { get; protected set; }

        [JsonProperty()]
        public override string ClientSideComponentProperties { get; protected set; }

        [JsonProperty("FieldTypeKind")]
        public override ColumnType ColumnType { get; protected set; }

        [JsonProperty()]
        public override string CustomFormatter { get; protected set; }

        [JsonProperty()]
        public override string DefaultFormula { get; protected set; }

        [JsonProperty()]
        public override string DefaultValue { get; protected set; }

        [JsonProperty()]
        public override string Description { get; protected set; }

        [JsonProperty()]
        public override string Direction { get; protected set; }

        [JsonProperty()]
        public override bool EnforceUniqueValues { get; protected set; }

        [JsonProperty()]
        public override string EntityPropertyName { get; protected set; }

        [JsonProperty()]
        public override bool Filterable { get; protected set; }

        [JsonProperty()]
        public override bool FromBaseType { get; protected set; }

        [JsonProperty()]
        public override string Group { get; protected set; }

        [JsonProperty()]
        public override bool Hidden { get; protected set; }

        [JsonProperty()]
        public override Guid Id { get; protected set; }

        [JsonProperty()]
        public override bool Indexed { get; protected set; }

        [JsonProperty()]
        public override string JSLink { get; protected set; }

        [JsonProperty("MaximumValue")]
        public virtual double MaxValue { get; protected set; }

        [JsonProperty("MinimumValue")]
        public virtual double MinValue { get; protected set; }

        [JsonProperty("InternalName")]
        public override string Name { get; protected set; }

        [JsonProperty()]
        public override bool NoCrawl { get; protected set; }

        [JsonProperty("DisplayFormat")]
        public virtual int NumberFormat { get; protected set; }

        [JsonProperty()]
        public override bool PinnedToFiltersPane { get; protected set; }

        [JsonProperty("ReadOnlyField")]
        public override bool ReadOnly { get; protected set; }

        [JsonProperty()]
        public override bool Required { get; protected set; }

        [JsonProperty()]
        public override string SchemaXml { get; protected set; }

        [JsonProperty()]
        public override string SchemaXmlWithResourceTokens { get; protected set; }

        [JsonProperty()]
        public virtual bool ShowAsPercentage { get; protected set; }

        [JsonProperty()]
        public override string Scope { get; protected set; }

        [JsonProperty()]
        public override bool Sealed { get; protected set; }

        [JsonProperty()]
        public override bool ShowInFiltersPane { get; protected set; }

        [JsonProperty()]
        public override bool Sortable { get; protected set; }

        [JsonProperty()]
        public override string StaticName { get; protected set; }

        [JsonProperty()]
        public override string Title { get; protected set; }

        [JsonProperty()]
        public override string TypeAsString { get; protected set; }

        [JsonProperty()]
        public override string TypeDisplayName { get; protected set; }

        [JsonProperty()]
        public override string TypeShortDescription { get; protected set; }

        [JsonProperty()]
        public override string ValidationFormula { get; protected set; }

        [JsonProperty()]
        public override string ValidationMessage { get; protected set; }

    }

}
