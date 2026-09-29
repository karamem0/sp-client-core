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

public interface INavigationNodeService
{

    Task<NavigationNode?> AddObjectAsync(
        NavigationNode navigationNodeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task<NavigationNode?> AddObjectToQuickLaunchAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task<NavigationNode?> AddObjectToTopNavigationBarAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    Task<NavigationNode?> GetObjectAsync(NavigationNode navigationNodeObject);

    Task<NavigationNode?> GetObjectAsync(NavigationNode navigationNodeObject, bool selectAllProperties = true);

    Task<NavigationNode?> GetObjectAsync(int navigationNodeId, bool selectAllProperties = true);

    Task<IEnumerable<NavigationNode>?> GetObjectEnumerableAsync(NavigationNode navigationNodeObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(NavigationNode navigationNodeObject);

    Task SetObjectAsync(NavigationNode navigationNodeObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class NavigationNodeService(ClientContext clientContext) : ClientService<NavigationNode>(clientContext), INavigationNodeService
{

    public async Task<NavigationNode?> AddObjectAsync(
        NavigationNode navigationNodeObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(navigationNodeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Children"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<NavigationNodeCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(NavigationNode)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<NavigationNode?> AddObjectToQuickLaunchAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Navigation"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "QuickLaunch"));
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<NavigationNodeCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(NavigationNode)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<NavigationNode?> AddObjectToTopNavigationBarAsync(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Navigation"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TopNavigationBar"));
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<NavigationNodeCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(NavigationNode)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<NavigationNode?> GetObjectAsync(int navigationNodeId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Navigation"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetNodeById",
                requestPayload.CreateParameter(navigationNodeId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(NavigationNode)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<NavigationNode>?> GetObjectEnumerableAsync(NavigationNode navigationNodeObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(navigationNodeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Children"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(NavigationNode))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<NavigationNodeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
