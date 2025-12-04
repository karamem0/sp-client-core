//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Query", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientActionQuery : ClientAction
{

    public static ClientActionQuery Create(
        long objectPathId,
        ClientQuery? query = null,
        ClientQuery? childItemQuery = null
    )
    {
        return new ClientActionQuery()
        {
            ObjectPathId = objectPathId,
            Query = query,
            ChildItemQuery = childItemQuery
        };
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; }

    [XmlElement()]
    public virtual ClientQuery? Query { get; protected set; }

    [XmlElement()]
    public virtual ClientQuery? ChildItemQuery { get; protected set; }

}
