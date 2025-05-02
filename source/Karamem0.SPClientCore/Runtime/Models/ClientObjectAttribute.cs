//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
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
        var objectAttribute = type.GetCustomAttribute<ClientObjectAttribute>();
        _ = objectAttribute ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        if (Guid.TryParse(objectAttribute.Id, out var objectId))
        {
            return objectId;
        }
        else
        {
            return Guid.Empty;
        }
    }

    public static string? GetName(Type type)
    {
        var objectAttribute = type.GetCustomAttribute<ClientObjectAttribute>();
        _ = objectAttribute ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return objectAttribute.Name;
    }

    public string? Id { get; set; }

    public string? Name { get; set; }

}
