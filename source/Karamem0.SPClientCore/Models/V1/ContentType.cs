//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ContentType", Id = "{91b5bd2d-e133-486f-b727-197ce5eb2c0d}")]
[JsonObject()]
public class ContentType : ClientObject
{

    [JsonProperty()]
    public virtual string? ClientFormCustomFormatter { get; protected set; }

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual string? DisplayFormTemplateName { get; protected set; }

    [JsonProperty()]
    public virtual Uri? DisplayFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? DocumentTemplate { get; protected set; }

    [JsonProperty()]
    public virtual Uri? DocumentTemplateUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? EditFormTemplateName { get; protected set; }

    [JsonProperty()]
    public virtual Uri? EditFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? Group { get; protected set; }

    [JsonProperty()]
    public virtual bool Hidden { get; protected set; }

    [JsonProperty()]
    public virtual ContentTypeId? Id { get; protected set; }

    [JsonProperty()]
    public virtual string? JSLink { get; protected set; }

    [JsonProperty()]
    public virtual Uri? MobileDisplayFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? MobileEditFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual Uri? MobileNewFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

    [JsonProperty()]
    public virtual string? NewFormTemplateName { get; protected set; }

    [JsonProperty()]
    public virtual Uri? NewFormUrl { get; protected set; }

    [JsonProperty()]
    public virtual bool ReadOnly { get; protected set; }

    [JsonProperty()]
    public virtual string? SchemaXml { get; protected set; }

    [JsonProperty()]
    public virtual string? SchemaXmlWithResourceTokens { get; protected set; }

    [JsonProperty()]
    public virtual string? Scope { get; protected set; }

    [JsonProperty()]
    public virtual bool Sealed { get; protected set; }

    [JsonProperty()]
    public virtual string? StringId { get; protected set; }

}
