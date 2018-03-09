//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.OData
{

    [JsonObject()]
    public class ODataMetadata : ODataObject
    {

        public static ODataMetadata Create(Type type)
        {
            var typeAttribute = type.GetCustomAttribute<JsonObjectAttribute>(false);
            if (typeAttribute != null)
            {
                return new ODataMetadata(null, null, typeAttribute.Id);
            }
            else
            {
                if (type.IsGenericSubclassOf(typeof(ClientObjectCollection<>)))
                {
                    var argumentType = type.GetGenericArguments()[0];
                    var argumentAttribute = argumentType.GetCustomAttribute<JsonObjectAttribute>(false);
                    if (argumentAttribute != null)
                    {
                        return new ODataMetadata(null, null, $"Collection({argumentAttribute.Id})");
                    }
                }
                if (type.IsGenericSubclassOf(typeof(ClientValueObjectCollection<>)))
                {
                    var argumentType = type.GetGenericArguments()[0];
                    if (argumentType.IsGenericSubclassOf(typeof(Nullable<>)))
                    {
                        argumentType = argumentType.GetGenericArguments()[0];
                    }
                    return new ODataMetadata(null, null, $"Collection(Edm.{argumentType.Name})");
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
