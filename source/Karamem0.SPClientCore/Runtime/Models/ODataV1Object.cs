//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV1Object : ODataObject
{

    [JsonProperty("__deferred")]
    public virtual ODataV1Deferred? Deferred { get; protected set; }

}

[JsonObject()]
public class ODataV1Object<T> : ODataV1Object
{

    [JsonProperty("__metadata")]
    public virtual ODataV1Metadata? Metadata { get; protected set; } = ODataV1Metadata.Create(typeof(T));

}
