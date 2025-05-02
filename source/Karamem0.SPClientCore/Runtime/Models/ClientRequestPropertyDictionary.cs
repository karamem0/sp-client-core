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
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyDictionary : ClientRequestProperty
{

    public static ClientRequestPropertyDictionary Create(string name, IDictionary values)
    {
        return new ClientRequestPropertyDictionary()
        {
            Name = name,
            Values = values
                .Keys.OfType<object>()
                .ToDictionary(key => key.ToString(), key => values[key])
                .Select(value => ClientRequestPropertyValue.Create(value.Key, ClientRequestValue.Create(value.Value)))
                .ToArray()
        };
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual string? Type { get; protected set; } = "Dictionary";

    [XmlElement("Property")]
    public virtual IReadOnlyCollection<ClientRequestPropertyValue>? Values { get; protected set; }

}
