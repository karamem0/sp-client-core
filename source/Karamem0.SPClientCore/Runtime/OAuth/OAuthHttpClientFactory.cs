//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Net.Http;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public static class OAuthHttpClientFactory
{

    private static readonly Lazy<HttpClient> instance = new(() => new HttpClient());

    public static HttpClient Create()
    {
        return instance.Value;
    }

}
