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

public interface ITermGroupService
{

    TermGroup? AddObject(string termGroupName, Guid termGroupId);

    TermGroup? GetObject(TermGroup termGroupObject);

    TermGroup? GetObject(Guid termGroupId);

    TermGroup? GetObject(string termGroupName);

    IEnumerable<TermGroup>? GetObjectEnumerable();

    void RemoveObject(TermGroup termGroupObject);

    void SetObject(TermGroup termGroupObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermGroupService(ClientContext clientContext) : ClientService<TermGroup>(clientContext), ITermGroupService
{

    public TermGroup? AddObject(string termGroupName, Guid termGroupId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermGroup)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermGroup? GetObject(Guid termGroupId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermGroup)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermGroup? GetObject(string termGroupName)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermGroup)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TermGroup>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(TermGroup))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermGroupEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void SetObject(TermGroup termGroupObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termGroupObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "TermStore"), ClientActionInstantiateObjectPath.Create);
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
