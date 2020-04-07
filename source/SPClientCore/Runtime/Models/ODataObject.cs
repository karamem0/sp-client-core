//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataObject
    {

        protected ODataObject()
        {
            this.Metadata = ODataMetadata.Create(this.GetType());
            this.ExtensionProperties = new Dictionary<string, JToken>();
        }

        [JsonIgnore()]
        public object this[string key] => this.ExtensionProperties[key];

        [JsonIgnore()]
        public IEnumerable<string> ExtensionKeys => this.ExtensionProperties.Select(item => item.Key);

        [JsonProperty("__deferred")]
        internal ODataDeferred Deferred { get; private set; }

        [JsonProperty("__metadata")]
        internal ODataMetadata Metadata { get; private set; }

        [JsonExtensionData()]
        protected Dictionary<string, JToken> ExtensionProperties { get; private set; }

    }

}
