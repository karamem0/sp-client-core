//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantDeletedSiteCollectionService
{

    Task<TenantDeletedSiteCollection?> GetObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task<TenantDeletedSiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true);

    Task<IEnumerable<TenantDeletedSiteCollection>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<TenantOperationResult?> RemoveObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task RemoveObjectAwaitAsync(TenantDeletedSiteCollection siteCollectionObject);

    Task<TenantOperationResult?> RestoreObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task RestoreObjectAwaitAsync(TenantDeletedSiteCollection siteCollectionObject);

}

public class TenantDeletedSiteCollectionService(ClientContext clientContext) : TenantClientService(clientContext), ITenantDeletedSiteCollectionService
{

    public async Task<TenantDeletedSiteCollection?> GetObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantDeletedSiteCollection)))
        );
        var clientObject = await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantDeletedSiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
        var clientObjectUrl = clientObject?.Url;
        _ = clientObjectUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return await this.GetObjectAsync(clientObjectUrl, selectAllProperties);
    }

    public async Task<TenantDeletedSiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetDeletedSitePropertiesByUrl",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(false)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantDeletedSiteCollection)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantDeletedSiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TenantDeletedSiteCollection>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetDeletedSitePropertiesFromSharePoint",
                requestPayload.CreateParameter(null)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantDeletedSiteCollection))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantOperationResult?> RemoveObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RemoveDeletedSite",
                requestPayload.CreateParameter(siteCollectionObject.Url)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAwaitAsync(TenantDeletedSiteCollection siteCollectionObject)
    {
        await this.WaitObjectAsync(await this.RemoveObjectAsync(siteCollectionObject));
    }

    public async Task<TenantOperationResult?> RestoreObjectAsync(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RestoreDeletedSitePreferId",
                requestPayload.CreateParameter(siteCollectionObject.Url),
                requestPayload.CreateParameter(siteCollectionObject.Id)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RestoreObjectAwaitAsync(TenantDeletedSiteCollection siteCollectionObject)
    {
        await this.WaitObjectAsync(await this.RestoreObjectAsync(siteCollectionObject));
    }

}
