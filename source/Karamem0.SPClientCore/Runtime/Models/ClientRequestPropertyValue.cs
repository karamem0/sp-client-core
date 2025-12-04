//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyValue : ClientRequestProperty
{

    public static ClientRequestPropertyValue Create(string? name, ClientRequestValue value)
    {
        return new ClientRequestPropertyValue()
        {
            Name = name,
            Type = value.Type,
            Value = value.Value
        };
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual string? Type { get; protected set; }

    [XmlText()]
    public virtual string? Value { get; protected set; }

}
