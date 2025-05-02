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

public interface ITenantListDesignService
{

    TenantListDesign? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    TenantListDesign? GetObject(Guid listDesignId);

    IEnumerable<TenantListDesign>? GetObjectEnumerable();

    void RemoveObject(TenantListDesign listDesignObject);

}

public class TenantListDesignService(ClientContext clientContext) : ClientService(clientContext), ITenantListDesignService
{

    public TenantListDesign? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateListDesign",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantListDesignCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantListDesign)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantListDesign>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantListDesign? GetObject(Guid listDesignId)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Tenant),
                "GetListDesign",
                requestPayload.CreateParameter(listDesignId)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantListDesign>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<TenantListDesign>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetListDesigns"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TenantListDesign))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantListDesignEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(TenantListDesign listDesignObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveListDesign",
                requestPayload.CreateParameter(listDesignObject.Id)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
