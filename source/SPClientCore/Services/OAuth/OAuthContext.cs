//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.OAuth
{

    public class OAuthContext
    {

        private readonly string tenantId;

        private readonly string authority;

        private readonly string clientId;

        private readonly string resource;

        private readonly HttpClient httpClient = new HttpClient();

        public OAuthContext(string authority, string clientId, string resource)
        {
            if (string.IsNullOrEmpty(authority))
            {
                throw new ArgumentNullException(nameof(authority));
            }
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }
            this.authority = authority;
            this.clientId = clientId;
            this.resource = resource;
            var requestUrl = new Uri(resource, UriKind.Absolute).ConcatPath("_vti_bin/client.svc");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer");
            Trace.WriteLine(requestMessage);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            var authHeaderValue = responseMessage.Headers.WwwAuthenticate.FirstOrDefault();
            if (authHeaderValue != null)
            {
                var authRealm = Regex.Match(authHeaderValue.Parameter, "realm=\"(.+?)\"");
                if (authRealm.Success)
                {
                    this.tenantId = authRealm.Groups[1].Value;
                }
            }
            if (this.tenantId == null)
            {
                throw new ArgumentNullException(nameof(resource), StringResources.ErrorCannotResolveTenantId);
            }
        }

        public OAuthMessage AcquireDeviceCode()
        {
            var requertParameters = new Dictionary<string, object>()
            {
                { "client_id", this.clientId },
                { "scope", string.Join(" ", new[] {
                    "offline_access",
                    this.resource + "/AllSites.FullControl",
                    this.resource + "/User.Read.All"
                })}
            };
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantId)
                .ConcatPath("oauth2/v2.0/devicecode")
                .ConcatQuery(UriQuery.Create(requertParameters));
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Add("Accept", "application/json");
            Trace.WriteLine(requestMessage);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
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
            if (string.IsNullOrEmpty(deviceCode))
            {
                throw new ArgumentNullException(nameof(deviceCode));
            }
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantId)
                .ConcatPath("oauth2/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "device_code" },
                { "client_id", this.clientId },
                { "code", deviceCode },
                { "scope", string.Join(" ", new[] {
                    "offline_access",
                    this.resource + "/AllSites.FullControl",
                    this.resource + "/User.Read.All"
                })}
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OAuthToken>(responseContent);
            }
            else
            {
                return JsonConvert.DeserializeObject<OAuthError>(responseContent);
            }
        }

        public OAuthMessage AcquireTokenByPassword(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantId)
                .ConcatPath("oauth2/v2.0/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "password" },
                { "client_id", this.clientId },
                { "username", userName },
                { "password", password },
                { "scope", string.Join(" ", new[] {
                    "offline_access",
                    this.resource + "/AllSites.FullControl",
                    this.resource + "/User.Read.All"
                })}
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OAuthToken>(responseContent);
            }
            else
            {
                return JsonConvert.DeserializeObject<OAuthError>(responseContent);
            }
        }

        public OAuthMessage AcquireTokenByRefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantId)
                .ConcatPath("oauth2/v2.0/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "refresh_token" },
                { "client_id", this.clientId },
                { "refresh_token", refreshToken },
                { "scope", string.Join(" ", new[] {
                    "offline_access",
                    this.resource + "/AllSites.FullControl",
                    this.resource + "/User.Read.All"
                })}
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OAuthToken>(responseContent);
            }
            else
            {
                return JsonConvert.DeserializeObject<OAuthError>(responseContent);
            }
        }

        public Uri GetAdminConsentUrl()
        {
            var requertParameters = new Dictionary<string, object>()
            {
                { "client_id", this.clientId },
                { "redirect_uri", Constants.AdminConsentRedirectUrl }
            };
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantId)
                .ConcatPath("adminconsent")
                .ConcatQuery(UriQuery.Create(requertParameters));
            return requestUrl;
        }

    }

}
