//
// Copyright (c) 2018-2024 karamem0
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

public interface ITenantPersonalSiteService
{

    TenantOperationResult AddObject(IReadOnlyCollection<string> userId);

    void AddObjectAwait(IReadOnlyCollection<string> userId);

    string GetObject(string userId);

}

public class TenantPersonalSiteService(ClientContext clientContext) : TenantClientService(clientContext), ITenantPersonalSiteService
{
    public TenantOperationResult AddObject(IReadOnlyCollection<string> userId)
    {
        _ = userId ?? throw new ArgumentNullException(nameof(userId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "RequestPersonalSites",
                requestPayload.CreateParameter(userId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(TenantOperationResult))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void AddObjectAwait(IReadOnlyCollection<string> userId)
    {
        this.WaitObject(this.AddObject(userId));
    }

    public string GetObject(string userId)
    {
        _ = userId ?? throw new ArgumentNullException(nameof(userId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "GetPersonalSiteUrl",
                requestPayload.CreateParameter(userId)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
