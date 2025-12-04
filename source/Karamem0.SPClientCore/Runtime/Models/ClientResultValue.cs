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

public class ClientResultValue
{

    public static ClientResultValue Create(KeyValuePair<string, JToken> input)
    {
        if (TryCreate(input, out var output))
        {
            return output;
        }
        throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, input.ToString()), nameof(input));
    }

    public static bool TryCreate(KeyValuePair<string, JToken> input, out ClientResultValue output)
    {
        output = new ClientResultValue();
        var charIndex = input.Key.IndexOf('$');
        if (charIndex >= 0)
        {
            output.Key = input.Key[..charIndex];
        }
        else
        {
            output.Key = input.Key;
        }
        switch (input.Value.Type)
        {
            case JTokenType.Null:
                output.Value = null;
                return true;
            case JTokenType.Boolean:
                output.Value = input.Value.ToObject<bool>();
                return true;
            case JTokenType.Integer:
            case JTokenType.Float:
                switch (input
                            .Key.Split('$')
                            .Last()
                            .Trim())
                {
                    case "Byte":
                        output.Value = input.Value.ToObject<byte>();
                        return true;
                    case "Char":
                        output.Value = input.Value.ToObject<char>();
                        return true;
                    case "Int16":
                        output.Value = input.Value.ToObject<short>();
                        return true;
                    case "UInt16":
                        output.Value = input.Value.ToObject<ushort>();
                        return true;
                    case "Int32":
                        output.Value = input.Value.ToObject<int>();
                        return true;
                    case "UInt32":
                        output.Value = input.Value.ToObject<uint>();
                        return true;
                    case "Int64":
                        output.Value = input.Value.ToObject<long>();
                        return true;
                    case "UInt64":
                        output.Value = input.Value.ToObject<ulong>();
                        return true;
                    case "Single":
                        output.Value = input.Value.ToObject<float>();
                        return true;
                    case "Double":
                        output.Value = input.Value.ToObject<double>();
                        return true;
                    case "Decimal":
                        output.Value = input.Value.ToObject<decimal>();
                        return true;
                    default:
                        output.Value = input.Value.ToObject<int>();
                        return true;
                }
            case JTokenType.Date:
                output.Value = input.Value.ToObject<DateTime>();
                return true;
            case JTokenType.Guid:
                output.Value = input.Value.ToObject<Guid>();
                return true;
            case JTokenType.Object:
                var objectNameJson = input.Value["_ObjectType_"];
                if (objectNameJson is null)
                {
                    output.Value = input.Value.ToObject<Dictionary<string, object>>();
                }
                else
                {
                    var objectName = objectNameJson.ToString();
                    var objectType = ClientValueObject.GetType(objectName) ?? typeof(ClientValueObject);
                    output.Value = input.Value.ToObject(objectType);
                }
                return true;
            case JTokenType.Array:
                output.Value = input
                    .Value.Select(item => new KeyValuePair<string, JToken>(
                            input
                                .Key.Split('$')
                                .First(),
                            item
                        )
                    )
                    .Select(Create)
                    .Select(item => item.Value)
                    .ToArray();
                return true;
            case JTokenType.String:
                if (DateTimeConverter.TryParse(input.Value.ToString(), out var dateValue))
                {
                    output.Value = dateValue;
                    return true;
                }
                if (GuidConverter.TryParse(input.Value.ToString(), out var guidValue))
                {
                    output.Value = guidValue;
                    return true;
                }
                output.Value = input.Value.ToString();
                return true;
            default:
                output = new ClientResultValue();
                return false;
        }
    }

    public string? Key { get; protected set; }

    public object? Value { get; protected set; }

}
