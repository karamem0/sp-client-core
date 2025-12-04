//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommunications.Disconnect, "Site")]
[OutputType(typeof(void))]
public class DisconnectSiteCommand : ClientObjectCmdlet
{

    [Parameter(
        Mandatory = false,
        Position = 0,
        ValueFromPipeline = true
    )]
    public Uri? Url { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.Url is null)
        {
            if (ClientService.ServiceProvider is null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var clientContext = ClientService.ServiceProvider.GetService<ClientContext>();
            _ = clientContext ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            var accessToken = clientContext.AccessToken;
            var jwtToken = new JsonWebToken(accessToken);
            var jwtTenantId = jwtToken.GetPayloadValue<string>("tid");
            AadOAuthTokenStore.Remove(jwtTenantId);
            ClientService.Unregister();
        }
        else
        {
            AadOAuthTokenStore.Remove(this.Url);
        }
    }

}
