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
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyObjectPath(string name, ObjectPath objectPath) : ClientRequestProperty
{

    [XmlAttribute()]
    public virtual string Name { get; protected set; } = name;

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; } = objectPath.Id;

}
