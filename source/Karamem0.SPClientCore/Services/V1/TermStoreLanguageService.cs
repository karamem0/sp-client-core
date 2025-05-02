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

public interface ITermStoreLanguageService
{

    void AddObject(uint lcid);

    void RemoveObject(uint lcid);

}

public class TermStoreLanguageService(ClientContext clientContext) : ClientService(clientContext), ITermStoreLanguageService
{

    public void AddObject(uint lcid)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "AddLanguage",
                requestPayload.CreateParameter(lcid)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(uint lcid)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticMethod.Create(typeof(TaxonomySession), "GetTaxonomySession"));
        var objectPath2 = requestPayload.Add(ObjectPathMethod.Create(objectPath1.Id, "GetDefaultSiteCollectionTermStore"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteLanguage",
                requestPayload.CreateParameter(lcid)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
