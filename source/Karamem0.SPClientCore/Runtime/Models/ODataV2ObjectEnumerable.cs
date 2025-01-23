//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
[method: JsonConstructor()]
public class ODataV2ObjectEnumerable<T>(T[] results = null) : ODataV2Object, IEnumerable<T> where T : ODataV2Object
{

    [JsonProperty("value")]
    public IReadOnlyCollection<T> Entries { get; private set; } = results;

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.Entries is null)
        {
            return Enumerable.Empty<T>().GetEnumerator();
        }
        else
        {
            return this.Entries.GetEnumerator();
        }
    }

}
