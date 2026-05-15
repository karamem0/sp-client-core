//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IUserService
{

    User? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    User? EnsureObject(string userLoginName, bool selectAllProperties = true);

    User? GetObject(bool selectAllProperties = true);

    User? GetObject(User userObject);

    User? GetObject(User userObject, bool selectAllProperties = true);

    User? GetObject(int userId, bool selectAllProperties = true);

    User? GetObject(string userName, bool selectAllProperties = true);

    IEnumerable<User>? GetObjectEnumerable(bool selectAllProperties = true);

    void RemoveObject(User userObject);

    void SetObject(User userObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class UserService(ClientContext clientContext) : ClientService<User>(clientContext), IUserService
{

    public User? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? EnsureObject(string userLoginName, bool selectAllProperties = true)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "CurrentUser"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(int userId, bool selectAllProperties = true)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(string userName, bool selectAllProperties = true)
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

    public IEnumerable<User>? GetObjectEnumerable(bool selectAllProperties = true)
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
                ClientQuery.Create(selectAllProperties, typeof(User))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
