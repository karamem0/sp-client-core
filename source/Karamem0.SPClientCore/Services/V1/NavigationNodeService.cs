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

public interface INavigationNodeService
{

    NavigationNode? AddObject(NavigationNode navigationNodeObject, IReadOnlyDictionary<string, object?> creationInfo);

    NavigationNode? AddObjectToQuickLaunch(IReadOnlyDictionary<string, object?> creationInfo);

    NavigationNode? AddObjectToTopNavigationBar(IReadOnlyDictionary<string, object?> creationInfo);

    NavigationNode? GetObject(NavigationNode navigationNodeObject);

    NavigationNode? GetObject(int navigationNodeId);

    IEnumerable<NavigationNode>? GetObjectEnumerable(NavigationNode navigationNodeObject);

    void RemoveObject(NavigationNode navigationNodeObject);

    void SetObject(NavigationNode navigationNodeObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class NavigationNodeService(ClientContext clientContext) : ClientService<NavigationNode>(clientContext), INavigationNodeService
{

    public NavigationNode? AddObject(NavigationNode navigationNodeObject, IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(NavigationNode)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public NavigationNode? AddObjectToQuickLaunch(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(NavigationNode)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public NavigationNode? AddObjectToTopNavigationBar(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(NavigationNode)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public NavigationNode? GetObject(int navigationNodeId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(NavigationNode)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<NavigationNode>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<NavigationNode>? GetObjectEnumerable(NavigationNode navigationNodeObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(navigationNodeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Children"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(NavigationNode))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<NavigationNodeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
