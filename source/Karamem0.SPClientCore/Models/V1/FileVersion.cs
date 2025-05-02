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

[ClientObject(Name = "SP.FileVersion", Id = "{96e4bc1b-e67f-4967-9327-36b79e20aebc}")]
[JsonObject()]
public class FileVersion : ClientObject
{

    [JsonProperty()]
    public virtual string? CheckInComment { get; set; }

    [JsonProperty()]
    public virtual DateTime Created { get; set; }

    [JsonProperty("ID")]
    public virtual int Id { get; set; }

    [JsonProperty()]
    public virtual bool IsCurrentVersion { get; set; }

    [JsonProperty()]
    public virtual int Length { get; set; }

    [JsonProperty()]
    public virtual int Size { get; set; }

    [JsonProperty()]
    public virtual string? Url { get; set; }

    [JsonProperty()]
    public virtual string? VersionLabel { get; set; }

}
