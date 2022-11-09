//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITenantDeletedPersonalSiteCollectionService
    {

        IEnumerable<TenantDeletedSiteCollection> GetObjectEnumerable();

        IEnumerable<TenantDeletedSiteCollection> GetObjectEnumerable(Uri siteCollectionUrl);

    }

    public class TenantDeletedPersonalSiteCollectionService : ClientService, ITenantDeletedPersonalSiteCollectionService
    {

        public TenantDeletedPersonalSiteCollectionService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<TenantDeletedSiteCollection> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetAllDeletedPersonalSitesPropertiesAllVersions",
                    requestPayload.CreateParameter(null)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TenantDeletedSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<TenantDeletedSiteCollection> GetObjectEnumerable(Uri siteCollectionUrl)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetDeletedPersonalSitePropertiesAllVersions",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString())),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantDeletedSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantDeletedSiteCollectionsEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

    }

}
