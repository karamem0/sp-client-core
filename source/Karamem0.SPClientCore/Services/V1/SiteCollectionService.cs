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

    Task<SiteCollection?> GetObjectAsync(bool selectAllProperties = true);

    Task<SiteCollection?> GetObjectAsync(SiteCollection siteCollectionObject);

    Task<SiteCollection?> GetObjectAsync(SiteCollection siteCollectionObject, bool selectAllProperties = true);

    Task<SiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true);

}

public class SiteCollectionService(ClientContext clientContext) : ClientService<SiteCollection>(clientContext), ISiteCollectionService
{

    public async Task<SiteCollection?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Site"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(SiteCollection)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<SiteCollection?> GetObjectAsync(Uri siteCollectionUrl, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SiteCollection>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
