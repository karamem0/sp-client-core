//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Method", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ObjectPathMethod : ObjectPath
{

    public static ObjectPathMethod Create(
        long parentId,
        string name,
        params ClientRequestParameter[] parameters
    )
    {
        return new ObjectPathMethod()
        {
            ParentId = parentId,
            Name = name,
            Parameters = parameters
        };
    }

    public static ObjectPathMethod Create(
        long parentId,
        string name,
        IEnumerable<ClientRequestParameter> parameters
    )
    {
        return Create(
            parentId,
            name,
            [.. parameters]
        );
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ParentId { get; protected set; }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlArray()]
    public virtual IReadOnlyCollection<ClientRequestParameter>? Parameters { get; protected set; }

}
