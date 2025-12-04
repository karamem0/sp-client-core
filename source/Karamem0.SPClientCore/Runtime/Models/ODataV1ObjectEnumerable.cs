//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System.Collections;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV1ObjectEnumerable<T> : ODataV1Object<ODataV1ObjectEnumerable<T>>, IEnumerable<T> where T : ODataV1Object
{

    [JsonProperty("results")]
    public IReadOnlyCollection<T> Entries { get; protected set; } = [];

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Entries.GetEnumerator();
    }

}
