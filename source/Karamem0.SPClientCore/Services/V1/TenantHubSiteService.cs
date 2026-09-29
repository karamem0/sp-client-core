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

public interface ITenantHubSiteService
{

    Task<HubSite?> AddObjectAsync(
        Uri siteCollectionUrl,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task<HubSite?> GetObjectAsync(Guid hubSiteId, bool selectAllProperties = true);

    Task<HubSite?> GetObjectAsync(Uri hubSiteUrl, bool selectAllProperties = true);

    Task<IEnumerable<HubSite>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(HubSite hubSiteObject);

    Task SetObjectAsync(HubSite hubSiteObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TenantHubSiteService(ClientContext clientContext) : ClientService<HubSite>(clientContext), ITenantHubSiteService
{

    public async Task<HubSite?> AddObjectAsync(
        Uri siteCollectionUrl,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RegisterHubSiteWithCreationInformation",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<HubSiteCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(HubSite)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<HubSite?> GetObjectAsync(Guid hubSiteId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetHubSitePropertiesById",
                requestPayload.CreateParameter(hubSiteId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(HubSite)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<HubSite?> GetObjectAsync(Uri hubSiteUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetHubSitePropertiesByUrl",
                requestPayload.CreateParameter(hubSiteUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(HubSite)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<HubSite>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetHubSitesProperties"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(HubSite))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HubSiteEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public override async Task RemoveObjectAsync(HubSite hubSiteObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "UnregisterHubSite",
                requestPayload.CreateParameter(hubSiteObject.SiteCollectionUrl)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public override async Task SetObjectAsync(HubSite hubSiteObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetHubSitePropertiesByUrl",
                requestPayload.CreateParameter(hubSiteObject.SiteCollectionUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Empty)
        );
        var objectPath3 = requestPayload.Add(objectPath2, requestPayload.CreateSetPropertyDelegates(hubSiteObject, modificationInfo));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
