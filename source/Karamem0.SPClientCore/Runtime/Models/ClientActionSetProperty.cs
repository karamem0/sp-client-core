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
public class ClientActionSetProperty(long objectPathId, string name, ClientRequestParameter parameter) : ClientAction
{

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; } = objectPathId;

    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name ?? throw new ArgumentNullException(nameof(name));

    [XmlElement()]
    public virtual ClientRequestParameter Parameter { get; protected set; } = parameter;

}
