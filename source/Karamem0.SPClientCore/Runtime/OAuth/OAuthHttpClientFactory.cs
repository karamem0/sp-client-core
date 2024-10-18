//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public static class OAuthHttpClientFactory
{

    private static readonly Lazy<HttpClient> instance = new(() => new HttpClient());

    public static HttpClient Create()
    {
        return instance.Value;
    }

}
