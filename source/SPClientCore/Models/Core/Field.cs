//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.Field")]
    public class Field : ClientObject
    {

        public Field()
        {
        }

        [JsonProperty()]
        public bool? AutoIndexed { get; private set; }

        [JsonProperty()]
        public bool? CanBeDeleted { get; private set; }

        [JsonProperty()]
        public string ClientSideComponentId { get; private set; }

        [JsonProperty()]
        public string ClientSideComponentProperties { get; private set; }

        [JsonProperty()]
        public string CustomFormatter { get; private set; }

        [JsonProperty()]
        public string DefaultFormula { get; private set; }

        [JsonProperty()]
        public string DefaultValue { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string Direction { get; private set; }

        [JsonProperty()]
        public bool? EnforceUniqueValues { get; private set; }

        [JsonProperty()]
        public string EntityPropertyName { get; private set; }

        [JsonProperty()]
        public FieldTypeKind? FieldTypeKind { get; private set; }

        [JsonProperty()]
        public bool? Filterable { get; private set; }

        [JsonProperty()]
        public bool? FromBaseType { get; private set; }

        [JsonProperty()]
        public string Group { get; private set; }

        [JsonProperty()]
        public bool? Hidden { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public bool? Indexed { get; private set; }

        [JsonProperty()]
        public string InternalName { get; private set; }

        [JsonProperty()]
        public string JSLink { get; private set; }

        [JsonProperty()]
        public int? MaxLength { get; private set; }

        [JsonProperty()]
        public bool? PinnedToFiltersPane { get; private set; }

        [JsonProperty()]
        public bool? ReadOnlyField { get; private set; }

        [JsonProperty()]
        public bool? Required { get; private set; }

        [JsonProperty()]
        public string SchemaXml { get; private set; }

        [JsonProperty()]
        public string SchemaXmlWithResourceTokens { get; private set; }

        [JsonProperty()]
        public string Scope { get; private set; }

        [JsonProperty()]
        public bool? Sealed { get; private set; }

        [JsonProperty()]
        public bool? ShowInFiltersPane { get; private set; }

        [JsonProperty()]
        public bool? Sortable { get; private set; }

        [JsonProperty()]
        public string StaticName { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string TypeAsstring { get; private set; }

        [JsonProperty()]
        public string TypeDisplayName { get; private set; }

        [JsonProperty()]
        public string TypeShortDescription { get; private set; }

        [JsonProperty()]
        public string ValidationFormula { get; private set; }

        [JsonProperty()]
        public string ValidationMessage { get; private set; }

    }

}
