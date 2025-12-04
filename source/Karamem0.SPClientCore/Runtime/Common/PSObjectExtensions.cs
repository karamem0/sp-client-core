//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Collections;
using System.Management.Automation;

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
