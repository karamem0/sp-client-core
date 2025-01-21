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

[ClientObject(Name = "SP.FileCreationInformation", Id = "{f5c8173c-cae6-4469-a7af-3879ca3c617c}")]
[JsonObject()]
public class FileCreationInfo : ClientValueObject
{

    public FileCreationInfo()
    {
    }

    public FileCreationInfo(IReadOnlyDictionary<string, object> parameters) : base(parameters)
    {
    }

    [JsonProperty()]
    public virtual byte[] Content { get; protected set; }

    [JsonProperty()]
    public virtual bool Overwrite { get; protected set; }

    [JsonProperty("Url")]
    public virtual string FileName { get; protected set; }

}
