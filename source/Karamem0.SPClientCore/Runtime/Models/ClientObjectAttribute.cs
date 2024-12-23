//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ClientObjectAttribute : Attribute
{

    public static Guid GetId(Type type)
    {
        var objectAttribute = type.GetCustomAttribute<ClientObjectAttribute>() ?? throw new InvalidOperationException();
        var objectId = Guid.Parse(objectAttribute.Id);
        return objectId;
    }

    public static string GetName(Type type)
    {
        var objectAttribute = type.GetCustomAttribute<ClientObjectAttribute>() ?? throw new InvalidOperationException();
        var objectName = objectAttribute.Name;
        return objectName;
    }

    public ClientObjectAttribute()
    {
    }

    public string Id { get; set; }

    public string Name { get; set; }

}
