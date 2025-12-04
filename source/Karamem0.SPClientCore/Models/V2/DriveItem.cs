//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Models.V2;

[JsonObject()]
public class DriveItem : ODataV2Object
{

    [JsonProperty("createdBy")]
    public virtual IdentitySet? Author { get; protected set; }

    [JsonProperty("createdDateTime")]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty("cTag")]
    public virtual string? CTag { get; protected set; }

    [JsonProperty("@content.downloadUrl")]
    public virtual Uri? DownloadUrl { get; protected set; }

    [JsonProperty("lastModifiedBy")]
    public virtual IdentitySet? Editor { get; protected set; }

    [JsonProperty("eTag")]
    public virtual string? ETag { get; protected set; }

    [JsonProperty("file")]
    public virtual File? File { get; protected set; }

    [JsonProperty("fileSystemInfo")]
    public virtual FileSystemInfo? FileSystemInfo { get; protected set; }

    [JsonProperty("folder")]
    public virtual Folder? Folder { get; protected set; }

    [JsonProperty("id")]
    public virtual string? Id { get; protected set; }

    [JsonProperty("lastModifiedDateTime")]
    public virtual DateTime LastModified { get; protected set; }

    [JsonProperty("name")]
    public virtual string? Name { get; protected set; }

    [JsonProperty("parentReference")]
    public virtual ItemReference? ParentReference { get; protected set; }

    [JsonProperty("sharepointIds")]
    public virtual SharePointIds? SharePointIds { get; protected set; }

    [JsonProperty("size")]
    public virtual double Size { get; protected set; }

    [JsonProperty("webUrl")]
    public virtual Uri? WebUrl { get; protected set; }

}
