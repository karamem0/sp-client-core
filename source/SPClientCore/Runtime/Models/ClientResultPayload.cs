//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public class ClientResultPayload
    {

        private static readonly JsonSerializerSettings JsonSerializerSettings =
            new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>()
                {
                    new JsonDateTimeConverter(),
                    new JsonGuidConverter()
                }
            };

        private static readonly JsonSerializer JsonSerializer = JsonSerializer.Create(ClientResultPayload.JsonSerializerSettings);

        public ClientResultPayload(string jsonString)
        {
            var jsonArray = JsonConvert.DeserializeObject<JArray>(
                JsonHelper.ReplaceDoubleToInfinity(jsonString),
                ClientResultPayload.JsonSerializerSettings);
            var jsonToken = jsonArray.ElementAt(0);
            this.SchemaVersion = jsonToken.Value<string>(nameof(this.SchemaVersion));
            this.LibraryVersion = jsonToken.Value<string>(nameof(this.LibraryVersion));
            this.ErrorInfo = jsonToken[nameof(this.ErrorInfo)].ToObject<ClientResultError>();
            this.TraceCorrelationId = jsonToken.Value<string>(nameof(this.TraceCorrelationId));
            this.ClientObjects = jsonArray.Skip(1).Chunks(2).ToDictionary(chunk => chunk.ElementAt(0).Value<long>(), chunk => chunk.ElementAt(1));
        }

        public string SchemaVersion { get; private set; }

        public string LibraryVersion { get; private set; }

        public ClientResultError ErrorInfo { get; private set; }

        public string TraceCorrelationId { get; private set; }

        public IReadOnlyDictionary<long, JToken> ClientObjects { get; private set; }

        public T ToObject<T>(long id)
        {
            var jsonToken = this.ClientObjects[id];
            if (typeof(T).IsSubclassOf(typeof(ClientObject)))
            {
                var objectName = jsonToken["_ObjectType_"].ToString();
                var objectType = ClientObject.GetType<T>(objectName);
                return (T)jsonToken.ToObject(objectType, ClientResultPayload.JsonSerializer);
            }
            else
            {
                return jsonToken.ToObject<T>(ClientResultPayload.JsonSerializer);
            }
        }

    }

}
