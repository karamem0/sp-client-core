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

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class PropertyInfoExtensions
{

    public static T GetCustomAttribute<T>(this PropertyInfo property) where T : Attribute
    {
        return (T)Attribute.GetCustomAttribute(property, typeof(T));
    }

    public static T GetCustomAttribute<T>(this PropertyInfo property, bool inherit) where T : Attribute
    {
        return (T)Attribute.GetCustomAttribute(property, typeof(T), inherit);
    }

    public static bool TryGetValue(this PropertyInfo property, object obj, out object value)
    {
        value = property.GetValue(obj);
        if (value is not null)
        {
            if (property.PropertyType.IsGenericSubclassOf(typeof(Nullable<>)))
            {
                value = property.PropertyType.GetProperty("Value").GetValue(value);
            }
            return true;
        }
        return false;
    }

}
