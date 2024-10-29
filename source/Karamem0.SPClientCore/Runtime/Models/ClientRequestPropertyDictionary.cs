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
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyDictionary(string name, IDictionary values) : ClientRequestProperty
{
    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name;

    [XmlAttribute()]
    public virtual string Type { get; protected set; } = "Dictionary";

    [XmlElement("Property")]
    public virtual IEnumerable<ClientRequestPropertyValue> Values { get; protected set; } = values.Keys
            .OfType<object>()
            .ToDictionary(key => key.ToString(), key => values[key])
            .Select(value => new ClientRequestPropertyValue(value.Key, ClientRequestValue.Create(value.Value)))
            .ToArray();

}
