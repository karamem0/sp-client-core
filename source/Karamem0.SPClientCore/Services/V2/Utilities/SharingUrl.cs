//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V2.Utilities;

public static class SharingUrl
{

    public static string Create(Uri absoluteUrl)
    {
        var bytes = Encoding.UTF8.GetBytes(absoluteUrl.ToString());
        var base64 = Convert.ToBase64String(bytes);
        return $"u!{base64.TrimEnd('=').Replace('/', '_').Replace('+', '-')}";
    }

    public static string Create(Uri baseUrl, Uri relativeUrl)
    {
        return Create(baseUrl.ConcatPath(relativeUrl.ToString()));
    }

}
