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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITermSetService
{

    TermSet? AddObject(
        TermGroup termGroupObject,
        string termSetName,
        Guid termSetId,
        uint lcid
    );

    TermSet? GetObject(TermSet termSetObject);

    TermSet? GetObject(TermGroup termGroupObject, Guid termSetId);

    TermSet? GetObject(TermGroup termGroupObject, string termSetName);

    IEnumerable<TermSet>? GetObjectEnumerable(TermGroup termGroupObject);

    void RemoveObject(TermSet termSetObject);

    void SetObject(TermSet termSetObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermSetService(ClientContext clientContext) : ClientService<TermSet>(clientContext), ITermSetService
{

    public TermSet? AddObject(
        TermGroup termGroupObject,
        string termSetName,
        Guid termSetId,
        uint lcid
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermSet)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermSet? GetObject(TermGroup termGroupObject, Guid termSetId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermSet)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermSet? GetObject(TermGroup termGroupObject, string termSetName)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermSet)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TermSet>? GetObjectEnumerable(TermGroup termGroupObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "TermSets"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TermSet))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermSetEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void SetObject(TermSet termSetObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termSetObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termSetObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TermStore"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
