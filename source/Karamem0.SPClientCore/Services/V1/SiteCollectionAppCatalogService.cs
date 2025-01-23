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

public interface ISiteCollectionAppCatalogService
{

    void AddObject(Uri siteCollectionUrl);

    SiteCollectionAppCatalog GetObject(SiteCollectionAppCatalog siteCollectionAppCatalogObject);

    IEnumerable<SiteCollectionAppCatalog> GetObjectEnumerable();

    void RemoveObject(Uri siteCollectionUrl);

    void RemoveObject(Guid? siteCollectionId);

}

public class SiteCollectionAppCatalogService(ClientContext clientContext)
    : ClientService<SiteCollectionAppCatalog>(clientContext), ISiteCollectionAppCatalogService
{

    public void AddObject(Uri siteCollectionUrl)
    {
        _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current")
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "TenantAppCatalog")
        );
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "SiteCollectionAppCatalogsSites")
        );
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<SiteCollectionAppCatalog> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current")
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "TenantAppCatalog")
        );
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "SiteCollectionAppCatalogsSites"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(SiteCollectionAppCatalog))
            }
        );
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<SiteCollectionAppCatalogEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Uri siteCollectionUrl)
    {
        _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current")
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "TenantAppCatalog")
        );
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "SiteCollectionAppCatalogsSites")
        );
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(Guid? siteCollectionId)
    {
        _ = siteCollectionId ?? throw new ArgumentNullException(nameof(siteCollectionId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current")
        );
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web")
        );
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "TenantAppCatalog")
        );
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "SiteCollectionAppCatalogsSites")
        );
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "RemoveById",
                requestPayload.CreateParameter(siteCollectionId)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
