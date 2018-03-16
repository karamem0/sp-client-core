//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject()]
    public abstract class ClientObject
    {

        protected ClientObject()
        {
            this.Metadata = ODataMetadata.Create(this.GetType());
            this.ExtendedProperties = new Dictionary<string, JToken>();
        }

        [JsonProperty("__deferred")]
        public ODataDeferred Deferred { get; private set; }

        [JsonProperty("__metadata")]
        public ODataMetadata Metadata { get; private set; }

        [JsonExtensionData()]
        public Dictionary<string, JToken> ExtendedProperties { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
