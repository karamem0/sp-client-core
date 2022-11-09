//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1
{

    [ClientObject(Name = "SP.FieldUrlValue", Id = "{fa8b44af-7b43-43f2-904a-bd319497011e}")]
    [JsonObject()]
    public class ColumnUrlValue : ClientValueObject
    {

        public ColumnUrlValue()
        {
        }

        public ColumnUrlValue(string url, string description)
        {
            this.Url = url;
            this.Description = description;
        }

        [JsonProperty()]
        public virtual string Description { get; protected set; }

        [JsonProperty()]
        public virtual string Url { get; protected set; }

    }

}
