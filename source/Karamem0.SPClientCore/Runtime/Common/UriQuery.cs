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
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class UriQuery
{

    public static string Create(IReadOnlyDictionary<string, object?> parameters, bool quote = false)
    {
        parameters ??= new Dictionary<string, object?>();
        return string.Join(
            "&",
            parameters.Select(pair =>
                {
                    var key = Uri.EscapeDataString(pair.Key);
                    if (pair.Value is null)
                    {
                        return $"{key}=";
                    }
                    switch (pair.Value)
                    {
                        case string:
                        case Guid:
                        case Uri:
                            var value = Uri.EscapeDataString(pair.Value.ToString());
                            if (quote)
                            {
                                return $"{key}=%27{value}%27";
                            }
                            else
                            {
                                return $"{key}={value}";
                            }
                        case bool:
                            return $"{key}={pair.Value.ToString().ToLower()}";
                        case short:
                        case ushort:
                        case int:
                        case uint:
                        case long:
                        case ulong:
                        case decimal:
                            return $"{key}={pair.Value}";
                        default:
                            return $"{key}={Uri.EscapeDataString(pair.Value.ToString())}";
                    }
                }
            )
        );
    }

}
