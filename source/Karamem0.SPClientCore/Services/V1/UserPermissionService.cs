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

public interface IUserPermissionService
{

    BasePermission? GetObject(User userObject, SecurableObject securableObject);

}

public class UserPermissionService(ClientContext clientContext) : ClientService(clientContext), IUserPermissionService
{

    public BasePermission? GetObject(User userObject, SecurableObject securableObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(securableObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPath => ClientActionMethod.Create(
                objectPath1.Id,
                "GetUserEffectivePermissions",
                requestPayload.CreateParameter(userObject.LoginName)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<BasePermission>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
