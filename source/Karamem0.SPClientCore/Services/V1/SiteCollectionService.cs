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

public interface ISiteCollectionService
{

    SiteCollection? GetObject(bool selectAllProperties = true);

    SiteCollection? GetObject(SiteCollection siteCollectionObject);

    SiteCollection? GetObject(SiteCollection siteCollectionObject, bool selectAllProperties = true);

    SiteCollection? GetObject(Uri siteCollectionUrl, bool selectAllProperties = true);

}

public class SiteCollectionService(ClientContext clientContext) : ClientService<SiteCollection>(clientContext), ISiteCollectionService
{

    public SiteCollection? GetObject(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Site"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(SiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public SiteCollection? GetObject(Uri siteCollectionUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(false)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(SiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
