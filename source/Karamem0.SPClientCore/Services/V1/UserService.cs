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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IUserService
{

    User? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    User? EnsureObject(string userLoginName);

    User? GetObject();

    User? GetObject(User userObject);

    User? GetObject(int userId);

    User? GetObject(string userName);

    IEnumerable<User>? GetObjectEnumerable();

    void RemoveObject(User userObject);

    void SetObject(User userObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class UserService(ClientContext clientContext) : ClientService<User>(clientContext), IUserService
{

    public User? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteUsers"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<UserCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? EnsureObject(string userLoginName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "EnsureUser",
                requestPayload.CreateParameter(userLoginName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "CurrentUser"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(int userId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteUsers"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
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

    public User? GetObject(string userName)
    {
        if (Regex.IsMatch(userName, "^[ci]:0"))
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteUsers"));
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath3.Id,
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
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteUsers"));
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath3.Id,
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

    public IEnumerable<User>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "SiteUsers"),
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

}
