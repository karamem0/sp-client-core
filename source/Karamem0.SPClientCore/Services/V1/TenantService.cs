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

public interface ITenantService
{

    Tenant GetObject();

    void SetObject(IReadOnlyDictionary<string, object> modificationInfo);

}

public class TenantService(ClientContext clientContext) : ClientService(clientContext), ITenantService
{

    public Tenant GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(Tenant))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Tenant>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(IReadOnlyDictionary<string, object> modificationInfo)
    {
        _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)),
            requestPayload
                .CreateSetPropertyDelegates(typeof(Tenant), modificationInfo)
                .ToArray()
        );
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => new ClientActionMethod(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
