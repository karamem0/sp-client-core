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

public interface ITermGroupService
{

    Task<TermGroup?> AddObjectAsync(
        string termGroupName,
        Guid termGroupId,
        bool selectAllProperties = true
    );

    Task<TermGroup?> GetObjectAsync(TermGroup termGroupObject);

    Task<TermGroup?> GetObjectAsync(TermGroup termGroupObject, bool selectAllProperties = true);

    Task<TermGroup?> GetObjectAsync(Guid termGroupId, bool selectAllProperties = true);

    Task<TermGroup?> GetObjectAsync(string termGroupName, bool selectAllProperties = true);

    Task<IEnumerable<TermGroup>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(TermGroup termGroupObject);

    Task SetObjectAsync(TermGroup termGroupObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermGroupService(ClientContext clientContext) : ClientService<TermGroup>(clientContext), ITermGroupService
{

    public async Task<TermGroup?> AddObjectAsync(
        string termGroupName,
        Guid termGroupId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "CreateGroup",
                requestPayload.CreateParameter(termGroupName),
                requestPayload.CreateParameter(termGroupId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermGroup)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermGroup?> GetObjectAsync(Guid termGroupId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Groups"), ClientActionInstantiateObjectPath.Create);
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(termGroupId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermGroup)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermGroup?> GetObjectAsync(string termGroupName, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Groups"), ClientActionInstantiateObjectPath.Create);
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(termGroupName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermGroup)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TermGroup>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Groups"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TermGroup))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermGroupEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public override async Task SetObjectAsync(TermGroup termGroupObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termGroupObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TermStore"), ClientActionInstantiateObjectPath.Create);
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
