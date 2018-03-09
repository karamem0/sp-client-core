//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject()]
    public abstract class ClientValueObject
    {

        protected ClientValueObject()
        {
            this.Metadata = ODataMetadata.Create(this.GetType());
        }

        [JsonProperty("__metadata")]
        public virtual ODataMetadata Metadata { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
