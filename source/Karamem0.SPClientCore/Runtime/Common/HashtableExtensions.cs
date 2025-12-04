//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Collections;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class HashtableExtensions
{

    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hashtable)
    {
        return hashtable
            .Keys.Cast<object>()
            .ToDictionary(key => (TKey)key, key => (TValue)hashtable[key]);
    }

}
