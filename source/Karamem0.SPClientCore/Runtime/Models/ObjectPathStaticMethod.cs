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
using System.Resources;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("StaticMethod", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ObjectPathStaticMethod : ObjectPath
{

    public static ObjectPathStaticMethod Create(
        Type type,
        string name,
        params ClientRequestParameter[] parameters
    )
    {
        return new ObjectPathStaticMethod()
        {
            TypeId = ClientObjectAttribute.GetId(type),
            Name = name,
            Parameters = parameters
        };
    }

    public static ObjectPathStaticMethod Create(
        Type type,
        string name,
        IEnumerable<ClientRequestParameter> parameters
    )
    {
        return Create(
            type,
            name,
            [.. parameters]
        );
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual Guid TypeId { get; protected set; }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlArray()]
    public virtual IReadOnlyCollection<ClientRequestParameter>? Parameters { get; protected set; }

}
