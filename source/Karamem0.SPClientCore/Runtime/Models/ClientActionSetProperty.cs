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
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("SetProperty", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientActionSetProperty : ClientAction
{

    public static ClientActionSetProperty Create(
        long objectPathId,
        string? name,
        ClientRequestParameter? parameter
    )
    {
        return new ClientActionSetProperty()
        {
            ObjectPathId = objectPathId,
            Name = name,
            Parameter = parameter
        };
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlElement()]
    public virtual ClientRequestParameter? Parameter { get; protected set; }

}
