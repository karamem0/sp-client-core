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

[ClientObject(Name = "SP.Folder", Id = "{dbe8175a-505d-4eff-bec4-6c809709808b}")]
[JsonObject()]
public class Folder : ClientObject
{

    [JsonProperty()]
    public virtual IReadOnlyCollection<ContentTypeId>? ContentTypeOrder { get; set; }

    [JsonProperty("TimeCreated")]
    public virtual DateTime Created { get; set; }

    [JsonProperty()]
    public virtual bool Exists { get; set; }

    [JsonProperty()]
    public virtual bool ExistsAllowThrowForPolicyFailures { get; set; }

    [JsonProperty()]
    public virtual bool ExistsWithException { get; set; }

    [JsonProperty()]
    public virtual bool IsWOPIEnabled { get; set; }

    [JsonProperty()]
    public virtual int ItemCount { get; set; }

    [JsonProperty("TimeLastModified")]
    public virtual DateTime LastModified { get; set; }

    [JsonProperty()]
    public virtual string? Name { get; set; }

    [JsonProperty("ProgID")]
    public virtual string? ProgId { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<ContentTypeId>? UniqueContentTypeOrder { get; set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; set; }

    [JsonProperty()]
    public virtual string? WelcomePage { get; set; }

}
