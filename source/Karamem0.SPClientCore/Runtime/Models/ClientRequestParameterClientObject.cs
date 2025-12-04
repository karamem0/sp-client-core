//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Parameter", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestParameterClientObject : ClientRequestParameter
{

    public static ClientRequestParameterClientObject Create(ClientRequestPayload payload, object value)
    {
        return new ClientRequestParameterClientObject()
        {
            TypeId = ClientObjectAttribute.GetId(value.GetType()),
            Properties = value
                .GetType()
                .GetDeclaredProperties()
                .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
                .Select(propertyInfo => ClientRequestProperty.Create(
                        propertyInfo,
                        payload,
                        value
                    )
                )
                .ToArray()
        };
    }

    [XmlAttribute()]
    public virtual Guid TypeId { get; protected set; }

    [XmlElement("Property")]
    public virtual IReadOnlyCollection<ClientRequestProperty>? Properties { get; protected set; }

}
