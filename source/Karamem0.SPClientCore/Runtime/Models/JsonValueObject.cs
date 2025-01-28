//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public abstract class JsonValueObject : ValueObject
{

    [JsonIgnore()]
    public virtual object this[string key] => this.ExtensionProperties[key];

    [JsonIgnore()]
    public virtual IEnumerable<string> ExtensionKeys => this.ExtensionProperties.Where(item => item.Value is not null)
        .Select(ClientResultValue.Create)
        .Select(item => item.Key)
        .ToArray();

    [JsonExtensionData()]
    protected virtual Dictionary<string, JToken> ExtensionProperties { get; private set; } = [];

    [JsonIgnore()]
    protected override Lazy<IReadOnlyCollection<PropertyInfo>> EqualityProperties => new(
        () => this.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(property => property.IsDefined(typeof(JsonPropertyAttribute), true))
            .ToArray()
    );

}
