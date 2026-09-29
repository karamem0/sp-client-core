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

public interface ITenantListDesignService
{

    Task<TenantListDesign?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task<TenantListDesign?> GetObjectAsync(Guid listDesignId);

    Task<IEnumerable<TenantListDesign>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(TenantListDesign listDesignObject);

}

public class TenantListDesignService(ClientContext clientContext) : ClientService(clientContext), ITenantListDesignService
{

    public async Task<TenantListDesign?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateListDesign",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantListDesignCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantListDesign)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantListDesign>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantListDesign?> GetObjectAsync(Guid listDesignId)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Tenant),
                "GetListDesign",
                requestPayload.CreateParameter(listDesignId)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantListDesign>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<TenantListDesign>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetListDesigns"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantListDesign))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantListDesignEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(TenantListDesign listDesignObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveListDesign",
                requestPayload.CreateParameter(listDesignObject.Id)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
