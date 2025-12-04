//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV1RequestPayload
{

    public static ODataV1RequestPayload Create<T>(IReadOnlyDictionary<string, object?> parameters) where T : ODataV1Object, new()
    {
        var value = new ODataV1RequestPayload()
        {
            Entity = new T()
        };
        foreach (var property in value
                     .Entity.GetType()
                     .GetDeclaredProperties())
        {
            if (parameters.TryGetValue(property.Name, out var propertyValue))
            {
                property.SetValue(value.Entity, propertyValue);
            }
        }
        return value;
    }

    [JsonProperty("parameters")]
    public ODataV1Object? Entity { get; protected set; }

}
