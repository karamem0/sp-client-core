//
// Copyright (c) 2018-2024 karamem0
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

public class ObjectPathCollection : IEnumerable<ObjectPath>
{

    private readonly IDictionary<long, ObjectPath> collection;

    public ObjectPathCollection()
    {
        this.collection = new Dictionary<long, ObjectPath>();
    }

    public ObjectPath this[long id] => this.collection[id];

    public void Add(ObjectPath item)
    {
        _ = item ?? throw new ArgumentNullException(nameof(item));
        this.collection.Add(item.Id, item);
    }

    public void Remove(long id)
    {
        _ = this.collection.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<ObjectPath> GetEnumerator()
    {
        return this.collection.Values.GetEnumerator();
    }

}
