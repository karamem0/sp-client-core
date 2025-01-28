//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Parameter", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestParameterClientObject(ClientRequestPayload payload, object value) : ClientRequestParameter
{

    [XmlAttribute()]
    public virtual Guid TypeId { get; protected set; } = ClientObjectAttribute.GetId(value.GetType());

    [XmlElement("Property")]
    public virtual IReadOnlyCollection<ClientRequestProperty> Properties { get; protected set; } = value.GetType()
        .GetDeclaredProperties()
        .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
        .Select(propertyInfo => ClientRequestProperty.Create(propertyInfo, payload, value))
        .ToArray();

}
