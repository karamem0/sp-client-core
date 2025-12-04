//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class JsonEnumerableConverter : JsonConverter
{

    public override bool CanRead => true;

    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType)
    {
        if (objectType.IsGenericSubclassOf(typeof(IReadOnlyCollection<>)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override object? ReadJson(
        JsonReader reader,
        Type objectType,
        object? existingValue,
        JsonSerializer serializer
    )
    {
        if (objectType
            .GetGenericArguments()[0]
            .IsSubclassOf(typeof(ClientObject)))
        {
            var jsonArray = serializer.Deserialize<JArray>(reader);
            if (jsonArray is not null)
            {
                var result1 = jsonArray
                    .Select(jsonToken =>
                        {
                            var valueName = jsonToken.Value<string>("_ObjectType_");
                            _ = valueName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                            var valueType = ClientObject.GetType(valueName);
                            return jsonToken.ToObject(valueType, serializer);
                        }
                    )
                    .ToArray();
                var result2 = typeof(Enumerable)
                    .GetMethod("OfType", BindingFlags.Public | BindingFlags.Static)
                    .MakeGenericMethod(objectType.GetGenericArguments())
                    .Invoke(null, [result1]);
                var result3 = typeof(Enumerable)
                    .GetMethod("ToArray", BindingFlags.Public | BindingFlags.Static)
                    .MakeGenericMethod(objectType.GetGenericArguments())
                    .Invoke(null, [result2]);
                return result3;
            }
        }
        else
        {
            return serializer.Deserialize(reader, objectType);
        }
        return null;
    }

    public override void WriteJson(
        JsonWriter writer,
        object? value,
        JsonSerializer serializer
    )
    {
        throw new NotImplementedException();
    }

}
