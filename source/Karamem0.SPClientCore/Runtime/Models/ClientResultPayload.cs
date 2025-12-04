//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json.Linq;

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
            ?.ToObject<ClientResultError>();
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

    public string? SchemaVersion { get; protected set; }

    public string? LibraryVersion { get; protected set; }

    public ClientResultError? ErrorInfo { get; protected set; }

    public string? TraceCorrelationId { get; protected set; }

    public IReadOnlyDictionary<long, JToken>? ClientObjects { get; protected set; }

    public T? ToObject<T>(long id)
    {
        var jsonToken = this.ClientObjects?[id];
        _ = jsonToken ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        if (jsonToken.Type == JTokenType.Null)
        {
            return default;
        }
        if (typeof(T).IsSubclassOf(typeof(ClientObject)))
        {
            var objectName = jsonToken.Value<string>("_ObjectType_");
            _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            var objectType = ClientObject.GetType<T>(objectName);
            return (T?)jsonToken.ToObject(objectType, JsonSerializerManager.Instance);
        }
        else
        {
            return jsonToken.ToObject<T>(JsonSerializerManager.Instance);
        }
    }

    public IEnumerable<T?> ToObjectEnumerable<T>(IEnumerable<long> ids)
    {
        foreach (var id in ids)
        {
            var jsonToken = this.ClientObjects?[id];
            _ = jsonToken ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (jsonToken.Type == JTokenType.Null)
            {
                yield return default;
            }
            if (typeof(T).IsSubclassOf(typeof(ClientObject)))
            {
                var objectName = jsonToken.Value<string>("_ObjectType_");
                _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                var objectType = ClientObject.GetType<T>(objectName);
                yield return (T?)jsonToken.ToObject(objectType, JsonSerializerManager.Instance);
            }
            else
            {
                yield return jsonToken.ToObject<T>(JsonSerializerManager.Instance);
            }
        }
    }

    public bool IsNull(long id)
    {
        var jsonToken = this.ClientObjects?[id];
        _ = jsonToken ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
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
