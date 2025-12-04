//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public abstract class ObjectPath : ClientRequestObject
{

    [XmlAttribute()]
    public abstract long Id { get; protected set; }

}
