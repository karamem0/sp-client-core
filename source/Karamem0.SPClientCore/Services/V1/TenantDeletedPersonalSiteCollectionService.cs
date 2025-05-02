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

public interface ITenantDeletedPersonalSiteCollectionService
{

    IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable();

    IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable(Uri siteCollectionUrl);

}

public class TenantDeletedPersonalSiteCollectionService(ClientContext clientContext) : ClientService(clientContext), ITenantDeletedPersonalSiteCollectionService
{

    public IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetAllDeletedPersonalSitesPropertiesAllVersions",
                requestPayload.CreateParameter(null)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TenantDeletedSiteCollection))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TenantDeletedSiteCollection>? GetObjectEnumerable(Uri siteCollectionUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetDeletedPersonalSitePropertiesAllVersions",
                requestPayload.CreateParameter(siteCollectionUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TenantDeletedSiteCollection))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
