//
// Copyright (c) 2018-2025 karamem0
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

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ClientQueryIgnoreAttribute : Attribute
{

    public static bool IsMatch(PropertyInfo propertyInfo, IEnumerable<string> conditions)
    {
        var conditionAttribute = propertyInfo.GetCustomAttribute<ClientQueryIgnoreAttribute>();
        if (conditionAttribute is null)
        {
            return true;
        }
        else if (conditionAttribute.Name is null)
        {
            return false;
        }
        else if (conditions is null)
        {
            return false;
        }
        else
        {
            return conditions.Contains(conditionAttribute.Name);
        }
    }

    public string? Name { get; set; }

}
