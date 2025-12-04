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

[ClientObject(Name = "SP.File", Id = "{df28be1e-74b5-4b21-b73a-2bbac0a23d8a}")]
[JsonObject()]
public class File : ClientObject
{

    [JsonProperty()]
    public virtual User? Author { get; protected set; }

    [JsonProperty()]
    public virtual string? CheckInComment { get; protected set; }

    [JsonProperty()]
    public virtual CheckOutType CheckOutType { get; protected set; }

    [JsonProperty("CheckedOutByUser")]
    public virtual User? CheckOutUser { get; protected set; }

    [JsonProperty()]
    public virtual string? ContentTag { get; protected set; }

    [JsonProperty("TimeCreated")]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty()]
    public virtual int CustomizedPageStatus { get; protected set; }

    [JsonProperty("ModifiedBy")]
    public virtual User? Editor { get; protected set; }

    [JsonProperty()]
    public virtual string? ETag { get; protected set; }

    [JsonProperty()]
    public virtual bool Exists { get; protected set; }

    [JsonProperty()]
    public virtual bool ExistsAllowThrowForPolicyFailures { get; protected set; }

    [JsonProperty()]
    public virtual bool ExistsWithException { get; protected set; }

    [JsonProperty()]
    public virtual bool IrmEnabled { get; protected set; }

    [JsonProperty("TimeLastModified")]
    public virtual DateTime LastModified { get; protected set; }

    [JsonProperty()]
    public virtual long Length { get; protected set; }

    [JsonProperty()]
    public virtual byte Level { get; protected set; }

    [JsonProperty()]
    public virtual string? LinkingUri { get; protected set; }

    [JsonProperty()]
    public virtual Uri? LinkingUrl { get; protected set; }

    [JsonProperty("LockedByUser")]
    public virtual User? LockUser { get; protected set; }

    [JsonProperty()]
    public virtual int MajorVersion { get; protected set; }

    [JsonProperty()]
    public virtual int MinorVersion { get; protected set; }

    [JsonProperty()]
    public virtual string? Name { get; protected set; }

    [JsonProperty()]
    public virtual Uri? ServerRelativeUrl { get; protected set; }

    [JsonProperty()]
    public virtual string? Title { get; protected set; }

    [JsonProperty()]
    public virtual int UIVersion { get; protected set; }

    [JsonProperty()]
    public virtual string? UIVersionLabel { get; protected set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; protected set; }

}
