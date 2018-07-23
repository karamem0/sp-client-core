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
            this.ExtensionProperties = new Dictionary<string, JToken>();
        }

        [JsonIgnore()]
        public dynamic this[string key]
        {
            get => (dynamic)this.ExtensionProperties[key];
        }

        [JsonIgnore()]
        public IEnumerable<string> ExtensionKeys
        {
            get => this.ExtensionProperties.Keys;
        }

        [JsonProperty("__deferred")]
        public ODataDeferred Deferred { get; private set; }

        [JsonProperty("__metadata")]
        public ODataMetadata Metadata { get; private set; }

        [JsonExtensionData()]
        protected Dictionary<string, JToken> ExtensionProperties { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
