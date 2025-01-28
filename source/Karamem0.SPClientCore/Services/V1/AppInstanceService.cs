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

public interface IAppInstanceService
{

    AppInstance GetObject(Guid? appInstanceId);

    IEnumerable<AppInstance> GetObjectEnumerable();

    IEnumerable<AppInstance> GetObjectEnumerable(Guid? appProductId);

}

public class AppInstanceService(ClientContext clientContext) : ClientService(clientContext), IAppInstanceService
{

    public AppInstance GetObject(Guid? appInstanceId)
    {
        _ = appInstanceId ?? throw new ArgumentNullException(nameof(appInstanceId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(objectPath2.Id, "GetAppInstanceById", requestPayload.CreateParameter(appInstanceId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(AppInstance))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstance>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<AppInstance> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(AppCatalog),
                "GetAppInstances",
                new ClientRequestParameterObjectPath(objectPath2)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(AppInstance))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<AppInstance> GetObjectEnumerable(Guid? appProductId)
    {
        _ = appProductId ?? throw new ArgumentNullException(nameof(appProductId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "GetAppInstancesByProductId",
                requestPayload.CreateParameter(appProductId)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(AppInstance))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<AppInstanceEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
