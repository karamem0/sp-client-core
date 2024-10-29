//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Query", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientQuery : ClientRequestObject
{

    public static readonly ClientQuery Empty = new(false);

    public ClientQuery(bool selectAllProperties)
    {
        this.SelectAllProperties = selectAllProperties;
        this.Properties = [];
    }

    public ClientQuery(bool selectAllProperties, Type type, params string[] conditions)
    {
        this.SelectAllProperties = selectAllProperties;
        this.Properties = type.GetDeclaredProperties()
            .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
            .Where(propertyInfo =>
            {
                var conditionAttribute = propertyInfo.GetCustomAttribute<ClientQueryIgnoreAttribute>();
                if (conditionAttribute is null)
                {
                    return true;
                }
                else
                {
                    if (conditionAttribute.Name is null)
                    {
                        return false;
                    }
                    else
                    {
                        return conditions.Contains(conditionAttribute.Name);
                    }
                }
            })
            .Select(propertyInfo =>
            {
                var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                var propertyName = string.IsNullOrEmpty(propertyAttribute.PropertyName) ? propertyInfo.Name : propertyAttribute.PropertyName;
                var propertyType = propertyInfo.PropertyType;
                if (propertyType.IsSubclassOf(typeof(ClientObject)))
                {
                    return new ClientQueryProperty(propertyName)
                    {
                        SelectAll = true,
                        Query = new ClientQuery(selectAllProperties, propertyType)
                    };
                }
                else
                {
                    return new ClientQueryProperty(propertyName)
                    {
                        ScalarProperty = true
                    };
                }
            })
            .ToList();
    }

    [XmlAttribute()]
    public virtual bool SelectAllProperties { get; protected set; }

    [XmlArray()]
    public virtual IEnumerable<ClientQueryProperty> Properties { get; protected set; }

}
