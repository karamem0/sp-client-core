//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "SP.Taxonomy.TaxonomyItem", Id = "{5f6011b8-fae0-4784-8882-85765261d951}")]
    [JsonObject()]
    public class TaxonomyItem : ClientObject
    {

        public TaxonomyItem()
        {
        }

        [JsonProperty()]
        public virtual DateTime CreatedDate { get; protected set; }

        [JsonProperty()]
        public virtual Guid Id { get; protected set; }

        [JsonProperty()]
        public virtual DateTime LastModifiedDate { get; protected set; }

        [JsonProperty()]
        public virtual string Name { get; protected set; }

    }

}