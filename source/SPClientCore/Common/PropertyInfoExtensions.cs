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
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Common
{

    public static class PropertyInfoExtensions
    {

        public static PropertyInfo GetDeclaringProperty(this PropertyInfo propertyInfo)
        {
            return propertyInfo.DeclaringType.GetProperty(propertyInfo.Name);
        }

    }

}
