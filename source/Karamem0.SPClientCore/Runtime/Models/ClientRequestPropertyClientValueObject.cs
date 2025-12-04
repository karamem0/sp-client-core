//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPropertyClientValueObject : ClientRequestProperty
{

    public static ClientRequestPropertyClientValueObject Create(string name, ClientValueObject value)
    {
        return new ClientRequestPropertyClientValueObject()
        {
            Name = name,
            TypeId = ClientObjectAttribute.GetId(value.GetType()),
            Values = value
                .GetType()
                .GetDeclaredProperties()
                .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
                .Select(propertyInfo =>
                    {
                        var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                        var propertyName = string.IsNullOrEmpty(propertyAttribute.PropertyName) ? propertyInfo.Name : propertyAttribute.PropertyName;
                        var propertyValue = propertyInfo.GetValue(value);
                        if (ClientRequestValue.TryCreate(propertyValue, out var valueObject))
                        {
                            return ClientRequestPropertyValue.Create(propertyName, valueObject);
                        }
                        else
                        {
                            throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
                        }
                    }
                )
                .ToArray()
        };
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual Guid TypeId { get; protected set; }

    [XmlElement("Property")]
    public virtual IReadOnlyCollection<ClientRequestPropertyValue>? Values { get; protected set; }

}
