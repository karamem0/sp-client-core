//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class EnumerableExtensions
{

    public static IEnumerable<IEnumerable<T>> Chunks<T>(this IEnumerable<T> collection, int size)
    {
        if (size < 1)
        {
            throw new ArgumentException(string.Format(StringResources.ErrorValueCannotBeLessThan, 1), nameof(size));
        }
        while (collection.Any())
        {
            yield return collection.Take(size);
            collection = collection.Skip(size);
        }
    }

}
