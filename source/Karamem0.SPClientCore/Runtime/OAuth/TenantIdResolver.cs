//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class TenantIdResolver(Uri baseAddress)
{

    private readonly HttpClient httpClient = OAuthHttpClientFactory.Create();

    private readonly Uri baseAddress = baseAddress;

    private string? tenantId;

    public string Resolve()
    {
        if (this.tenantId is null)
        {
            var requestUrl = this.baseAddress.ConcatPath("_vti_bin/client.svc");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            var responseMessage = this
                .httpClient.SendAsync(requestMessage)
                .GetAwaiter()
                .GetResult();
            var authHeaderValue = responseMessage.Headers.WwwAuthenticate.FirstOrDefault();
            if (authHeaderValue is not null)
            {
                var authRealm = Regex.Match(authHeaderValue.Parameter, "realm=\"(.+?)\"");
                if (authRealm.Success)
                {
                    this.tenantId = authRealm.Groups[1].Value;
                }
            }
        }
        return this.tenantId ?? throw new InvalidOperationException(StringResources.ErrorCannotResolveTenantId);
    }

}
