//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common
{

    public static class DictionaryExtensions
    {

        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> collection, TKey key, TValue defaultValue)
        {
            _ = collection ?? throw new ArgumentNullException(nameof(collection));
            if (collection.TryGetValue(key, out var value))
            {
                return value;
            }
            return defaultValue;
        }

    }

}
