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

[ClientObject(Name = "SP.AttachmentCreationInformation", Id = "{edf6309c-8142-4133-921e-4d6aec35550d}")]
[JsonObject()]
public class AttachmentFileCreationInfo : ClientValueObject
{

    [JsonProperty()]
    public virtual System.IO.Stream? ContentStream { get; protected set; }

    [JsonProperty()]
    public virtual string? FileName { get; protected set; }

}
