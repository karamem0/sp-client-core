//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public abstract class ClientAction : ClientRequestObject
    {

        protected ClientAction()
        {
            this.Id = ClientRequestObject.NewId();
        }

        [XmlAttribute()]
        public virtual long Id { get; protected set; }

    }

}
