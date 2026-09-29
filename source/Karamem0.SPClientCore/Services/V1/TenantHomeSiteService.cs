//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantHomeSiteService
{

    Task<Uri?> GetObjectAsync();

    Task RemoveObjectAsync();

    Task SetObjectAsync(Uri homeSiteUrl);

}

public class TenantHomeSiteService(ClientContext clientContext) : ClientService(clientContext), ITenantHomeSiteService
{

    public async Task<Uri?> GetObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "GetSPHSiteUrl"));
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Uri>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task RemoveObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "RemoveSPHSite"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(Uri homeSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetSPHSite",
                requestPayload.CreateParameter(homeSiteUrl)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
