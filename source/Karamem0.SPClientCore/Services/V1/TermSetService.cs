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

public interface ITermSetService
{

    Task<TermSet?> AddObjectAsync(
        TermGroup termGroupObject,
        string termSetName,
        Guid termSetId,
        uint lcid,
        bool selectAllProperties = true
    );

    Task<TermSet?> GetObjectAsync(TermSet termSetObject);

    Task<TermSet?> GetObjectAsync(TermSet termSetObject, bool selectAllProperties = true);

    Task<TermSet?> GetObjectAsync(
        TermGroup termGroupObject,
        Guid termSetId,
        bool selectAllProperties = true
    );

    Task<TermSet?> GetObjectAsync(
        TermGroup termGroupObject,
        string termSetName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<TermSet>?> GetObjectEnumerableAsync(TermGroup termGroupObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(TermSet termSetObject);

    Task SetObjectAsync(TermSet termSetObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermSetService(ClientContext clientContext) : ClientService<TermSet>(clientContext), ITermSetService
{

    public async Task<TermSet?> AddObjectAsync(
        TermGroup termGroupObject,
        string termSetName,
        Guid termSetId,
        uint lcid,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateTermSet",
                requestPayload.CreateParameter(termSetName),
                requestPayload.CreateParameter(termSetId),
                requestPayload.CreateParameter(lcid)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermSet)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermSet?> GetObjectAsync(
        TermGroup termGroupObject,
        Guid termSetId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "TermSets"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(termSetId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermSet)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermSet?> GetObjectAsync(
        TermGroup termGroupObject,
        string termSetName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "TermSets"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByName",
                requestPayload.CreateParameter(termSetName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermSet)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TermSet>?> GetObjectEnumerableAsync(TermGroup termGroupObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "TermSets"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TermSet))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermSetEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public override async Task SetObjectAsync(TermSet termSetObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termSetObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TermStore"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
