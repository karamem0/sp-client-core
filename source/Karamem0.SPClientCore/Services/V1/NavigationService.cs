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

public interface INavigationService
{

    Navigation? GetObject();

    void SetObject(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class NavigationService(ClientContext clientContext) : ClientService(clientContext), INavigationService
{

    public Navigation? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Navigation"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Navigation)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Navigation>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Navigation"),
            requestPayload.CreateSetPropertyDelegates(typeof(Navigation), modificationInfo)
        );
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
