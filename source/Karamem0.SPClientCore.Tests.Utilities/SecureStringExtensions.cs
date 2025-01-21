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
using System.Security;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Utilities;

public static class SecureStringExtensions
{

    public static SecureString ToSecureString(this string value)
    {
        _ = value ?? throw new ArgumentNullException(nameof(value));
        var secureString = new SecureString();
        foreach (var character in value)
        {
            secureString.AppendChar(character);
        }
        return secureString;
    }

}
