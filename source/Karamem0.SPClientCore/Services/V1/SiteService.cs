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

    Site? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Site? GetObject(bool selectAllProperties = true);

    Site? GetObject(Site siteObject);

    Site? GetObject(Site siteObject, bool selectAllProperties = true);

    Site? GetObject(SiteCollection siteCollectionObject, bool selectAllProperties = true);

    Site? GetObject(List listObject, bool selectAllProperties = true);

    Site? GetObject(Guid siteId, bool selectAllProperties = true);

    Site? GetObject(Uri siteUrl, bool selectAllProperties = true);

    IEnumerable<Site>? GetObjectEnumerable(bool selectAllProperties = true);

    void RemoveObject(Site siteObject);

    void SelectObject(Site siteObject);

    void SetObject(IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObject(Site siteObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SiteService(ClientContext clientContext) : ClientService<Site>(clientContext), ISiteService
{

    public Site? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Web"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(SiteCollection siteCollectionObject, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentWeb"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(Guid siteId, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(Uri siteUrl, bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Site>? GetObjectEnumerable(bool selectAllProperties = true)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SelectObject(Site siteObject)
    {
        this.ClientContext.BaseAddress = siteObject.Url ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
    }

    public void SetObject(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Web"),
            requestPayload.CreateSetPropertyDelegates(typeof(Site), modificationInfo)
        );
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
