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

[XmlType("Method", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientActionMethod(
    long objectPathId,
    string name,
    params ClientRequestParameter[] parameters
) : ClientAction
{

    public ClientActionMethod(
        long objectPathId,
        string name,
        IEnumerable<ClientRequestParameter> parameters
    )
        : this(
            objectPathId,
            name,
            [.. parameters]
        )
    {
    }

    [XmlAttribute()]
    public override long Id { get; protected set; } = NewId();

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; } = objectPathId;

    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name ?? throw new ArgumentNullException(nameof(name));

    [XmlArray()]
    public virtual IReadOnlyCollection<ClientRequestParameter> Parameters { get; protected set; } = parameters;

}
