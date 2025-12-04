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
public class ClientRequestParameterArray : ClientRequestParameter
{

    public static ClientRequestParameterArray Create(ClientRequestPayload payload, params object[] values)
    {
        return new ClientRequestParameterArray()
        {
            Values = values
                .Select(payload.CreateParameter)
                .ToArray()
        };
    }

    public static ClientRequestParameterArray Create(ClientRequestPayload payload, IEnumerable<object> values)
    {
        return Create(payload, [.. values]);
    }

    [XmlAttribute()]
    public virtual string Type { get; protected set; } = "Array";

    [XmlElement("Object")]
    public virtual IReadOnlyCollection<ClientRequestParameter>? Values { get; protected set; }

}
