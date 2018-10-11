//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Karamem0.SharePoint.PowerShell.Common;
using System.Diagnostics;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public class NetworkClientContext : ClientContext
    {

        private NetworkCredential credential;

        private HttpClient httpClient;

        public NetworkClientContext(Uri baseAddress, NetworkCredential credential) : base(baseAddress)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            this.credential = credential;
        }

        protected override HttpClient HttpClient
        {
            get
            {
                if (this.httpClient == null)
                {
                    this.httpClient = new HttpClient(new HttpClientHandler() { Credentials = this.credential });
                    this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                }
                return this.httpClient;
            }
        }

        protected override HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, Uri requestUrl)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            if (httpMethod != HttpMethod.Get)
            {
                var contextInfoRequestUrl = this.BaseAddress.ConcatPath("_api/contextinfo");
                var contextInfoRequestMessage = new HttpRequestMessage(HttpMethod.Post, contextInfoRequestUrl);
                Trace.WriteLine(contextInfoRequestMessage);
                var contextInfoResponseMessage = this.HttpClient.SendAsync(contextInfoRequestMessage).GetAwaiter().GetResult();
                var contextInfoResponseContent = contextInfoResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Trace.WriteLine(contextInfoResponseMessage);
                Trace.WriteLine(contextInfoResponseContent);
                try
                {
                    var contextInfoResponsePayload = JsonConvert.DeserializeObject<ODataResultPayload<ContextInformation>>(contextInfoResponseContent);
                    if (contextInfoResponseMessage.IsSuccessStatusCode)
                    {
                        var contextInfo = contextInfoResponsePayload.Entry;
                        var contextWebInfo = contextInfo.ContextWebInformation;
                        var formDigestValue = contextWebInfo.FormDigestValue;
                        requestMessage.Headers.Add("X-RequestDigest", formDigestValue);
                    }
                    else
                    {
                        throw new InvalidOperationException(contextInfoResponsePayload.Error.Message.Value);
                    }
                }
                catch (JsonException)
                {
                    throw new InvalidOperationException(contextInfoResponseContent);
                }
            }
            return requestMessage;
        }

    }

}
