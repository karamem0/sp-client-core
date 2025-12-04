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

[ClientObject(Name = "SP.MoveCopyOptions", Id = "{b3ff81b8-6cec-4ad3-ae27-9d5cff515d8e}")]
[JsonObject()]
public class MoveCopyOptions : ClientValueObject
{

    [JsonProperty()]
    public virtual bool KeepBoth { get; protected set; }

    [JsonProperty()]
    public virtual bool ResetAuthorAndCreatedOnCopy { get; protected set; }

    [JsonProperty()]
    public virtual bool RetainEditorAndModifiedOnMove { get; protected set; }

    [JsonProperty()]
    public virtual bool ShouldBypassSharedLocks { get; protected set; }

}
