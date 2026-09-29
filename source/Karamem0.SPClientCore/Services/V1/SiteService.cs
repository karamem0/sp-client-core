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

public interface ISiteService
{

    Task<Site?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(Site siteObject);

    Task<Site?> GetObjectAsync(Site siteObject, bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(SiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(List listObject, bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(Guid siteId, bool selectAllProperties = true);

    Task<Site?> GetObjectAsync(Uri siteUrl, bool selectAllProperties = true);

    Task<IEnumerable<Site>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(Site siteObject);

    Task SelectObjectAsync(Site siteObject);

    Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAsync(Site siteObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SiteService(ClientContext clientContext) : ClientService<Site>(clientContext), ISiteService
{

    public async Task<Site?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"), ClientActionInstantiateObjectPath.Create);
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Webs"), ClientActionInstantiateObjectPath.Create);
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<SiteCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Site?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Web"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Site?> GetObjectAsync(SiteCollection siteCollectionObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "OpenWeb",
                requestPayload.CreateParameter(siteCollectionObject.ServerRelativeUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Site?> GetObjectAsync(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentWeb"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Site?> GetObjectAsync(Guid siteId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "OpenWebById",
                requestPayload.CreateParameter(siteId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Site?> GetObjectAsync(Uri siteUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "OpenWeb",
                requestPayload.CreateParameter(siteUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Site>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Webs"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Site))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SiteEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SelectObjectAsync(Site siteObject)
    {
        this.ClientContext.BaseAddress = siteObject.Url ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
    }

    public async Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Web"),
            requestPayload.CreateSetPropertyDelegates(typeof(Site), modificationInfo)
        );
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
