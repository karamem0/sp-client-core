//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common
{

    public static class UriQuery
    {

        public static string Create(IReadOnlyDictionary<string, object> parameters, bool quote = false)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            return string.Join("&", parameters.Select(pair =>
            {
                var key = Uri.EscapeDataString(pair.Key);
                if (pair.Value == null)
                {
                    return $"{key}=";
                }
                else if (pair.Value is string)
                {
                    var value = Uri.EscapeDataString(pair.Value.ToString());
                    if (quote)
                    {
                        return $"{key}=%27{value}%27";
                    }
                    else
                    {
                        return $"{key}={value}";
                    }
                }
                else if (pair.Value is bool)
                {
                    var value = Uri.EscapeDataString(pair.Value.ToString().ToLower());
                    return $"{key}={value}";
                }
                else
                {
                    var value = Uri.EscapeDataString(pair.Value.ToString());
                    return $"{key}={value}";
                }
            }));
        }

    }

}
