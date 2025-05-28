//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class ClientActionCollection : IEnumerable<ClientAction>
{

    private readonly Dictionary<long, ClientAction> collection = [];

    public ClientAction this[long id] => this.collection[id];

    public void Add(ClientAction item)
    {
        this.collection.Add(item.Id, item);
    }

    public void AddRange(IEnumerable<ClientAction> items)
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }

    public void Remove(long id)
    {
        _ = this.collection.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<ClientAction> GetEnumerator()
    {
        return this.collection.Values.GetEnumerator();
    }

}
