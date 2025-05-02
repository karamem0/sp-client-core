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

public interface IGroupMemberService
{

    User? AddObject(Group groupObject, User memberObject);

    User? GetObject(Group groupObject, int userId);

    User? GetObject(Group groupObject, string userName);

    IEnumerable<User>? GetObjectEnumerable(Group groupObject);

    void RemoveObject(Group groupObject, User memberObject);

}

public class GroupMemberService(ClientContext clientContext) : ClientService(clientContext), IGroupMemberService
{

    public User? AddObject(Group groupObject, User memberObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "AddUser",
                requestPayload.CreateParameter(memberObject)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(Group groupObject, int userId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(userId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(Group groupObject, string userName)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(userName, "^[ci]:0"))
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Users"));
            var objectPath3 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath2.Id,
                    "GetByLoginName",
                    requestPayload.CreateParameter(userName)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
        else
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Users"));
            var objectPath3 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath2.Id,
                    "GetByEmail",
                    requestPayload.CreateParameter(userName)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

    public IEnumerable<User>? GetObjectEnumerable(Group groupObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Users"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(User))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Group groupObject, User memberObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(memberObject)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
