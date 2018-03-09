//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Common
{

    public static class TypeExtensions
    {

        public static bool IsGenericSubclassOf(this Type targetType, Type compareType)
        {
            if (targetType.IsGenericType)
            {
                if (targetType.GetGenericTypeDefinition() == compareType)
                {
                    return true;
                }
                if (targetType.BaseType != null)
                {
                    return targetType.BaseType.IsGenericSubclassOf(compareType);
                }
            }
            return false;
        }

        public static T GetCustomAttribute<T>(this Type type) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(type, typeof(T));
        }

        public static T GetCustomAttribute<T>(this Type type, bool inherit) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(type, typeof(T), inherit);
        }

    }

}
