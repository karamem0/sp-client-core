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

[XmlType("Object", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyArrayValue : ClientRequestObject
{

    public static ClientRequestPropertyArrayValue Create(string? type, string? value)
    {
        return new ClientRequestPropertyArrayValue()
        {
            Type = type,
            Value = value
        };
    }

    [XmlAttribute()]
    public virtual string? Type { get; protected set; }

    [XmlText()]
    public virtual string? Value { get; protected set; }

}
