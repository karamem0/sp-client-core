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

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientQueryProperty(string name) : ClientRequestObject
{
    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name ?? throw new ArgumentNullException(nameof(name));

    [XmlAttribute()]
    public virtual bool? ScalarProperty { get; set; }

    [XmlAttribute()]
    public virtual bool? SelectAll { get; set; }

    [XmlElement()]
    public virtual ClientQuery Query { get; set; }

}
