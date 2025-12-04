//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantSiteCollectionService
{

    TenantOperationResult? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    void AddObjectAwait(IReadOnlyDictionary<string, object?> creationInfo);

    TenantSiteCollection? GetObject(TenantSiteCollection siteCollectionObject);

    TenantSiteCollection? GetObject(Uri siteCollectionUrl);

    TenantSiteCollection? GetObjectAwait(TenantSiteCollection siteCollectionObject);

    TenantSiteCollection? GetObjectAwait(Uri siteCollectionUrl);

    IEnumerable<TenantSiteCollection>? GetObjectEnumerable();

    IEnumerable<TenantSiteCollection>? GetObjectEnumerable(IReadOnlyDictionary<string, object?> filterInfo);

    TenantOperationResult? LockObject(TenantSiteCollection siteCollectionObject);

    void LockObjectAwait(TenantSiteCollection siteCollectionObject);

    TenantOperationResult? RemoveObject(TenantSiteCollection siteCollectionObject);

    void RemoveObjectAwait(TenantSiteCollection siteCollectionObject);

    TenantOperationResult? SetObject(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObjectAwait(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo);

    TenantOperationResult? UnlockObject(TenantSiteCollection siteCollectionObject);

    void UnlockObjectAwait(TenantSiteCollection siteCollectionObject);

}

public class TenantSiteCollectionService(ClientContext clientContext) : TenantClientService(clientContext), ITenantSiteCollectionService
{

    public TenantOperationResult? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void AddObjectAwait(IReadOnlyDictionary<string, object?> creationInfo)
    {
        this.WaitObject(this.AddObject(creationInfo));
    }

    public TenantSiteCollection? GetObject(TenantSiteCollection siteCollectionObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantSiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantSiteCollection? GetObject(Uri siteCollectionUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantSiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantSiteCollection? GetObjectAwait(TenantSiteCollection siteCollectionObject)
    {
        return this.GetObjectAwait(siteCollectionObject.Url ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull));
    }

    public TenantSiteCollection? GetObjectAwait(Uri siteCollectionUrl)
    {
        while (true)
        {
            var errorCount = 0;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTenantService));
                var siteCollectionObject = this.GetObject(siteCollectionUrl);
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

    public IEnumerable<TenantSiteCollection>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(TenantSiteCollection))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TenantSiteCollection>? GetObjectEnumerable(IReadOnlyDictionary<string, object?> filterInfo)
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
                ClientQuery.Create(true, typeof(TenantSiteCollection))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantOperationResult? LockObject(TenantSiteCollection siteCollectionObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void LockObjectAwait(TenantSiteCollection siteCollectionObject)
    {
        this.WaitObject(this.LockObject(siteCollectionObject));
    }

    public TenantOperationResult? RemoveObject(TenantSiteCollection siteCollectionObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObjectAwait(TenantSiteCollection siteCollectionObject)
    {
        this.WaitObject(this.RemoveObject(siteCollectionObject));
    }

    public TenantOperationResult? SetObject(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            requestPayload.CreateSetPropertyDelegates(siteCollectionObject, modificationInfo)
        );
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "Update"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObjectAwait(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        this.WaitObject(this.SetObject(siteCollectionObject, modificationInfo));
    }

    public TenantOperationResult? UnlockObject(TenantSiteCollection siteCollectionObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void UnlockObjectAwait(TenantSiteCollection siteCollectionObject)
    {
        this.WaitObject(this.UnlockObject(siteCollectionObject));
    }

}
