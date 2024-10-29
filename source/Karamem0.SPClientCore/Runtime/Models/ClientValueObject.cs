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
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ClientValueObject : JsonValueObject
{

    private static readonly IReadOnlyDictionary<string, Type> ClientValueObjectDictionary =
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsSubclassOf(typeof(ClientValueObject)))
            .Where(type => type.IsDefined(typeof(ClientObjectAttribute)))
            .ToDictionary(type => type.GetCustomAttribute<ClientObjectAttribute>().Name, type => type);

    public static Type GetType(string name)
    {
        return ClientValueObjectDictionary
            .Where(item => item.Key == name)
            .Select(item => item.Value)
            .SingleOrDefault();
    }

    public ClientValueObject()
    {
    }

    public ClientValueObject(IReadOnlyDictionary<string, object> parameters)
    {
        _ = parameters ?? throw new ArgumentNullException(nameof(parameters));
        foreach (var propertyInfo in this.GetType().GetDeclaredProperties())
        {
            if (parameters.TryGetValue(propertyInfo.Name, out var value))
            {
                if (value is SwitchParameter switchValue)
                {
                    var switchAttribute = propertyInfo.GetCustomAttribute<SwitchParameterValueAttribute>();
                    if (switchAttribute is not null)
                    {
                        propertyInfo.SetValue(this, switchValue.ToBool() ? switchAttribute.TrueValue : switchAttribute.FalseValue);
                    }
                    else
                    {
                        propertyInfo.SetValue(this, switchValue.ToBool());
                    }
                }
                else
                {
                    propertyInfo.SetValue(this, value);
                }
            }
            else
            {
                var defaultAttribute = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
                if (defaultAttribute is not null)
                {
                    propertyInfo.SetValue(this, defaultAttribute.Value);
                }
            }
        }
    }

    [JsonProperty("_ObjectType_")]
    public string ObjectType { get; private set; }

}
