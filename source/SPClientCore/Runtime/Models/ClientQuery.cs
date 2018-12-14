//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [XmlType("Query", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
    public class ClientQuery : ClientRequestObject
    {

        public static readonly ClientQuery Empty = new ClientQuery(false);

        public ClientQuery(bool selectAllProperties)
        {
            this.SelectAllProperties = selectAllProperties;
            this.Properties = new List<ClientQueryProperty>();
        }

        public ClientQuery(bool selectAllProperties, Type type)
        {
            this.SelectAllProperties = selectAllProperties;
            this.Properties = type.GetDeclaringProperties()
                .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
                .Select(propertyInfo =>
                {
                    var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                    return string.IsNullOrEmpty(propertyAttribute.PropertyName)
                        ? new ClientQueryProperty(propertyInfo.Name)
                        : new ClientQueryProperty(propertyAttribute.PropertyName);
                })
                .ToList();
        }

        [XmlAttribute()]
        public virtual bool SelectAllProperties { get; protected set; }

        [XmlArray()]
        public virtual IEnumerable<ClientQueryProperty> Properties { get; protected set; }

    }

}
