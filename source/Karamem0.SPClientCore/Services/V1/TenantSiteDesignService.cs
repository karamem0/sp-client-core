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

public interface ITenantSiteDesignService
{

    Task<TenantSiteDesign?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task<TenantSiteDesign?> GetObjectAsync(Guid siteDesignId);

    Task<IEnumerable<TenantSiteDesign>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(TenantSiteDesign siteDesignObject);

}

public class TenantSiteDesignService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteDesignService
{

    public async Task<TenantSiteDesign?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateSiteDesign",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantSiteDesignCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantSiteDesign)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteDesign>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantSiteDesign?> GetObjectAsync(Guid siteDesignId)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Tenant),
                "GetSiteDesign",
                requestPayload.CreateParameter(siteDesignId)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteDesign>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<TenantSiteDesign>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetSiteDesigns"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantSiteDesign))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteDesignEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(TenantSiteDesign siteDesignObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteSiteDesign",
                requestPayload.CreateParameter(siteDesignObject.Id)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
