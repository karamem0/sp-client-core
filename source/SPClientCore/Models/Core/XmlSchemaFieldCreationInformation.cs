//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.XmlSchemaFieldCreationInformation")]
    public class XmlSchemaFieldCreationInformation : ClientObject
    {

        public XmlSchemaFieldCreationInformation()
        {
        }

        [JsonProperty()]
        public AddFieldOptions? Options { get; private set; }

        [JsonProperty()]
        public string SchemaXml { get; private set; }

    }

}
