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

public interface IRoleDefinitionService
{

    RoleDefinition? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    RoleDefinition? GetObject(RoleDefinition roleDefinitionObject);

    RoleDefinition? GetObject(int roleDefinitionId);

    RoleDefinition? GetObject(string roleDefinitionName);

    IEnumerable<RoleDefinition>? GetObjectEnumerable();

    void RemoveObject(RoleDefinition roleDefinitionObject);

    void SetObject(RoleDefinition roleDefinitionObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class RoleDefinitionService(ClientContext clientContext) : ClientService<RoleDefinition>(clientContext), IRoleDefinitionService
{

    public RoleDefinition? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<RoleDefinitionCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RoleDefinition)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleDefinition? GetObject(int roleDefinitionId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(roleDefinitionId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RoleDefinition)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleDefinition? GetObject(string roleDefinitionName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RoleDefinitions"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(roleDefinitionName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RoleDefinition)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinition>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<RoleDefinition>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "RoleDefinitions"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(RoleDefinition))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleDefinitionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
