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

    SiteCollectionAppCatalog? GetObject(SiteCollectionAppCatalog siteCollectionAppCatalogObject);

    IEnumerable<SiteCollectionAppCatalog>? GetObjectEnumerable();

    void RemoveObject(Uri siteCollectionUrl);

    void RemoveObject(Guid siteCollectionId);

}

public class SiteCollectionAppCatalogService(ClientContext clientContext)
    : ClientService<SiteCollectionAppCatalog>(clientContext), ISiteCollectionAppCatalogService
{

    public void AddObject(Uri siteCollectionUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TenantAppCatalog"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteCollectionAppCatalogsSites"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<SiteCollectionAppCatalog>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TenantAppCatalog"));
        var objectPath4 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath3.Id, "SiteCollectionAppCatalogsSites"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(SiteCollectionAppCatalog))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteCollectionAppCatalogEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Uri siteCollectionUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TenantAppCatalog"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteCollectionAppCatalogsSites"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(Guid siteCollectionId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TenantAppCatalog"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteCollectionAppCatalogsSites"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveById",
                requestPayload.CreateParameter(siteCollectionId)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
