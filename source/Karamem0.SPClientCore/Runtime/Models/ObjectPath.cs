//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public abstract class ObjectPath : ClientRequestObject
{

    protected ObjectPath()
    {
        this.Id = NewId();
    }

    [XmlAttribute()]
    public virtual long Id { get; protected set; }

}
