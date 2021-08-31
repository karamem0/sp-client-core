//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [XmlType("Property", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
    public class ClientRequestPropertyDictionary : ClientRequestProperty
    {

        public ClientRequestPropertyDictionary(string name, IDictionary values)
        {
            this.Name = name;
            this.Type = "Dictionary";
            this.Values = values.Keys
                .OfType<object>()
                .ToDictionary(key => key.ToString(), key => values[key])
                .Select(value => new ClientRequestPropertyValue(value.Key, ClientRequestValue.Create(value.Value)))
                .ToArray();
        }

        [XmlAttribute()]
        public virtual string Name { get; protected set; }

        [XmlAttribute()]
        public virtual string Type { get; protected set; }

        [XmlElement("Property")]
        public virtual IEnumerable<ClientRequestPropertyValue> Values { get; protected set; }

    }

}
