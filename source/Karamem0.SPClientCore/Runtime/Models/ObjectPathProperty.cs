//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ObjectPathProperty : ObjectPath
{

    public ObjectPathProperty(long parentId, string name)
    {
        this.ParentId = parentId;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    [XmlAttribute()]
    public override long Id { get; protected set; }

    [XmlAttribute()]
    public virtual long ParentId { get; private set; }

    [XmlAttribute()]
    public virtual string Name { get; private set; }

}
