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

public interface ITermStoreService
{

    Task<TermStore?> GetObjectAsync(bool selectAllProperties = true);

    Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermStoreService(ClientContext clientContext) : ClientService(clientContext), ITermStoreService
{

    public async Task<TermStore?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermStore)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermStore>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath3 = requestPayload.Add(objectPath2, requestPayload.CreateSetPropertyDelegates(typeof(TermStore), modificationInfo));
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
