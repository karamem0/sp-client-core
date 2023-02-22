//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common
{

    public static class HashtableExtensions
    {

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hashtable)
        {
            _ = hashtable ?? throw new ArgumentNullException(nameof(hashtable));
            return hashtable.Keys.Cast<object>().ToDictionary(key => (TKey)key, key => (TValue)hashtable[key]);
        }

    }

}
