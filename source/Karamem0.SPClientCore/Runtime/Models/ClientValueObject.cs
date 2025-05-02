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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ClientValueObject : JsonValueObject
{

    public static ClientValueObject Create<T>(IReadOnlyDictionary<string, object?> parameters) where T : ClientValueObject, new()
    {
        var value = new T();
        foreach (var propertyInfo in value
                     .GetType()
                     .GetDeclaredProperties())
        {
            if (parameters.TryGetValue(propertyInfo.Name, out var propertyValue))
            {
                if (propertyValue is SwitchParameter switchValue)
                {
                    var switchAttribute = propertyInfo.GetCustomAttribute<SwitchParameterValueAttribute>();
                    if (switchAttribute is not null)
                    {
                        propertyInfo.SetValue(value, switchValue.ToBool() ? switchAttribute.TrueValue : switchAttribute.FalseValue);
                    }
                    else
                    {
                        propertyInfo.SetValue(value, switchValue.ToBool());
                    }
                }
                else
                {
                    propertyInfo.SetValue(value, propertyValue);
                }
            }
            else
            {
                var defaultAttribute = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
                if (defaultAttribute is not null)
                {
                    propertyInfo.SetValue(value, defaultAttribute.Value);
                }
            }
        }
        return value;
    }

    private static readonly IReadOnlyDictionary<string, Type> ClientValueObjectDictionary = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(type => type.IsSubclassOf(typeof(ClientValueObject)))
        .Where(type => type.IsDefined(typeof(ClientObjectAttribute)))
        .ToDictionary(
            type => type.GetCustomAttribute<ClientObjectAttribute>()
                        .Name ??
                    throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull),
            type => type
        );

    public static Type GetType(string name)
    {
        return ClientValueObjectDictionary
            .Where(item => item.Key == name)
            .Select(item => item.Value)
            .SingleOrDefault();
    }

    [JsonProperty("_ObjectType_")]
    public string? ObjectType { get; private set; }

}
