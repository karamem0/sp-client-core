//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientContext
{

    public static ClientContext Create(
        Uri baseAddress,
        AadOAuthContext oAuthContext,
        AadOAuthToken oAuthToken
    )
    {
        return new ClientContext(
            baseAddress,
            new AadOAuthTokenProvider(
                baseAddress,
                oAuthContext,
                oAuthToken
            )
        );
    }

    public static ClientContext Create(
        Uri baseAddress,
        AcsOAuthContext oAuthContext,
        AcsOAuthToken oAuthToken
    )
    {
        return new ClientContext(baseAddress, new AcsOAuthTokenProvider(oAuthContext, oAuthToken));
    }

    private Uri baseAddress;

    private readonly OAuthTokenProvider oAuthTokenProvider;

    private readonly ClientHttpExecutor clientHttpExecutor;

    private ClientContext(Uri baseAddress, OAuthTokenProvider oAuthTokenProvider)
        : base()
    {
        this.baseAddress = new Uri(
            baseAddress
                .ToString()
                .TrimEnd('/'),
            UriKind.Absolute
        );
        this.oAuthTokenProvider = oAuthTokenProvider;
        this.clientHttpExecutor = new ClientHttpExecutor();
    }

    public Uri BaseAddress
    {
        get => this.baseAddress;
        set => this.baseAddress = new Uri(
            value
                .ToString()
                .TrimEnd('/'),
            UriKind.Absolute
        );
    }

    public string? AccessToken => this.oAuthTokenProvider.CurrentAccessToken;

    public async Task DeleteObjectAsync(Uri requestUrl)
    {
        _ = await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("X-HTTP-Method", "DELETE");
                requestMessage.Headers.Add("If-Match", "*");
                return requestMessage;
            },
            responseMessage => responseMessage.Content.ReadAsStringAsync()
        );
    }

    public async Task<T?> GetObjectAsync<T>(Uri requestUrl) where T : ODataV1Object
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = JsonSerializerManager.Instance.Deserialize<ODataV1ResultPayload<T>>(responseContent);
                _ = responsePayload ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (responsePayload.Error is null)
                {
                    return responsePayload.Entry;
                }
                else
                {
                    throw new InvalidOperationException(responsePayload.Error.Message?.Value);
                }
            }
        );
    }

    public async Task<T?> GetObjectV2Async<T>(Uri requestUrl) where T : ODataV2Object
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json");
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = JsonSerializerManager.Instance.Deserialize<JToken>(responseContent);
                _ = responsePayload ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (responsePayload.Value<bool>("@odata.null"))
                {
                    return null;
                }
                else
                {
                    return responsePayload.ToObject<T>();
                }
            }
        );
    }

    public async Task<System.IO.Stream> GetStreamAsync(Uri requestUrl)
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                return requestMessage;
            },
            async responseMessage => await responseMessage.Content.ReadAsStreamAsync()
        );
    }

    public async Task PatchObjectAsync(Uri requestUrl, object? requestPayload)
    {
        _ = await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("X-HTTP-Method", "PATCH");
                requestMessage.Headers.Add("If-Match", "*");
                if (requestPayload is not null)
                {
                    var requestContent = JsonSerializerManager.Instance.Serialize(requestPayload);
                    requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                return requestMessage;
            },
            responseMessage => responseMessage.Content.ReadAsStringAsync()
        );
    }

    public async Task PostObjectAsync(Uri requestUrl, object? requestPayload)
    {
        _ = await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                if (requestPayload is not null)
                {
                    var jsonContent = JsonSerializerManager.Instance.Serialize(requestPayload);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                return requestMessage;
            },
            responseMessage => responseMessage.Content.ReadAsStringAsync()
        );
    }

    public async Task<T?> PostObjectAsync<T>(Uri requestUrl, object? requestPayload) where T : ODataV1Object
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                if (requestPayload is not null)
                {
                    var requestContent = JsonSerializerManager.Instance.Serialize(requestPayload);
                    requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = JsonSerializerManager.Instance.Deserialize<ODataV1ResultPayload<T>>(responseContent);
                _ = responsePayload ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (responsePayload.Error is null)
                {
                    return responsePayload.Entry;
                }
                else
                {
                    throw new InvalidOperationException(responsePayload.Error.Message?.Value);
                }
            }
        );
    }

    public async Task PostStreamAsync(Uri requestUrl, System.IO.Stream requestStream)
    {
        _ = await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Content = new StreamContent(requestStream);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                return requestMessage;
            },
            async responseMessage => await responseMessage.Content.ReadAsStringAsync()
        );
    }

    public async Task<T?> PostStreamAsync<T>(Uri requestUrl, System.IO.Stream requestStream) where T : ODataV1Object
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Content = new StreamContent(requestStream);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = JsonSerializerManager.Instance.Deserialize<ODataV1ResultPayload<T>>(responseContent);
                _ = responsePayload ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (responsePayload.Error is null)
                {
                    return responsePayload.Entry;
                }
                else
                {
                    throw new InvalidOperationException(responsePayload.Error.Message?.Value);
                }
            }
        );
    }

    public async Task<ClientResultPayload> ProcessQueryAsync(ClientRequestPayload requestPayload)
    {
        return await this.clientHttpExecutor.ExecuteAsync(
            async () =>
            {
                var accessToken = await this.oAuthTokenProvider.GetAccessTokenAsync();
                var requestUrl = this.BaseAddress.ConcatPath("_vti_bin/client.svc/ProcessQuery");
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {accessToken}");
                var requestContent = requestPayload.ToString();
                requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml");
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = new ClientResultPayload(responseContent);
                if (responsePayload.ErrorInfo is null)
                {
                    return responsePayload;
                }
                else
                {
                    throw new InvalidOperationException(responsePayload.ErrorInfo.ErrorMessage);
                }
            }
        );
    }

}
