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

public interface IUserPropertyService
{

    Task<UserProperty?> GetObjectAsync(bool selectAllProperties = true);

    Task<UserProperty?> GetObjectAsync(UserProperty userPropertyObject);

    Task<UserProperty?> GetObjectAsync(UserProperty userPropertyObject, bool selectAllProperties = true);

    Task<UserProperty?> GetObjectAsync(string userLoginName, bool selectAllProperties = true);

}

public class UserPropertyService(ClientContext clientContext) : ClientService<UserProperty>(clientContext), IUserPropertyService
{

    public async Task<UserProperty?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(PeopleManager)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetMyProperties"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(UserProperty)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<UserProperty>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<UserProperty?> GetObjectAsync(string userLoginName, bool selectAllProperties = true)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(UserProperty)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<UserProperty>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
