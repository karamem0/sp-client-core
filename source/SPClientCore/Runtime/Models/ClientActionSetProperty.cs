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

    [XmlType("SetProperty", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
    public class ClientActionSetProperty : ClientAction
    {

        public ClientActionSetProperty(long objectPathId, string name, ClientRequestParameter parameter)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            this.ObjectPathId = objectPathId;
            this.Name = name;
            this.Parameter = parameter;
        }

        [XmlAttribute()]
        public override long Id { get; protected set; }

        [XmlAttribute()]
        public virtual long ObjectPathId { get; protected set; }

        [XmlAttribute()]
        public virtual string Name { get; protected set; }

        [XmlElement()]
        public virtual ClientRequestParameter Parameter { get; protected set; }

    }

}
