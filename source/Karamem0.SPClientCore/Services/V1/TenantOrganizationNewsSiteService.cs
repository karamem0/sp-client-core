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

public interface ITenantOrganizationNewsSiteService
{

    Task AddObjectAsync(Uri organizationNewsSiteUrl);

    Task<IEnumerable<Uri>?> GetObjectEnumerableAsync();

    Task RemoveObjectAsync(Uri organizationNewsSiteUrl);

}

public class TenantOrganizationNewsSiteService(ClientContext clientContext) : ClientService(clientContext), ITenantOrganizationNewsSiteService
{

    public async Task AddObjectAsync(Uri organizationNewsSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetOrgNewsSite",
                requestPayload.CreateParameter(organizationNewsSiteUrl)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<IEnumerable<Uri>?> GetObjectEnumerableAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "GetOrgNewsSites"));
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<IEnumerable<Uri>>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task RemoveObjectAsync(Uri organizationNewsSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveOrgNewsSite",
                requestPayload.CreateParameter(organizationNewsSiteUrl)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
