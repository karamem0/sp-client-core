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

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyArray : ClientRequestProperty
{

    public static ClientRequestPropertyArray Create(string name, params object[] values)
    {
        return new ClientRequestPropertyArray()
        {
            Name = name,
            Values = values
                .Select(ClientRequestValue.Create)
                .Select(value => ClientRequestPropertyArrayValue.Create(value.Type, value.Value))
                .ToArray()
        };
    }

    public static ClientRequestPropertyArray Create(string name, IEnumerable<object> values)
    {
        return Create(name, [.. values]);
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual string? Type { get; protected set; } = "Array";

    [XmlElement("Object")]
    public virtual IReadOnlyCollection<ClientRequestPropertyArrayValue>? Values { get; protected set; }

}
