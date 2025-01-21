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

[XmlType("Parameter", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestParameterValue(ClientRequestValue value) : ClientRequestParameter
{

    public ClientRequestParameterValue() : this(ClientRequestValue.Create(null))
    {
    }

    public ClientRequestParameterValue(object value) : this(ClientRequestValue.Create(value))
    {
    }

    [XmlAttribute()]
    public virtual string Type { get; protected set; } = value.Type;

    [XmlText()]
    public virtual string Value { get; protected set; } = value.Value;

}
