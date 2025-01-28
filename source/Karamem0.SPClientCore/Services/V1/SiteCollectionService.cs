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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteCollectionService
{

    SiteCollection GetObject();

    SiteCollection GetObject(SiteCollection siteCollectionObject);

    SiteCollection GetObject(Uri siteCollectionUrl);

}

public class SiteCollectionService(ClientContext clientContext)
    : ClientService<SiteCollection>(clientContext), ISiteCollectionService
{

    public SiteCollection GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Site"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(SiteCollection))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public SiteCollection GetObject(Uri siteCollectionUrl)
    {
        _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(false)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(SiteCollection))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
