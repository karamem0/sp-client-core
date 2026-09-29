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

public interface ITenantPersonalSiteService
{

    Task<TenantOperationResult?> AddObjectAsync(IEnumerable<string> userIds, bool selectAllProperties = true);

    Task AddObjectAwaitAsync(IEnumerable<string> userIds);

    Task<string?> GetObjectAsync(string userId);

}

public class TenantPersonalSiteService(ClientContext clientContext) : TenantClientService(clientContext), ITenantPersonalSiteService
{

    public async Task<TenantOperationResult?> AddObjectAsync(IEnumerable<string> userIds, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RequestPersonalSites",
                requestPayload.CreateParameter(userIds)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task AddObjectAwaitAsync(IEnumerable<string> userIds)
    {
        await this.WaitObjectAsync(await this.AddObjectAsync(userIds));
    }

    public async Task<string?> GetObjectAsync(string userId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetPersonalSiteUrl",
                requestPayload.CreateParameter(userId)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionMethod>()));
    }

}
