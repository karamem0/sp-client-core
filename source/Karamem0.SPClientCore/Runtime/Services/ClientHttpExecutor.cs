//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientHttpExecutor
{

    private readonly HttpClient httpClient;

    public ClientHttpExecutor()
    {
        this.httpClient = new HttpClient(new ClientHttpMessageHandler())
        {
            Timeout = Timeout.InfiniteTimeSpan
        };
        this.httpClient.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue(ClientConstants.UserAgent, this.GetType().Assembly.GetName().Version.ToString(3))
        );
    }

    public void Execute(
        Func<HttpRequestMessage> requestCallback,
        Func<HttpResponseMessage, Task<object>> responseCallback
    )
    {
        var syncContext = new ClientHttpSynchronizationContext();
        try
        {
            SynchronizationContext.SetSynchronizationContext(syncContext);
            var executeTask = this.ExecuteAsync(requestCallback, responseCallback);
            syncContext.Wait();
            _ = executeTask.GetAwaiter().GetResult();
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(null);
        }
    }

    public T Execute<T>(Func<HttpRequestMessage> requestCallback, Func<HttpResponseMessage, Task<T>> responseCallback)
    {
        var syncContext = new ClientHttpSynchronizationContext();
        try
        {
            SynchronizationContext.SetSynchronizationContext(syncContext);
            var executeTask = this.ExecuteAsync(requestCallback, responseCallback);
            syncContext.Wait();
            return executeTask.GetAwaiter().GetResult();
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(null);
        }
    }

    public async Task<T> ExecuteAsync<T>(
        Func<HttpRequestMessage> requestCallback,
        Func<HttpResponseMessage, Task<T>> responseCallback
    )
    {
        _ = requestCallback ?? throw new ArgumentNullException(nameof(requestCallback));
        _ = responseCallback ?? throw new ArgumentNullException(nameof(responseCallback));
        var syncContext = SynchronizationContext.Current as ClientHttpSynchronizationContext;
        try
        {
            var errorCount = 0;
            while (true)
            {
                var requestMessage = requestCallback.Invoke();
                var responseMessage = await this.httpClient.SendAsync(requestMessage);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseCallback.Invoke(responseMessage);
                }
                else
                {
                    var statusCode = (int)responseMessage.StatusCode;
                    if (statusCode is 429 or 502 or 503)
                    {
                        errorCount += 1;
                        if (errorCount > ClientConstants.MaxRetryCount)
                        {
                            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
                        }
                        await Task.Delay(
                            responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(
                                TimeSpan.FromSeconds(errorCount + 1)
                            )
                        );
                    }
                    else
                    {
                        var responseContent = await responseMessage.Content.ReadAsStringAsync();
                        if (JsonSerializerManager.Instance.TryDeserialize(responseContent, out OAuthError oAuthError))
                        {
                            throw new InvalidOperationException(oAuthError.ErrorDescription);
                        }
                        if (JsonSerializerManager.Instance.TryDeserialize(
                                responseContent,
                                out ODataV1ResultPayload v1Payload
                            ))
                        {
                            throw new InvalidOperationException(v1Payload.Error.Message.Value);
                        }
                        if (JsonSerializerManager.Instance.TryDeserialize(
                                responseContent,
                                out ODataV2ResultPayload v2Payload
                            ))
                        {
                            throw new InvalidOperationException(v2Payload.Error.Message);
                        }
                        throw new InvalidOperationException(StringResources.ErrorUnknown);
                    }
                }
            }
        }
        finally
        {
            syncContext.Complete();
        }
    }

}
