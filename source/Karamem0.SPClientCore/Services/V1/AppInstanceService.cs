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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IAppInstanceService
{

    AppInstance? GetObject(Guid appInstanceId);

    IEnumerable<AppInstance>? GetObjectEnumerable();

    IEnumerable<AppInstance>? GetObjectEnumerable(Guid appProductId);

}

public class AppInstanceService(ClientContext clientContext) : ClientService(clientContext), IAppInstanceService
{

    public AppInstance? GetObject(Guid appInstanceId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(AppInstance)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstance>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<AppInstance>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(AppInstance))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<AppInstance>? GetObjectEnumerable(Guid appProductId)
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
                ClientQuery.Create(true, typeof(AppInstance))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
