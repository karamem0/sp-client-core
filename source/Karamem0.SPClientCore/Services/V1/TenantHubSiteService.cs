//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantHubSiteService
{

    HubSite AddObject(string siteCollectionUrl, IReadOnlyDictionary<string, object> creationInfo);

    HubSite GetObject(Guid? hubSiteId);

    HubSite GetObject(string hubSiteUrl);

    IEnumerable<HubSite> GetObjectEnumerable();

    void RemoveObject(HubSite hubSiteObject);

    void SetObject(HubSite hubSiteObject, IReadOnlyDictionary<string, object> modificationInfo);

}

public class TenantHubSiteService : ClientService<HubSite>, ITenantHubSiteService
{

    public TenantHubSiteService(ClientContext clientContext) : base(clientContext)
    {
    }

    public HubSite AddObject(string siteCollectionUrl, IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "RegisterHubSiteWithCreationInformation",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(new HubSiteCreationInfo(creationInfo))),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(HubSite))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public HubSite GetObject(Guid? hubSiteId)
    {
        _ = hubSiteId ?? throw new ArgumentNullException(nameof(hubSiteId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetHubSitePropertiesById",
                requestPayload.CreateParameter(hubSiteId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(HubSite))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public HubSite GetObject(string hubSiteUrl)
    {
        _ = hubSiteUrl ?? throw new ArgumentNullException(nameof(hubSiteUrl));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetHubSitePropertiesByUrl",
                requestPayload.CreateParameter(hubSiteUrl)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(HubSite))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<HubSite> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(objectPath1.Id, "GetHubSitesProperties"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(HubSite))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<HubSiteEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void RemoveObject(HubSite hubSiteObject)
    {
        _ = hubSiteObject ?? throw new ArgumentNullException(nameof(hubSiteObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "UnregisterHubSite",
                requestPayload.CreateParameter(hubSiteObject.SiteCollectionUrl)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void SetObject(HubSite hubSiteObject, IReadOnlyDictionary<string, object> modificationInfo)
    {
        _ = hubSiteObject ?? throw new ArgumentNullException(nameof(hubSiteObject));
        _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetHubSitePropertiesByUrl",
                requestPayload.CreateParameter(hubSiteObject.SiteCollectionUrl)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty
            });
        var objectPath3 = requestPayload.Add(
            objectPath2,
            requestPayload.CreateSetPropertyDelegates(hubSiteObject, modificationInfo).ToArray());
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => new ClientActionMethod(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
