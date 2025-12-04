//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("ObjectPath", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientActionInstantiateObjectPath : ClientAction
{

    public static ClientActionInstantiateObjectPath Create(long objectPathId)
    {
        return new ClientActionInstantiateObjectPath()
        {
            ObjectPathId = objectPathId
        };
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; }

}
