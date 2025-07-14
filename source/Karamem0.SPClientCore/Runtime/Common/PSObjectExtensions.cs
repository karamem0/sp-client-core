//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class PSObjectExtensions
{

    public static IDictionary<string, object?> ToDictionary(this PSObject psObject)
    {
        if (psObject.BaseObject is Hashtable hashtable)
        {
            return hashtable.ToDictionary<string, object?>();
        }
        else
        {
            return psObject.Properties.ToDictionary(property => property.Name, property => (object?)property.Value);
        }
    }

}
