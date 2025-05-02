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

[ClientObject(Name = "SP.ContentType", Id = "{91b5bd2d-e133-486f-b727-197ce5eb2c0d}")]
[JsonObject()]
public class ContentType : ClientObject
{

    [JsonProperty()]
    public virtual string? ClientFormCustomFormatter { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual string? DisplayFormTemplateName { get; set; }

    [JsonProperty()]
    public virtual string? DisplayFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? DocumentTemplate { get; set; }

    [JsonProperty()]
    public virtual string? DocumentTemplateUrl { get; set; }

    [JsonProperty()]
    public virtual string? EditFormTemplateName { get; set; }

    [JsonProperty()]
    public virtual string? EditFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? Group { get; set; }

    [JsonProperty()]
    public virtual bool Hidden { get; set; }

    [JsonProperty()]
    public virtual ContentTypeId? Id { get; set; }

    [JsonProperty()]
    public virtual string? JSLink { get; set; }

    [JsonProperty()]
    public virtual string? MobileDisplayFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? MobileEditFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? MobileNewFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? Name { get; set; }

    [JsonProperty()]
    public virtual string? NewFormTemplateName { get; set; }

    [JsonProperty()]
    public virtual string? NewFormUrl { get; set; }

    [JsonProperty()]
    public virtual bool ReadOnly { get; set; }

    [JsonProperty()]
    public virtual string? SchemaXml { get; set; }

    [JsonProperty()]
    public virtual string? SchemaXmlWithResourceTokens { get; set; }

    [JsonProperty()]
    public virtual string? Scope { get; set; }

    [JsonProperty()]
    public virtual bool Sealed { get; set; }

    [JsonProperty()]
    public virtual string? StringId { get; set; }

}
