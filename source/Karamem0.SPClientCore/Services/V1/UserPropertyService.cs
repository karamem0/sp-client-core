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

public interface IUserPropertyService
{

    UserProperty? GetObject();

    UserProperty? GetObject(UserProperty userPropertyObject);

    UserProperty? GetObject(string userLoginName);

}

public class UserPropertyService(ClientContext clientContext) : ClientService<UserProperty>(clientContext), IUserPropertyService
{

    public UserProperty? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(PeopleManager)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetMyProperties"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(UserProperty)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserProperty>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public UserProperty? GetObject(string userLoginName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(PeopleManager)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetPropertiesFor",
                requestPayload.CreateParameter(userLoginName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(UserProperty)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserProperty>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
