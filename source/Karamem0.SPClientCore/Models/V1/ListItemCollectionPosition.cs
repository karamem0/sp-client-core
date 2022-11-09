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

    [ClientObject(Name = "SP.ListItemCollectionPosition", Id = "{922354eb-c56a-4d88-ad59-67496854efe1}")]
    [JsonObject()]
    public class ListItemCollectionPosition : ClientValueObject
    {

        public ListItemCollectionPosition()
        {
        }

        [JsonProperty()]
        public virtual string PagingInfo { get; protected set; }

    }

}
