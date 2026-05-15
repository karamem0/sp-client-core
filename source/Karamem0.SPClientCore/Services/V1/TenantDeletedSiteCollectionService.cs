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

    TenantDeletedSiteCollection? GetObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    TenantDeletedSiteCollection? GetObject(Uri siteCollectionUrl, bool selectAllProperties = true);

    IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable(bool selectAllProperties = true);

    TenantOperationResult? RemoveObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    void RemoveObjectAwait(TenantDeletedSiteCollection siteCollectionObject);

    TenantOperationResult? RestoreObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true);

    void RestoreObjectAwait(TenantDeletedSiteCollection siteCollectionObject);

}

public class TenantDeletedSiteCollectionService(ClientContext clientContext) : TenantClientService(clientContext), ITenantDeletedSiteCollectionService
{

    public TenantDeletedSiteCollection? GetObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(siteCollectionObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantDeletedSiteCollection)))
        );
        var clientObject = this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantDeletedSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
        var clientObjectUrl = clientObject?.Url;
        _ = clientObjectUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return this.GetObject(clientObjectUrl, selectAllProperties);
    }

    public TenantDeletedSiteCollection? GetObject(Uri siteCollectionUrl, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantDeletedSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable(bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantOperationResult? RemoveObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObjectAwait(TenantDeletedSiteCollection siteCollectionObject)
    {
        this.WaitObject(this.RemoveObject(siteCollectionObject));
    }

    public TenantOperationResult? RestoreObject(TenantDeletedSiteCollection siteCollectionObject, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RestoreObjectAwait(TenantDeletedSiteCollection siteCollectionObject)
    {
        this.WaitObject(this.RestoreObject(siteCollectionObject));
    }

}
