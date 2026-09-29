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

public interface ITenantSiteTemplateService
{

    Task<IEnumerable<TenantSiteTemplate>?> GetObjectEnumerableAsync(uint lcid, int compatibilityLevel);

    Task<IEnumerable<TenantSiteTemplate>?> GetObjectEnumerableAsync();

}

public class TenantSiteTemplateService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteTemplateService
{

    public async Task<IEnumerable<TenantSiteTemplate>?> GetObjectEnumerableAsync(uint lcid, int compatibilityLevel)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSPOTenantWebTemplates",
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(compatibilityLevel)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Empty
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TenantSiteTemplate>?> GetObjectEnumerableAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetSPOTenantAllWebTemplates"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Empty
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
