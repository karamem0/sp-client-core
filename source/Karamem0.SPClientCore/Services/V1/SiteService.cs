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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteService
{

    Site? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    Site? GetObject();

    Site? GetObject(Site siteObject);

    Site? GetObject(SiteCollection siteCollectionObject);

    Site? GetObject(List listObject);

    Site? GetObject(Guid siteId);

    Site? GetObject(Uri siteUrl);

    IEnumerable<Site>? GetObjectEnumerable();

    void RemoveObject(Site siteObject);

    void SelectObject(Site siteObject);

    void SetObject(Site siteObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SiteService(ClientContext clientContext) : ClientService<Site>(clientContext), ISiteService
{

    public Site? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Web"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(SiteCollection siteCollectionObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentWeb"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(Guid siteId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Site? GetObject(Uri siteUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Site)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Site>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Site>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(Site))
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

}
