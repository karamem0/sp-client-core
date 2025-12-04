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

[ClientObject(Name = "SP.FileVersion", Id = "{96e4bc1b-e67f-4967-9327-36b79e20aebc}")]
[JsonObject()]
public class FileVersion : ClientObject
{

    [JsonProperty()]
    public virtual string? CheckInComment { get; protected set; }

    [JsonProperty()]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty("ID")]
    public virtual int Id { get; protected set; }

    [JsonProperty()]
    public virtual bool IsCurrentVersion { get; protected set; }

    [JsonProperty()]
    public virtual int Length { get; protected set; }

    [JsonProperty()]
    public virtual int Size { get; protected set; }

    [JsonProperty()]
    public virtual Uri? Url { get; protected set; }

    [JsonProperty()]
    public virtual string? VersionLabel { get; protected set; }

}
