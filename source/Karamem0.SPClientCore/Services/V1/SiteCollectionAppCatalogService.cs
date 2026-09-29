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

public interface ISiteCollectionAppCatalogService
{

    Task AddObjectAsync(Uri siteCollectionUrl);

    Task<SiteCollectionAppCatalog?> GetObjectAsync(SiteCollectionAppCatalog siteCollectionAppCatalogObject);

    Task<SiteCollectionAppCatalog?> GetObjectAsync(SiteCollectionAppCatalog siteCollectionAppCatalogObject, bool selectAllProperties = true);

    Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(Guid? siteCollectionId, bool selectAllProperties = true);

    Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(Uri? siteCollectionUrl = null, bool selectAllProperties = true);

    Task RemoveObjectAsync(Uri siteCollectionUrl);

    Task RemoveObjectAsync(Guid siteCollectionId);

}

public class SiteCollectionAppCatalogService(ClientContext clientContext)
    : ClientService<SiteCollectionAppCatalog>(clientContext), ISiteCollectionAppCatalogService
{

    public async Task AddObjectAsync(Uri siteCollectionUrl)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
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
                ClientQuery.Create(selectAllProperties, typeof(SiteCollectionAppCatalog))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SiteCollectionAppCatalogEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(Guid? siteCollectionId, bool selectAllProperties = true)
    {
        return await this
            .GetObjectEnumerableAsync(selectAllProperties)
            .ContinueWith(task => task.Result.Where(item => item.SiteCollectionId == siteCollectionId))
            .ContinueWith(task => task.Result.ToArray());
    }

    public async Task<IEnumerable<SiteCollectionAppCatalog>?> GetObjectEnumerableAsync(Uri? siteCollectionUrl, bool selectAllProperties = true)
    {
        return await this
            .GetObjectEnumerableAsync(selectAllProperties)
            .ContinueWith(task => task.Result.Where(item => item.AbsoluteUrl == siteCollectionUrl))
            .ContinueWith(task => task.Result.ToArray());
    }

    public async Task RemoveObjectAsync(Uri siteCollectionUrl)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveObjectAsync(Guid siteCollectionId)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
