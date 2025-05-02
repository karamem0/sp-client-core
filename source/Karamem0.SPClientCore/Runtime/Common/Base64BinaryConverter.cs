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

public static class Base64BinaryConverter
{

    public static bool TryParse(string input, out byte[] result)
    {
        var match = Regex.Match(input, "^/Base64Binary\\(([0-9a-zA-Z+/]*={0,2})\\)/$");
        if (match.Success)
        {
            result = Convert.FromBase64String(match.Groups[1].Value);
            return true;
        }
        result = [];
        return false;
    }

}
