//
// Copyright (c) 2018-2024 karamem0
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

public abstract class ClientObjectEnumerable<T> : ClientObject, IEnumerable<T>
{

    protected ClientObjectEnumerable()
    {
    }

    [JsonProperty("_Child_Items_")]
    [JsonConverter(typeof(JsonEnumerableConverter))]
    public IReadOnlyList<T> Entries { get; private set; }

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
