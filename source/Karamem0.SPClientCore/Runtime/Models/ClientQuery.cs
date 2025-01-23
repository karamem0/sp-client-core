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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Query", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientQuery(
    bool selectAllProperties,
    Type type = null,
    params string[] conditions
) : ClientRequestObject
{

    public static readonly ClientQuery Empty = new(false);

    public ClientQuery(
        bool selectAllProperties,
        Type type,
        IEnumerable<string> conditions
    )
        : this(
            selectAllProperties,
            type,
            [.. conditions]
        )
    {
    }

    [XmlAttribute()]
    public virtual bool SelectAllProperties { get; protected set; } = selectAllProperties;

    [XmlArray()]
    public virtual IReadOnlyCollection<ClientQueryProperty> Properties { get; protected set; } = type is null
        ? []
        : type.GetDeclaredProperties()
            .Where(propertyInfo => propertyInfo.IsDefined(typeof(JsonPropertyAttribute)))
            .Where(propertyInfo => ClientQueryIgnoreAttribute.IsMatch(propertyInfo, conditions))
            .Select(propertyInfo => ClientQueryProperty.Create(propertyInfo, selectAllProperties))
            .ToArray();

}
