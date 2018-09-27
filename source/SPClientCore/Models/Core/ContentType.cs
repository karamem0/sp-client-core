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

    [JsonObject(Id = "SP.ContentType")]
    public class ContentType : ClientObject
    {

        public ContentType()
        {
        }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string DisplayFormTemplateName { get; private set; }

        [JsonProperty()]
        public string DisplayFormUrl { get; private set; }

        [JsonProperty()]
        public string DocumentTemplate { get; private set; }

        [JsonProperty()]
        public string DocumentTemplateUrl { get; private set; }

        [JsonProperty()]
        public string EditFormTemplateName { get; private set; }

        [JsonProperty()]
        public string EditFormUrl { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<FieldLink> FieldLinks { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Field> Fields { get; private set; }

        [JsonProperty()]
        public string Group { get; private set; }

        [JsonProperty()]
        public bool? Hidden { get; private set; }

        [JsonProperty()]
        public ContentTypeId Id { get; private set; }

        [JsonProperty()]
        public string JSLink { get; private set; }

        [JsonProperty()]
        public string MobileDisplayFormUrl { get; private set; }

        [JsonProperty()]
        public string MobileEditFormUrl { get; private set; }

        [JsonProperty()]
        public string MobileNewFormUrl { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty()]
        public string NewFormTemplateName { get; private set; }

        [JsonProperty()]
        public string NewFormUrl { get; private set; }

        [JsonProperty()]
        public ContentType Parent { get; private set; }

        [JsonProperty()]
        public bool? ReadOnly { get; private set; }

        [JsonProperty()]
        public string SchemaXml { get; private set; }

        [JsonProperty()]
        public string SchemaXmlWithResourceTokens { get; private set; }

        [JsonProperty()]
        public string Scope { get; private set; }

        [JsonProperty()]
        public bool? Sealed { get; private set; }

        [JsonProperty()]
        public string StringId { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<WorkflowAssociation> WorkflowAssociations { get; private set; }

    }

}
