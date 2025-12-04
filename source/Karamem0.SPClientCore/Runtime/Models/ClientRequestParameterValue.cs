//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Parameter", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestParameterValue() : ClientRequestParameter
{

    public static ClientRequestParameterValue Create(ClientRequestValue value)
    {
        return new ClientRequestParameterValue()
        {
            Type = value.Type,
            Value = value.Value
        };
    }

    public static ClientRequestParameterValue Create(object value)
    {
        return Create(ClientRequestValue.Create(value));
    }

    [XmlAttribute()]
    public virtual string? Type { get; protected set; }

    [XmlText()]
    public virtual string? Value { get; protected set; }

}
