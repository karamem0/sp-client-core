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

    TermGroup AddObject(string termGroupName, Guid? termGroupId);

    TermGroup GetObject(TermGroup termGroupObject);

    TermGroup GetObject(Guid? termGroupId);

    TermGroup GetObject(string termGroupName);

    IEnumerable<TermGroup> GetObjectEnumerable();

    void RemoveObject(TermGroup termGroupObject);

    void SetObject(TermGroup termGroupObject, IReadOnlyDictionary<string, object> modificationInfo);

}

public class TermGroupService(ClientContext clientContext) : ClientService<TermGroup>(clientContext), ITermGroupService
{

    public TermGroup AddObject(string termGroupName, Guid? termGroupId)
    {
        _ = termGroupName ?? throw new ArgumentNullException(nameof(termGroupName));
        _ = termGroupId ?? throw new ArgumentNullException(nameof(termGroupId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "CreateGroup",
                requestPayload.CreateParameter(termGroupName),
                requestPayload.CreateParameter(termGroupId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(TermGroup))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermGroup GetObject(Guid? termGroupId)
    {
        _ = termGroupId ?? throw new ArgumentNullException(nameof(termGroupId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "Groups"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(termGroupId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(TermGroup))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermGroup GetObject(string termGroupName)
    {
        _ = termGroupName ?? throw new ArgumentNullException(nameof(termGroupName));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "Groups"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(termGroupName)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(TermGroup))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TermGroup>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TermGroup> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "Groups"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(TermGroup))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TermGroupEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void SetObject(TermGroup termGroupObject, IReadOnlyDictionary<string, object> modificationInfo)
    {
        _ = termGroupObject ?? throw new ArgumentNullException(nameof(termGroupObject));
        _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(termGroupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            requestPayload.CreateSetPropertyDelegates(termGroupObject, modificationInfo).ToArray());
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "TermStore"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => new ClientActionMethod(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
