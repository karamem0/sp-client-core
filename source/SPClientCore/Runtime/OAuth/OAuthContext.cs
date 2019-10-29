//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    public class OAuthContext
    {

        private readonly string authority;

        private readonly string clientId;

        private readonly string resource;

        private readonly bool userMode;

        private readonly TenantIdResolver tenantIdResolver;

        private readonly HttpClient httpClient = new HttpClient();

        public OAuthContext(string authority, string clientId, string resource, bool userMode)
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
            this.userMode = userMode;
            this.tenantIdResolver = new TenantIdResolver(this.httpClient, new Uri(this.resource, UriKind.Absolute));
        }

        public OAuthMessage AcquireDeviceCode()
        {
            var requertParameters = new Dictionary<string, object>()
            {
                { "client_id", this.clientId },
                { "scope", string.Join(" ", this.userMode
                    ? new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.Manage"
                    }
                    : new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.FullControl",
                        $"{this.resource}/TermStore.ReadWrite.All",
                        $"{this.resource}/User.Read.All"
                    })
                }
            };
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantIdResolver.Resolve())
                .ConcatPath("oauth2/v2.0/devicecode")
                .ConcatQuery(UriQuery.Create(requertParameters));
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Add("Accept", "application/json");
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
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
            if (string.IsNullOrEmpty(deviceCode))
            {
                throw new ArgumentNullException(nameof(deviceCode));
            }
            var requestUrl = new Uri(this.authority, UriKind.Absolute)
                .ConcatPath(this.tenantIdResolver.Resolve())
                .ConcatPath("oauth2/v2.0/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "device_code" },
                { "client_id", this.clientId },
                { "code", deviceCode },
                { "scope", string.Join(" ", this.userMode
                    ? new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.Manage"
                    }
                    : new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.FullControl",
                        $"{this.resource}/TermStore.ReadWrite.All",
                        $"{this.resource}/User.Read.All"
                    })
                }
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
                .ConcatPath(this.tenantIdResolver.Resolve())
                .ConcatPath("oauth2/v2.0/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "password" },
                { "client_id", this.clientId },
                { "username", userName },
                { "password", password },
                { "scope", string.Join(" ", this.userMode
                    ? new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.Manage"
                    }
                    : new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.FullControl",
                        $"{this.resource}/TermStore.ReadWrite.All",
                        $"{this.resource}/User.Read.All"
                    })
                }
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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
                .ConcatPath(this.tenantIdResolver.Resolve())
                .ConcatPath("oauth2/v2.0/token");
            var requertParameters = new Dictionary<string, object>()
            {
                { "grant_type", "refresh_token" },
                { "client_id", this.clientId },
                { "refresh_token", refreshToken },
                { "scope", string.Join(" ", this.userMode
                    ? new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.Manage"
                    }
                    : new[]
                    {
                        "offline_access",
                        $"{this.resource}/AllSites.FullControl",
                        $"{this.resource}/TermStore.ReadWrite.All",
                        $"{this.resource}/User.Read.All"
                    })
                }
            };
            var requestContent = UriQuery.Create(requertParameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            requestMessage.Headers.Add("Accept", "application/json");
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OAuthToken>(responseContent);
            }
            else
            {
                return JsonConvert.DeserializeObject<OAuthError>(responseContent);
            }
        }

    }

}
