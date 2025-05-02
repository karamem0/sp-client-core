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

[ClientObject(Name = "SP.File", Id = "{df28be1e-74b5-4b21-b73a-2bbac0a23d8a}")]
[JsonObject()]
public class File : ClientObject
{

    [JsonProperty()]
    public virtual User? Author { get; set; }

    [JsonProperty()]
    public virtual string? CheckInComment { get; set; }

    [JsonProperty()]
    public virtual CheckOutType? CheckOutType { get; set; }

    [JsonProperty("CheckedOutByUser")]
    public virtual User? CheckOutUser { get; set; }

    [JsonProperty()]
    public virtual string? ContentTag { get; set; }

    [JsonProperty("TimeCreated")]
    public virtual DateTime Created { get; set; }

    [JsonProperty()]
    public virtual int CustomizedPageStatus { get; set; }

    [JsonProperty("ModifiedBy")]
    public virtual User? Editor { get; set; }

    [JsonProperty()]
    public virtual string? ETag { get; set; }

    [JsonProperty()]
    public virtual bool Exists { get; set; }

    [JsonProperty()]
    public virtual bool ExistsAllowThrowForPolicyFailures { get; set; }

    [JsonProperty()]
    public virtual bool ExistsWithException { get; set; }

    [JsonProperty()]
    public virtual bool IrmEnabled { get; set; }

    [JsonProperty("TimeLastModified")]
    public virtual DateTime LastModified { get; set; }

    [JsonProperty()]
    public virtual long Length { get; set; }

    [JsonProperty()]
    public virtual byte? Level { get; set; }

    [JsonProperty()]
    public virtual string? LinkingUri { get; set; }

    [JsonProperty()]
    public virtual string? LinkingUrl { get; set; }

    [JsonProperty("LockedByUser")]
    public virtual User? LockUser { get; set; }

    [JsonProperty()]
    public virtual int MajorVersion { get; set; }

    [JsonProperty()]
    public virtual int MinorVersion { get; set; }

    [JsonProperty()]
    public virtual string? Name { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual int UIVersion { get; set; }

    [JsonProperty()]
    public virtual string? UIVersionLabel { get; set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; set; }

}
