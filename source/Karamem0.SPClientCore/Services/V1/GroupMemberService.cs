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

    User AddObject(Group groupObject, User memberObject);

    User GetObject(Group groupObject, int? userId);

    User GetObject(Group groupObject, string userName);

    IEnumerable<User> GetObjectEnumerable(Group groupObject);

    void RemoveObject(Group groupObject, User memberObject);

}

public class GroupMemberService(ClientContext clientContext) : ClientService(clientContext), IGroupMemberService
{

    public User AddObject(Group groupObject, User memberObject)
    {
        _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
        _ = memberObject ?? throw new ArgumentNullException(nameof(memberObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "AddUser",
                requestPayload.CreateParameter(memberObject)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(User))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User GetObject(Group groupObject, int? userId)
    {
        _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
        _ = userId ?? throw new ArgumentNullException(nameof(userId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(userId)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(User))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User GetObject(Group groupObject, string userName)
    {
        _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
        _ = userName ?? throw new ArgumentNullException(nameof(userName));
        if (System.Text.RegularExpressions.Regex.IsMatch(userName, "^[ci]:0"))
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Users"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByLoginName",
                    requestPayload.CreateParameter(userName)
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(User))
                }
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
        else
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Users"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByEmail",
                    requestPayload.CreateParameter(userName)
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(User))
                }
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

    public IEnumerable<User> GetObjectEnumerable(Group groupObject)
    {
        _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Users"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(User))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Group groupObject, User memberObject)
    {
        _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
        _ = memberObject ?? throw new ArgumentNullException(nameof(memberObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Users"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(memberObject)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
