//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System.Reflection;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientQueryProperty : ClientRequestObject
{

    public static ClientQueryProperty Create(PropertyInfo propertyInfo, bool selectAllProperties)
    {
        var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
        var propertyName = string.IsNullOrEmpty(propertyAttribute.PropertyName) ? propertyInfo.Name : propertyAttribute.PropertyName;
        var propertyType = propertyInfo.PropertyType;
        if (propertyType.IsSubclassOf(typeof(ClientObject)))
        {
            return new ClientQueryProperty()
            {
                Name = propertyName,
                SelectAll = true,
                Query = ClientQuery.Create(selectAllProperties, propertyType)
            };
        }
        else
        {
            return new ClientQueryProperty()
            {
                Name = propertyName,
                ScalarProperty = true
            };
        }
    }

    [XmlAttribute()]
    public virtual string? Name { get; protected set; }

    [XmlAttribute()]
    public virtual bool? ScalarProperty { get; protected set; }

    [XmlAttribute()]
    public virtual bool? SelectAll { get; protected set; }

    [XmlElement()]
    public virtual ClientQuery? Query { get; protected set; }

}
