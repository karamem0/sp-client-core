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

public interface IGroupOwnerService
{

    Principal? GetObject(Group groupObject);

    void SetObject(Group groupObject, Principal principalObject);

}

public class GroupOwnerService(ClientContext clientContext) : ClientService(clientContext), IGroupOwnerService
{

    public Principal? GetObject(Group groupObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Owner"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(false, typeof(Principal)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Principal>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(Group groupObject, Principal principalObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "Owner",
                ClientRequestParameterObjectPath.Create(requestPayload.Add(ObjectPathIdentity.Create(principalObject.ObjectIdentity)))
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
