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
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyArray(string name, params object[] values) : ClientRequestProperty
{

    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name;

    [XmlAttribute()]
    public virtual string Type { get; protected set; } = "Array";

    [XmlElement("Object")]
    public virtual IEnumerable<ClientRequestPropertyArrayValue> Values { get; protected set; } = values
            .Select(ClientRequestValue.Create)
            .Select(value => new ClientRequestPropertyArrayValue(value.Type, value.Value));

}
