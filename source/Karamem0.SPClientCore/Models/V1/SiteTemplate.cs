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

[ClientObject(Name = "SP.WebTemplate", Id = "{2be10268-4be1-4b5a-850d-d06b137a9c40}")]
[JsonObject()]
public class SiteTemplate : ClientObject
{

    [JsonProperty()]
    public virtual string? Description { get; protected set; }

    [JsonProperty()]
    public virtual string? DisplayCategory { get; protected set; }

    [JsonProperty()]
    public virtual int Id { get; protected set; }

    [JsonProperty()]
    public virtual Uri? ImageUrl { get; protected set; }

    [JsonProperty()]
    public virtual bool IsHidden { get; protected set; }

    [JsonProperty()]
    public virtual bool IsRootWebOnly { get; protected set; }

    [JsonProperty()]
    public virtual bool IsSubWebOnly { get; protected set; }

    [JsonProperty()]
    public virtual uint Lcid { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

}
