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
public class ClientRequestParameterObjectPath : ClientRequestParameter
{

    public static ClientRequestParameterObjectPath Create(ObjectPath objectPath)
    {
        return new ClientRequestParameterObjectPath()
        {
            ObjectPathId = objectPath.Id
        };
    }

    [XmlAttribute()]
    public virtual long ObjectPathId { get; protected set; }

}
