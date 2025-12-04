//
// Copyright (c) 2018-2025 karamem0
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

    HubSite? AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object?> creationInfo);

    HubSite? GetObject(Guid hubSiteId);

    HubSite? GetObject(Uri hubSiteUrl);

    IEnumerable<HubSite>? GetObjectEnumerable();

    void RemoveObject(HubSite hubSiteObject);

    void SetObject(HubSite hubSiteObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TenantHubSiteService(ClientContext clientContext) : ClientService<HubSite>(clientContext), ITenantHubSiteService
{

    public HubSite? AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(HubSite)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public HubSite? GetObject(Guid hubSiteId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(HubSite)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public HubSite? GetObject(Uri hubSiteUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(HubSite)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HubSite>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<HubSite>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetHubSitesProperties"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(HubSite))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HubSiteEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void RemoveObject(HubSite hubSiteObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void SetObject(HubSite hubSiteObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
