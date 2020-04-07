//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataMetadata
    {

        public static ODataMetadata Create(Type type)
        {
            var attribute = type.GetCustomAttribute<ODataObjectAttribute>(false);
            if (attribute != null)
            {
                if (attribute.Name != null)
                {
                    return new ODataMetadata(null, null, attribute.Name);
                }
            }
            return null;
        }

        public ODataMetadata()
        {
        }

        public ODataMetadata(string id, Uri uri, string type)
        {
            this.Id = id;
            this.Uri = uri;
            this.Type = type;
        }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("uri")]
        public Uri Uri { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

    }

}
