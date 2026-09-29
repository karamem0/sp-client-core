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

public interface ITermService
{

    Task<Term?> CopyObjectAsync(
        Term termObject,
        bool copyChildren,
        bool selectAllProperties = true
    );

    Task<Term?> AddObjectAsync(
        TermSetItem termSetItemObject,
        string termName,
        Guid termId,
        uint lcid,
        bool selectAllProperties = true
    );

    Task DeprecateObjectAsync(Term termObject, bool deprecated);

    Task<Term?> GetObjectAsync(Term termObject);

    Task<Term?> GetObjectAsync(Term termObject, bool selectAllProperties = true);

    Task<Term?> GetObjectAsync(TermLabel termLabelObject, bool selectAllProperties = true);

    Task<Term?> GetObjectAsync(
        TermSetItem termSetItemObject,
        Guid termId,
        bool selectAllProperties = true
    );

    Task<Term?> GetObjectAsync(
        TermSetItem termSetItemObject,
        string termName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<Term>?> GetObjectEnumerableAsync(TermSetItem termSetItemObject, bool selectAllProperties = true);

    Task MergeObjectAsync(Term sourceTermObject, TermSetItem destinationTermObject);

    Task MoveObjectAsync(Term termObject, TermSetItem termSetItemObject);

    Task RemoveObjectAsync(Term termObject);

    Task SetObjectAsync(Term termObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermService(ClientContext clientContext) : ClientService<Term>(clientContext), ITermService
{

    public async Task<Term?> CopyObjectAsync(
        Term termObject,
        bool copyChildren,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "Copy",
                requestPayload.CreateParameter(copyChildren)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Term)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Term>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Term?> AddObjectAsync(
        TermSetItem termSetItemObject,
        string termName,
        Guid termId,
        uint lcid,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateTerm",
                requestPayload.CreateParameter(termName),
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(termId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Term)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Term>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task DeprecateObjectAsync(Term termObject, bool deprecated)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Deprecate",
                requestPayload.CreateParameter(deprecated)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<Term?> GetObjectAsync(TermLabel termLabelObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Term"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Term)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Term>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Term?> GetObjectAsync(
        TermSetItem termSetItemObject,
        Guid termId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Terms"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(termId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Term)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Term>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Term?> GetObjectAsync(
        TermSetItem termSetItemObject,
        string termName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Terms"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByName",
                requestPayload.CreateParameter(termName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermSetItem)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Term>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Term>?> GetObjectEnumerableAsync(TermSetItem termSetItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Terms"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Term))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task MergeObjectAsync(Term sourceTermObject, TermSetItem destinationTermObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(sourceTermObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Merge",
                requestPayload.CreateParameter(destinationTermObject)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task MoveObjectAsync(Term termObject, TermSetItem termSetItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Move",
                requestPayload.CreateParameter(termSetItemObject)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public override async Task SetObjectAsync(Term termObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TermStore"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
