//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ClientObject : JsonValueObject
{

    private static readonly IReadOnlyDictionary<string, Type> dictionary =
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ClientObject)))
            .Where(type => type.IsDefined(typeof(ClientObjectAttribute)))
            .Select(type => new
            {
                Type = type,
                Attribute = type.GetCustomAttribute<ClientObjectAttribute>()
            })
            .Where(value => value.Attribute.Name is not null)
            .ToDictionary(value => value.Attribute.Name, value => value.Type);

    public static Type GetType(string name)
    {
        return dictionary
            .Where(item => item.Key == name)
            .Select(item => item.Value)
            .SingleOrDefault();
    }

    public static Type GetType<T>(string name)
    {
        var type = GetType(name);
        if (type is null)
        {
            if (typeof(T).IsGenericSubclassOf(typeof(ClientObjectEnumerable<>)))
            {
                return typeof(T);
            }
            else
            {
                return typeof(ClientObject);
            }
        }
        else
        {
            return type;
        }
    }

    public ClientObject()
    {
    }

    [JsonIgnore()]
    public override object this[string key] =>
        this.ExtensionProperties
            .Where(item => item.Key == key)
            .Select(ClientResultValue.Create)
            .Select(item => item.Value)
            .SingleOrDefault();

    [JsonProperty("_ObjectIdentity_")]
    public string ObjectIdentity { get; private set; }

    [JsonProperty("_ObjectType_")]
    public string ObjectType { get; private set; }

    [JsonProperty("_ObjectVersion_")]
    public string ObjectVersion { get; private set; }

}
