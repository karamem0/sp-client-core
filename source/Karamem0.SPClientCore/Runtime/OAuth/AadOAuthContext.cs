//
// Copyright (c) 2018-2025 karamem0
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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AadOAuthContext(
    string authority,
    string clientId,
    string resource,
    bool userMode = false
) : OAuthContext
{

    private readonly string authority = authority ?? throw new ArgumentNullException(nameof(authority));

    private readonly string clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

    private readonly bool userMode = userMode;

    private readonly TenantIdResolver tenantIdResolver = new(new Uri(resource, UriKind.Absolute));

    public OAuthMessage AcquireDeviceCode()
    {
        var requertParameters = new Dictionary<string, object>()
        {
            ["client_id"] = this.clientId,
            ["scope"] = string.Join(
                " ",
                this.userMode
                    ?
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.Manage"
                    ]
                    :
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                        $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                        $"{OAuthConstants.ResourceId}/User.Read.All"
                    ]
            )
        };
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/devicecode")
            .ConcatQuery(UriQuery.Create(requertParameters));
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
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
            ["grant_type"] = "device_code",
            ["client_id"] = this.clientId,
            ["code"] = deviceCode,
            ["scope"] = string.Join(
                " ",
                this.userMode
                    ?
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.Manage"
                    ]
                    :
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                        $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                        $"{OAuthConstants.ResourceId}/User.Read.All"
                    ]
            )
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
            ["grant_type"] = "password",
            ["client_id"] = this.clientId,
            ["username"] = userName,
            ["password"] = password,
            ["scope"] = string.Join(
                " ",
                this.userMode
                    ?
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.Manage"
                    ]
                    :
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                        $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                        $"{OAuthConstants.ResourceId}/User.Read.All"
                    ]
            )
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
            ["grant_type"] = "refresh_token",
            ["client_id"] = this.clientId,
            ["refresh_token"] = refreshToken,
            ["scope"] = string.Join(
                " ",
                this.userMode
                    ?
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.Manage"
                    ]
                    :
                    [
                        "offline_access",
                        $"{OAuthConstants.ResourceId}/AllSites.FullControl",
                        $"{OAuthConstants.ResourceId}/TermStore.ReadWrite.All",
                        $"{OAuthConstants.ResourceId}/User.Read.All"
                    ]
            )
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
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByCertificate(BinaryData certData, SecureString certPassword)
    {
        _ = certData ?? throw new ArgumentNullException(nameof(certData));
        _ = certPassword ?? throw new ArgumentNullException(nameof(certPassword));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var certificate = new X509Certificate2(certData.ToArray(), certPassword);
        var claims = new Dictionary<string, object>()
        {
            ["aud"] = requestUrl.ToString(),
            ["iss"] = this.clientId,
            ["jti"] = Guid
                .NewGuid()
                .ToString(),
            ["sub"] = this.clientId
        };
        var requertParameters = new Dictionary<string, object>()
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = this.clientId,
            ["client_assertion_type"] = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
            ["client_assertion"] = new JsonWebTokenHandler().CreateToken(
                new SecurityTokenDescriptor()
                {
                    Claims = claims,
                    SigningCredentials = new X509SigningCredentials(certificate)
                }
            ),
            ["scope"] = string.Join(" ", [$"{OAuthConstants.ResourceId}/.default"])
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
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

    public OAuthMessage AcquireTokenByCertificate(BinaryData certData, BinaryData keyData)
    {
        _ = certData ?? throw new ArgumentNullException(nameof(certData));
        _ = keyData ?? throw new ArgumentNullException(nameof(keyData));
        var tenantId = this.tenantIdResolver.Resolve();
        var requestUrl = new Uri(this.authority, UriKind.Absolute)
            .ConcatPath(tenantId)
            .ConcatPath("oauth2/v2.0/token");
        var certificate = new PemCertificate(certData, keyData);
        var timestamp = DateTimeOffset.UtcNow;
        var header = JsonConvert.SerializeObject(
            new Dictionary<string, string>()
            {
                ["alg"] = "RS256",
                ["typ"] = "JWT",
                ["x5t"] = Base64UrlEncoder.Encode(
                    HexStringEncoder
                        .Decode(certificate.Thumbprint)
                        .ToArray()
                )
            }
        );
        var claims = JsonConvert.SerializeObject(
            new Dictionary<string, object>()
            {
                ["aud"] = requestUrl.ToString(),
                ["exp"] = timestamp
                    .AddMinutes(10)
                    .ToUnixTimeSeconds(),
                ["iss"] = this.clientId,
                ["jti"] = Guid
                    .NewGuid()
                    .ToString(),
                ["nbf"] = timestamp.ToUnixTimeSeconds(),
                ["sub"] = this.clientId
            }
        );
        var token = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(header)) + "." + Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(claims));
        var signature = Base64UrlEncoder.Encode(
            certificate.RSA.SignData(
                Encoding.UTF8.GetBytes(token),
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1
            )
        );
        var assertion = string.Concat(
            token,
            ".",
            signature
        );
        var requertParameters = new Dictionary<string, object>()
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = this.clientId,
            ["client_assertion_type"] = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer",
            ["client_assertion"] = assertion,
            ["scope"] = string.Join(" ", [$"{OAuthConstants.ResourceId}/.default"])
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
            return JsonConvert.DeserializeObject<AadOAuthToken>(responseContent);
        }
        else
        {
            return JsonConvert.DeserializeObject<OAuthError>(responseContent);
        }
    }

}
