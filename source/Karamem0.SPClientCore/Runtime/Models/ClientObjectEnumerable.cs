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

public abstract class ClientObjectEnumerable<T> : ClientObject, IEnumerable<T>
{

    [JsonProperty("_Child_Items_")]
    [JsonConverter(typeof(JsonEnumerableConverter))]
    public IEnumerable<T> Entries { get; protected set; } = [];

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Entries.GetEnumerator();
    }

}
