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

public interface ISiteCollectionService
{

    SiteCollection? GetObject();

    SiteCollection? GetObject(SiteCollection siteCollectionObject);

    SiteCollection? GetObject(Uri siteCollectionUrl);

}

public class SiteCollectionService(ClientContext clientContext) : ClientService<SiteCollection>(clientContext), ISiteCollectionService
{

    public SiteCollection? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Site"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(SiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public SiteCollection? GetObject(Uri siteCollectionUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(SiteCollection)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
