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

    [ClientObject(Name = "SP.ContentTypeId", Id = "{da0f1e90-296f-480e-bc27-cefe51eff241}")]
    [JsonObject()]
    public class ContentTypeId : ClientValueObject
    {

        public ContentTypeId()
        {
        }

        public ContentTypeId(string stringValue)
        {
            this.StringValue = stringValue;
        }

        [JsonProperty()]
        public virtual string StringValue { get; protected set; }

    }

}
