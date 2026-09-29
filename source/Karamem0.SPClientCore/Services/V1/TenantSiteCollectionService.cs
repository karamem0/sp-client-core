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

public interface ITenantSiteCollectionService
{

    Task<TenantOperationResult?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task AddObjectAwaitAsync(IReadOnlyDictionary<string, object?> creationInfo);

    Task<TenantSiteCollection?> GetObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task<TenantSiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true);

    Task<TenantSiteCollection?> GetObjectAwaitAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task<TenantSiteCollection?> GetObjectAwaitAsync(Uri siteCollectionUrl, bool selectAllProperties = true);

    Task<IEnumerable<TenantSiteCollection>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<IEnumerable<TenantSiteCollection>?> GetObjectEnumerableAsync(IReadOnlyDictionary<string, object?> filterInfo, bool selectAllProperties = true);

    Task<TenantOperationResult?> LockObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task LockObjectAwaitAsync(TenantSiteCollection siteCollectionObject);

    Task<TenantOperationResult?> RemoveObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task RemoveObjectAwaitAsync(TenantSiteCollection siteCollectionObject);

    Task<TenantOperationResult?> SetObjectAsync(
        TenantSiteCollection siteCollectionObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    );

    Task SetObjectAwaitAsync(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task<TenantOperationResult?> UnlockObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task UnlockObjectAwaitAsync(TenantSiteCollection siteCollectionObject);

}

public class TenantSiteCollectionService(ClientContext clientContext) : TenantClientService(clientContext), ITenantSiteCollectionService
{

    public async Task<TenantOperationResult?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateSite",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantSiteCollectionCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task AddObjectAwaitAsync(IReadOnlyDictionary<string, object?> creationInfo)
    {
        await this.WaitObjectAsync(await this.AddObjectAsync(creationInfo));
    }

    public async Task<TenantSiteCollection?> GetObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantSiteCollection)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantSiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSitePropertiesByUrl",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(false)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantSiteCollection)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantSiteCollection?> GetObjectAwaitAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        return await this.GetObjectAwaitAsync(
            siteCollectionObject.Url ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull),
            selectAllProperties
        );
    }

    public async Task<TenantSiteCollection?> GetObjectAwaitAsync(Uri siteCollectionUrl, bool selectAllProperties = true)
    {
        while (true)
        {
            var errorCount = 0;
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTenantService));
                var siteCollectionObject = await this.GetObjectAsync(siteCollectionUrl, selectAllProperties);
                _ = siteCollectionObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
                if (siteCollectionObject.Status == "Active")
                {
                    return siteCollectionObject;
                }
            }
            catch
            {
                errorCount += 1;
                if (errorCount > ClientConstants.MaxRetryCount)
                {
                    throw;
                }
            }
        }
    }

    public async Task<IEnumerable<TenantSiteCollection>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSitePropertiesFromSharePoint",
                requestPayload.CreateParameter(null),
                requestPayload.CreateParameter(false)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantSiteCollection))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TenantSiteCollection>?> GetObjectEnumerableAsync(
        IReadOnlyDictionary<string, object?> filterInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSitePropertiesFromSharePointByFilters",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantSiteCollectionFilter>(filterInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantSiteCollection))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TenantOperationResult?> LockObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "LockState",
                requestPayload.CreateParameter("NoAccess")
            )
        );
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "Update"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task LockObjectAwaitAsync(TenantSiteCollection siteCollectionObject)
    {
        await this.WaitObjectAsync(await this.LockObjectAsync(siteCollectionObject));
    }

    public async Task<TenantOperationResult?> RemoveObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RemoveSite",
                requestPayload.CreateParameter(siteCollectionObject.Url)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAwaitAsync(TenantSiteCollection siteCollectionObject)
    {
        await this.WaitObjectAsync(await this.RemoveObjectAsync(siteCollectionObject));
    }

    public async Task<TenantOperationResult?> SetObjectAsync(
        TenantSiteCollection siteCollectionObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            requestPayload.CreateSetPropertyDelegates(siteCollectionObject, modificationInfo)
        );
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "Update"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SetObjectAwaitAsync(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        await this.WaitObjectAsync(await this.SetObjectAsync(siteCollectionObject, modificationInfo));
    }

    public async Task<TenantOperationResult?> UnlockObjectAsync(TenantSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "LockState",
                requestPayload.CreateParameter("Unlock")
            )
        );
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "Update"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task UnlockObjectAwaitAsync(TenantSiteCollection siteCollectionObject)
    {
        await this.WaitObjectAsync(await this.UnlockObjectAsync(siteCollectionObject));
    }

}
