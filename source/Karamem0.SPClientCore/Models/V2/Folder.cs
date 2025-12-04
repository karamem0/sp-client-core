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
public class Folder : ODataV2Object
{

    [JsonProperty("childCount")]
    public virtual int ChildCount { get; protected set; }

}
