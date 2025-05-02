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

public interface ITermStoreService
{

    TermStore? GetObject();

    void SetObject(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermStoreService(ClientContext clientContext) : ClientService(clientContext), ITermStoreService
{

    public TermStore? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermStore)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermStore>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath3 = requestPayload.Add(objectPath2, requestPayload.CreateSetPropertyDelegates(typeof(TermStore), modificationInfo));
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
