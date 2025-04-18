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

[XmlType("StaticMethod", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ObjectPathStaticMethod(
    Type type,
    string name,
    params ClientRequestParameter[] parameters
) : ObjectPath
{

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual Guid TypeId { get; protected set; } = ClientObjectAttribute.GetId(type ?? throw new ArgumentNullException(nameof(type)));

    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name ?? throw new ArgumentNullException(nameof(name));

    [XmlArray()]
    public virtual IReadOnlyCollection<ClientRequestParameter> Parameters { get; protected set; } = parameters;

}
