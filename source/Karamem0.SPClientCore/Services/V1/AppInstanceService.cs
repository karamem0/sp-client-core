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

public interface IAppInstanceService
{

    Task<AppInstance?> GetObjectAsync(Guid appInstanceId, bool selectAllProperties = true);

    Task<IEnumerable<AppInstance>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<IEnumerable<AppInstance>?> GetObjectEnumerableAsync(Guid appProductId, bool selectAllProperties = true);

}

public class AppInstanceService(ClientContext clientContext) : ClientService(clientContext), IAppInstanceService
{

    public async Task<AppInstance?> GetObjectAsync(Guid appInstanceId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetAppInstanceById",
                requestPayload.CreateParameter(appInstanceId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(AppInstance)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AppInstance>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<AppInstance>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(AppCatalog),
                "GetAppInstances",
                ClientRequestParameterObjectPath.Create(objectPath2)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(AppInstance))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<AppInstance>?> GetObjectEnumerableAsync(Guid appProductId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetAppInstancesByProductId",
                requestPayload.CreateParameter(appProductId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(AppInstance))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
