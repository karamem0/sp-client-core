//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Diagnostics;
using System.Net.Http;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientHttpMessageHandler : DelegatingHandler
{

    public ClientHttpMessageHandler()
        : base(new HttpClientHandler())
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        Trace.WriteLine(requestMessage);
        if (requestMessage.Content is not null)
        {
            Trace.WriteLine(await requestMessage.Content.ReadAsStringAsync());
        }
        var responseMessage = await base.SendAsync(requestMessage, cancellationToken);
        Trace.WriteLine(responseMessage);
        if (responseMessage.Content is not null)
        {
            Trace.WriteLine(await responseMessage.Content.ReadAsStringAsync());
        }
        return responseMessage;
    }

}
