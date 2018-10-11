//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public abstract class ClientContext
    {

        private Uri baseAddress;

        protected ClientContext(Uri baseAddress)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }
            this.baseAddress = new Uri(baseAddress.ToString().TrimEnd('/'), UriKind.Absolute);
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

        protected abstract HttpClient HttpClient { get; }

        public void DeleteObject(Uri requestUrl)
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Post, requestUrl);
            requestMessage.Headers.Add("X-HTTP-Method", "DELETE");
            requestMessage.Headers.Add("If-Match", "*");
            Trace.WriteLine(requestMessage);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            try
            {
                var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
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

        public T GetObject<T>(Uri requestUrl) where T : ClientObject
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Get, requestUrl);
            Trace.WriteLine(requestMessage);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
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

        public Stream GetStream(Uri requestUrl)
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Get, requestUrl);
            Trace.WriteLine(requestMessage);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
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

        public void MergeObject(Uri requestUrl, object requestPayload)
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Post, requestUrl);
            if (requestPayload != null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                var jsonContent = JsonConvert.SerializeObject(requestPayload, jsonSerializerSettings);
                requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            }
            var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
            requestMessage.Headers.Add("X-HTTP-Method", "MERGE");
            requestMessage.Headers.Add("If-Match", "*");
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            try
            {
                var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
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

        public void PostObject(Uri requestUrl, object requestPayload)
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Post, requestUrl);
            if (requestPayload != null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                var jsonContent = JsonConvert.SerializeObject(requestPayload, jsonSerializerSettings);
                requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            }
            var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(responseMessage);
            Trace.WriteLine(responseContent);
            try
            {
                var responsePayload = JsonConvert.DeserializeObject<ODataResultPayload>(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
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

        public T PostObject<T>(Uri requestUrl, object requestPayload) where T : ClientObject
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Post, requestUrl);
            if (requestPayload != null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                var jsonContent = JsonConvert.SerializeObject(requestPayload, jsonSerializerSettings);
                requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8);
                requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
            }
            var requestContent = requestMessage.Content?.ReadAsStringAsync().GetAwaiter().GetResult();
            Trace.WriteLine(requestMessage);
            Trace.WriteLine(requestContent);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
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

        public T PostStream<T>(Uri requestUrl, Stream requestStream) where T : ClientObject
        {
            var requestMessage = this.CreateHttpRequestMessage(HttpMethod.Post, requestUrl);
            if (requestStream != null)
            {
                requestMessage.Content = new StreamContent(requestStream);
            }
            Trace.WriteLine(requestMessage);
            var responseMessage = this.HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
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

        protected abstract HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, Uri requestUrl);

    }

}
