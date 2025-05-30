//
// Copyright (c) 2018-2025 karamem0
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

    public string? AccessToken => this.oAuthTokenProvider.CurrentAceessToken;

    public void DeleteObject(Uri requestUrl)
    {
        _ = this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("X-HTTP-Method", "DELETE");
                requestMessage.Headers.Add("If-Match", "*");
                return requestMessage;
            },
            responseMessage => responseMessage.Content.ReadAsStringAsync()
        );
    }

    public T? GetObject<T>(Uri requestUrl) where T : ODataV1Object
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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

    public T? GetObjectV2<T>(Uri requestUrl) where T : ODataV2Object
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
                requestMessage.Headers.Add("Accept", "application/json");
                return requestMessage;
            },
            async responseMessage =>
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responsePayload = JsonSerializerManager.Instance.Deserialize<JToken>(responseContent);
                _ = responsePayload ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (responsePayload.Value<bool>("@odata.null") is true)
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

    public System.IO.Stream GetStream(Uri requestUrl)
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                return requestMessage;
            },
            async responseMessage => await responseMessage.Content.ReadAsStreamAsync()
        );
    }

    public void PatchObject(Uri requestUrl, object? requestPayload)
    {
        _ = this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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

    public void PostObject(Uri requestUrl, object? requestPayload)
    {
        _ = this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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

    public T? PostObject<T>(Uri requestUrl, object? requestPayload) where T : ODataV1Object
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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

    public void PostStream(Uri requestUrl, System.IO.Stream requestStream)
    {
        _ = this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Content = new StreamContent(requestStream);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                return requestMessage;
            },
            responseMessage => responseMessage.Content.ReadAsStringAsync()
        );
    }

    public T? PostStream<T>(Uri requestUrl, System.IO.Stream requestStream) where T : ODataV1Object
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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

    public ClientResultPayload ProcessQuery(ClientRequestPayload requestPayload)
    {
        return this.clientHttpExecutor.Execute(
            () =>
            {
                var requestUrl = this.BaseAddress.ConcatPath("_vti_bin/client.svc/ProcessQuery");
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", $"Bearer {this.oAuthTokenProvider.GetAccessToken()}");
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
