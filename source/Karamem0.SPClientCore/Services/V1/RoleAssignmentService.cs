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

public interface IRoleAssignmentService
{

    void BreakObjectInheritance(
        SecurableObject securableObject,
        bool copyRoleAssignments,
        bool clearSubscopes
    );

    RoleAssignment? AddObject(
        SecurableObject securableObject,
        Principal principalObject,
        RoleDefinition roleDefinitionObject,
        bool selectAllProperties = true
    );

    IEnumerable<RoleAssignment>? GetObjectEnumerable(SecurableObject securableObject, bool selectAllProperties = true);

    RoleAssignment? GetObject(RoleAssignment roleAssignmentObject);

    RoleAssignment? GetObject(RoleAssignment roleAssignmentObject, bool selectAllProperties = true);

    RoleAssignment? GetObject(
        SecurableObject securableObject,
        int principalId,
        bool selectAllProperties = true
    );

    void RemoveObject(RoleAssignment roleAssignmentObject);

    void ResetObjectInheritance(SecurableObject securableObject);

}

public class RoleAssignmentService(ClientContext clientContext) : ClientService<RoleAssignment>(clientContext), IRoleAssignmentService
{

    public void BreakObjectInheritance(
        SecurableObject securableObject,
        bool copyRoleAssignments,
        bool clearSubscopes
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(securableObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "BreakRoleInheritance",
                requestPayload.CreateParameter(copyRoleAssignments),
                requestPayload.CreateParameter(clearSubscopes)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public RoleAssignment? AddObject(
        SecurableObject securableObject,
        Principal principalObject,
        RoleDefinition roleDefinitionObject,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathConstructor.Create(typeof(RoleDefinitionBindingEnumerable)),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(roleDefinitionObject)
            )
        );
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(securableObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RoleAssignments"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(principalObject),
                ClientRequestParameterObjectPath.Create(objectPath1)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(RoleAssignment)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleAssignment>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<RoleAssignment>? GetObjectEnumerable(SecurableObject securableObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(securableObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "RoleAssignments"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(RoleAssignment))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleAssignmentEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleAssignment? GetObject(
        SecurableObject securableObject,
        int principalId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(securableObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "RoleAssignments"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByPrincipalId",
                requestPayload.CreateParameter(principalId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(RoleAssignment)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RoleAssignment>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void ResetObjectInheritance(SecurableObject securableObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(securableObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "ResetRoleInheritance")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
