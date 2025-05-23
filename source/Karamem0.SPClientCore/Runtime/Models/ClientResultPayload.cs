//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class ClientResultPayload
{

    public ClientResultPayload(string jsonString)
    {
        var jsonArray = JsonSerializerManager.Instance.Deserialize<JArray>(JsonHelper.ReplaceDoubleToInfinity(jsonString));
        var jsonToken = jsonArray.ElementAt(0);
        this.SchemaVersion = jsonToken.Value<string>(nameof(this.SchemaVersion));
        this.LibraryVersion = jsonToken.Value<string>(nameof(this.LibraryVersion));
        this.ErrorInfo = jsonToken[nameof(this.ErrorInfo)]
            .ToObject<ClientResultError>();
        this.TraceCorrelationId = jsonToken.Value<string>(nameof(this.TraceCorrelationId));
        this.ClientObjects = jsonArray
            .Skip(1)
            .Chunks(2)
            .ToDictionary(
                chunk => chunk
                    .ElementAt(0)
                    .Value<long>(),
                chunk => chunk.ElementAt(1)
            );
    }

    public string SchemaVersion { get; private set; }

    public string LibraryVersion { get; private set; }

    public ClientResultError ErrorInfo { get; private set; }

    public string TraceCorrelationId { get; private set; }

    public IReadOnlyDictionary<long, JToken> ClientObjects { get; private set; }

    public T ToObject<T>(long id)
    {
        var jsonToken = this.ClientObjects[id];
        if (jsonToken.Type == JTokenType.Null)
        {
            return default;
        }
        if (typeof(T).IsSubclassOf(typeof(ClientObject)))
        {
            var objectName = jsonToken["_ObjectType_"]
                .ToString();
            var objectType = ClientObject.GetType<T>(objectName);
            return (T)jsonToken.ToObject(objectType, JsonSerializerManager.Instance);
        }
        else
        {
            return jsonToken.ToObject<T>(JsonSerializerManager.Instance);
        }
    }

    public IEnumerable<T> ToObjectEnumerable<T>(IEnumerable<long> ids)
    {
        foreach (var id in ids)
        {
            var jsonToken = this.ClientObjects[id];
            if (jsonToken.Type == JTokenType.Null)
            {
                yield return default;
            }
            if (typeof(T).IsSubclassOf(typeof(ClientObject)))
            {
                var objectName = jsonToken["_ObjectType_"]
                    .ToString();
                var objectType = ClientObject.GetType<T>(objectName);
                yield return (T)jsonToken.ToObject(objectType, JsonSerializerManager.Instance);
            }
            else
            {
                yield return jsonToken.ToObject<T>(JsonSerializerManager.Instance);
            }
        }
    }

    public bool IsNull(long id)
    {
        var jsonToken = this.ClientObjects[id];
        if (jsonToken.Type == JTokenType.Null)
        {
            return true;
        }
        if (jsonToken.Value<bool>("IsNull"))
        {
            return true;
        }
        return false;
    }

}
