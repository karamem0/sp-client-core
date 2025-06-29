//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AcsOAuthContext(
    string clientId,
    SecureString clientSecret,
    string resource
) : OAuthContext
{

    private readonly NetworkCredential credential = new(clientId, clientSecret);

    private readonly string resource = resource;

    private readonly TenantIdResolver tenantIdResolver = new(new Uri(resource, UriKind.Absolute));

    public OAuthMessage? AcquireToken()
    {
        var tenantId = this.tenantIdResolver.Resolve();
        var resourceId = new Uri(this.resource, UriKind.Absolute).Host;
        var requestUrl = new Uri(OAuthConstants.AcsAuthority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("tokens/oauth/2");
        var requertParameters = new Dictionary<string, object?>()
        {
            {
                "grant_type", "client_credentials"
            },
            {
                "client_id", $"{this.credential.UserName}@{tenantId}"
            },
            {
                "client_secret", this.credential.Password
            },
            {
                "resource", $"{OAuthConstants.ResourceId}/{resourceId}@{tenantId}"
            }
        };
        var requestContent = UriQuery.Create(requertParameters);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = new StringContent(
                requestContent,
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            )
        };
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this
            .HttpClient.SendAsync(requestMessage)
            .GetAwaiter()
            .GetResult();
        var responseContent = responseMessage
            .Content.ReadAsStringAsync()
            .GetAwaiter()
            .GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<AcsOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

}
