//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services
{

    public class ClientContext
    {

        private Uri baseAddress;

        private readonly OAuthTokenCache oAuthTokenCache;

        private readonly HttpClient httpClient;

        public ClientContext(Uri baseAddress, OAuthTokenCache oAuthTokenCache)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }
            if (oAuthTokenCache == null)
            {
                throw new ArgumentNullException(nameof(oAuthTokenCache));
            }
            this.baseAddress = new Uri(baseAddress.ToString().TrimEnd('/'), UriKind.Absolute);
            this.oAuthTokenCache = oAuthTokenCache;
            this.httpClient = new HttpClient();
            this.httpClient.Timeout = Timeout.InfiniteTimeSpan;
        }

        public Uri BaseAddress
        {
            get
            {
                return this.baseAddress;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                this.baseAddress = new Uri(value.ToString().TrimEnd('/'), UriKind.Absolute);
            }
        }

        public void DeleteObject(Uri requestUrl)
        {
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                requestMessage.Headers.Add("X-HTTP-Method", "DELETE");
                requestMessage.Headers.Add("If-Match", "*");
                Trace.WriteLine(requestMessage);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                try
                {
                    var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(
                        responseContent,
                        JsonSerializerManager.JsonSerializerSettings);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else if ((int)responseMessage.StatusCode == 429)
                    {
                        Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
        }

        public T GetObject<T>(Uri requestUrl) where T : ODataObject
        {
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                Trace.WriteLine(requestMessage);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                try
                {
                    var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload<T>>(
                        responseContent,
                        JsonSerializerManager.JsonSerializerSettings);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return responsePayload.Entry;
                    }
                    else if ((int)responseMessage.StatusCode == 429)
                    {
                        Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
        }

        public System.IO.Stream GetStream(Uri requestUrl)
        {
            if (requestUrl == null)
            {
                throw new ArgumentNullException(nameof(requestUrl));
            }
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
            requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
            requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
            Trace.WriteLine(requestMessage);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseStream = responseMessage.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseStream;
            }
            else
            {
                throw new InvalidOperationException(responseMessage.ReasonPhrase);
            }
        }

        public void PatchObject(Uri requestUrl, object requestPayload)
        {
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                requestMessage.Headers.Add("X-HTTP-Method", "PATCH");
                requestMessage.Headers.Add("If-Match", "*");
                if (requestPayload != null)
                {
                    var jsonContent = JsonConvert.SerializeObject(requestPayload, JsonSerializerManager.JsonSerializerSettings);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(requestMessage);
                Trace.WriteLine(requestContent);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                try
                {
                    var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(
                        responseContent,
                        JsonSerializerManager.JsonSerializerSettings);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else if ((int)responseMessage.StatusCode == 429)
                    {
                        Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
        }

        public void PostObject(Uri requestUrl, object requestPayload)
        {
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                if (requestPayload != null)
                {
                    var jsonContent = JsonConvert.SerializeObject(requestPayload, JsonSerializerManager.JsonSerializerSettings);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(requestMessage);
                Trace.WriteLine(requestContent);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                try
                {
                    var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(
                        responseContent,
                        JsonSerializerManager.JsonSerializerSettings);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else if ((int)responseMessage.StatusCode == 429)
                    {
                        Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
        }

        public T PostObject<T>(Uri requestUrl, object requestPayload) where T : ODataObject
        {
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                if (requestPayload != null)
                {
                    var jsonContent = JsonConvert.SerializeObject(requestPayload, JsonSerializerManager.JsonSerializerSettings);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                }
                var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(requestMessage);
                Trace.WriteLine(requestContent);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                try
                {
                    var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload<T>>(
                        responseContent,
                        JsonSerializerManager.JsonSerializerSettings);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return responsePayload.Entry;
                    }
                    else if ((int)responseMessage.StatusCode == 429)
                    {
                        Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
        }

        public void PostStream(Uri requestUrl, System.IO.Stream requestStream)
        {
            if (requestUrl == null)
            {
                throw new ArgumentNullException(nameof(requestUrl));
            }
            if (requestStream == null)
            {
                throw new ArgumentNullException(nameof(requestStream));
            }
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
            requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
            requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
            requestMessage.Content = new StreamContent(requestStream);
            Trace.WriteLine(requestMessage);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            try
            {
                var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(responseContent);
                if (responsePayload.Error != null)
                {
                    throw new InvalidOperationException(responsePayload.Error.Message.Value);
                }
            }
            catch (JsonException)
            {
                throw new InvalidOperationException(responseContent);
            }
        }

        public T PostStream<T>(Uri requestUrl, System.IO.Stream requestStream) where T : ODataObject
        {
            if (requestUrl == null)
            {
                throw new ArgumentNullException(nameof(requestUrl));
            }
            if (requestStream == null)
            {
                throw new ArgumentNullException(nameof(requestStream));
            }
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
            requestMessage.Headers.Add("Accept", "application/json;odata=verbose");
            requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
            requestMessage.Content = new StreamContent(requestStream);
            Trace.WriteLine(requestMessage);
            var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            try
            {
                var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload<T>>(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responsePayload.Entry;
                }
                else
                {
                    throw new InvalidOperationException(responsePayload.Error.Message.Value);
                }
            }
            catch (JsonException)
            {
                throw new InvalidOperationException(responseContent);
            }
        }

        public ClientResultPayload ProcessQuery(ClientRequestPayload requestPayload)
        {
            if (requestPayload == null)
            {
                throw new ArgumentNullException(nameof(requestPayload));
            }
            for (var count = 1; count <= ClientConstants.MaxRetryCount; count++)
            {
                var requestContent = requestPayload.ToString();
                var requestUrl = this.BaseAddress.ConcatPath("_vti_bin/client.svc/ProcessQuery");
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMessage.Headers.Add("Authorization", "Bearer " + this.oAuthTokenCache.GetAccessToken());
                requestMessage.Headers.Add("User-Agent", "NONISV|karamem0|SPClientCore/" + this.GetType().Assembly.GetName().Version.ToString(3));
                requestMessage.Content = new StringContent(requestContent, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml");
                Trace.WriteLine(requestMessage);
                Trace.WriteLine(requestContent);
                var responseMessage = this.httpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
                var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(responseMessage);
                Trace.WriteLine(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responsePayload = new ClientResultPayload(responseContent);
                    if (responsePayload.ErrorInfo == null)
                    {
                        return responsePayload;
                    }
                    else
                    {
                        throw new InvalidOperationException(responsePayload.ErrorInfo.ErrorMessage);
                    }
                }
                else if ((int)responseMessage.StatusCode == 429)
                {
                    Thread.Sleep(responseMessage.Headers.RetryAfter.Delta.GetValueOrDefault(TimeSpan.FromSeconds(1)));
                }
                else
                {
                    throw new InvalidOperationException(responseContent);
                }
            }
            throw new InvalidOperationException(StringResources.ErrorMaxRetryCountExceeded);
        }

    }

}
