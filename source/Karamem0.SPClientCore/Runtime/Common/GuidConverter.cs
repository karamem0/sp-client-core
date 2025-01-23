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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class GuidConverter
{

    public static bool TryParse(string input, out Guid result)
    {
        var match = Regex.Match(
            input,
            "^/Guid\\(([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})\\)/$"
        );
        if (match.Success)
        {
            if (Guid.TryParse(match.Groups[1].Value, out var guid))
            {
                result = guid;
                return true;
            }
        }
        result = Guid.Empty;
        return false;
    }

}
