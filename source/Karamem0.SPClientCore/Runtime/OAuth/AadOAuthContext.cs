//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AadOAuthContext(string authority, string clientId, string resource, bool userMode) : OAuthContext
{

    private readonly string authority = authority ?? throw new ArgumentNullException(nameof(authority));

    private readonly string clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

    private readonly bool userMode = userMode;

    private readonly TenantIdResolver tenantIdResolver = new(new Uri(resource, UriKind.Absolute));

    public OAuthMessage AcquireDeviceCode()
    {
        var requertParameters = new Dictionary<string, object>()
        {
            { "client_id", this.clientId },
            { "scope", string.Join(" ", this.userMode
                ? [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.Manage"
                ]
                : [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                    $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                    $"{OAuthConstants.ResourceId}/User.Read.All"
                ])
            }
        };
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/devicecode")
            .ConcatQuery(UriQuery.Create(requertParameters));
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<OAuthDeviceCode>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByDeviceCode(string deviceCode)
    {
        _ = deviceCode ?? throw new ArgumentNullException(nameof(deviceCode));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var requertParameters = new Dictionary<string, object>()
        {
            { "grant_type", "device_code" },
            { "client_id", this.clientId },
            { "code", deviceCode },
            { "scope", string.Join(" ", this.userMode
                ? [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.Manage"
                ]
                : [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                    $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                    $"{OAuthConstants.ResourceId}/User.Read.All"
                ])
            }
        };
        var requestContent = UriQuery.Create(requertParameters);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded")
        };
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByPassword(string userName, string password)
    {
        _ = userName ?? throw new ArgumentNullException(nameof(userName));
        _ = password ?? throw new ArgumentNullException(nameof(password));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var requertParameters = new Dictionary<string, object>()
        {
            { "grant_type", "password" },
            { "client_id", this.clientId },
            { "username", userName },
            { "password", password },
            { "scope", string.Join(" ", this.userMode
                ? [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.Manage"
                ]
                : [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                    $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                    $"{OAuthConstants.ResourceId}/User.Read.All"
                ])
            }
        };
        var requestContent = UriQuery.Create(requertParameters);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded")
        };
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByRefreshToken(string refreshToken)
    {
        _ = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var requertParameters = new Dictionary<string, object>()
        {
            { "grant_type", "refresh_token" },
            { "client_id", this.clientId },
            { "refresh_token", refreshToken },
            { "scope", string.Join(" ", this.userMode
                ? [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.Manage"
                ]
                : [
                    "offline_access",
                    $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                    $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                    $"{OAuthConstants.ResourceId}/User.Read.All"
                ])
            }
        };
        var requestContent = UriQuery.Create(requertParameters);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded")
        };
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByCertificate(byte[] certBytes, SecureString certPassword)
    {
        _ = certBytes ?? throw new ArgumentNullException(nameof(certBytes));
        _ = certPassword ?? throw new ArgumentNullException(nameof(certPassword));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var requertParameters = new Dictionary<string, object>()
        {
            { "grant_type", "client_credentials" },
            { "client_id", this.clientId },
            { "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" },
            { "client_assertion", new JsonWebTokenHandler().CreateToken(new SecurityTokenDescriptor()
                {
                    Claims = new Dictionary<string, object>()
                    {
                        { "aud", requestUrl.ToString() },
                        { "iss", this.clientId },
                        { "jti", Guid.NewGuid().ToString() },
                        { "sub", this.clientId }
                    },
                    SigningCredentials = new X509SigningCredentials(new X509Certificate2(certBytes, certPassword))
                })
            },
            { "scope", string.Join(" ", [ $"{OAuthConstants.ResourceId}/.default" ]) }
        };
        var requestContent = UriQuery.Create(requertParameters);
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded")
        };
        requestMessage.Headers.Add("Accept", "application/json");
        var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
        var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

}
