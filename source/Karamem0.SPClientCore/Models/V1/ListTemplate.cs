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

[ClientObject(Name = "SP.ListTemplate", Id = "{d772ecd1-daa3-4cb1-9ea1-feea1e383fb2}")]
[JsonObject()]
public class ListTemplate : ClientObject
{

    [JsonProperty()]
    public virtual bool AllowsFolderCreation { get; set; }

    [JsonProperty()]
    public virtual BaseType? BaseType { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual Guid FeatureId { get; set; }

    [JsonProperty()]
    public virtual bool Hidden { get; set; }

    [JsonProperty()]
    public virtual string? ImageUrl { get; set; }

    [JsonProperty("InternalName")]
    public virtual string? Name { get; set; }

    [JsonProperty()]
    public virtual bool IsCustomTemplate { get; set; }

    [JsonProperty()]
    public virtual int ListTemplateTypeKind { get; set; }

    [JsonProperty("Name")]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual bool OnQuickLaunch { get; set; }

    [JsonProperty()]
    public virtual bool Unique { get; set; }

}
