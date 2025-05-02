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

public interface IRoleDefinitionService
{

    RoleDefinition AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    RoleDefinition GetObject(RoleDefinition roleDefinitionObject);

    RoleDefinition GetObject(int roleDefinitionId);

    RoleDefinition GetObject(string roleDefinitionName);

    IEnumerable<RoleDefinition> GetObjectEnumerable();

    void RemoveObject(RoleDefinition roleDefinitionObject);

    void SetObject(RoleDefinition roleDefinitionObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class RoleDefinitionService(ClientContext clientContext) : ClientService<RoleDefinition>(clientContext), IRoleDefinitionService
{

    public RoleDefinition AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<RoleDefinitionCreationInfo>(creationInfo))
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RoleDefinition))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleDefinition GetObject(int roleDefinitionId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(roleDefinitionId)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RoleDefinition))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleDefinition GetObject(string roleDefinitionName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(roleDefinitionName)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RoleDefinition))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<RoleDefinition> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RoleDefinitions"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(RoleDefinition))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinitionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
