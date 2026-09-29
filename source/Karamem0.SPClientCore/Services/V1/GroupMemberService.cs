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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IGroupMemberService
{

    Task<User?> AddObjectAsync(
        Group groupObject,
        User memberObject,
        bool selectAllProperties = true
    );

    Task<User?> GetObjectAsync(
        Group groupObject,
        int userId,
        bool selectAllProperties = true
    );

    Task<User?> GetObjectAsync(
        Group groupObject,
        string userName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<User>?> GetObjectEnumerableAsync(Group groupObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(Group groupObject, User memberObject);

}

public class GroupMemberService(ClientContext clientContext) : ClientService(clientContext), IGroupMemberService
{

    public async Task<User?> AddObjectAsync(
        Group groupObject,
        User memberObject,
        bool selectAllProperties = true
    )
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<User?> GetObjectAsync(
        Group groupObject,
        int userId,
        bool selectAllProperties = true
    )
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<User?> GetObjectAsync(
        Group groupObject,
        string userName,
        bool selectAllProperties = true
    )
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
        }
    }

    public async Task<IEnumerable<User>?> GetObjectEnumerableAsync(Group groupObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(groupObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Users"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(User))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(Group groupObject, User memberObject)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
