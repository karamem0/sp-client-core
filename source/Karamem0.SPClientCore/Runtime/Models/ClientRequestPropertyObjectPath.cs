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
public class ClientRequestPropertyObjectPath : ClientRequestProperty
{

    public static ClientRequestPropertyObjectPath Create(string? name, ObjectPath objectPath)
    {
        return new ClientRequestPropertyObjectPath()
        {
            Name = name,
            ObjectPathId = objectPath.Id
        };
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; }

}
