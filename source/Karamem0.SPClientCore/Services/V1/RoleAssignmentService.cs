//
// Copyright (c) 2018-2024 karamem0
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

public interface IRoleAssignmentService
{

    void BreakObjectInheritance(SecurableObject securableObject, bool copyRoleAssignments, bool clearSubscopes);

    RoleAssignment AddObject(SecurableObject securableObject, Principal principalObject, RoleDefinition roleDefinitionObject);

    IEnumerable<RoleAssignment> GetObjectEnumerable(SecurableObject securableObject);

    RoleAssignment GetObject(RoleAssignment roleAssignmentObject);

    RoleAssignment GetObject(SecurableObject securableObject, int? principalId);

    void RemoveObject(RoleAssignment roleAssignmentObject);

    void ResetObjectInheritance(SecurableObject securableObject);

}

public class RoleAssignmentService(ClientContext clientContext) : ClientService<RoleAssignment>(clientContext), IRoleAssignmentService
{
    public void BreakObjectInheritance(SecurableObject securableObject, bool copyRoleAssignments, bool clearSubscopes)
    {
        _ = securableObject ?? throw new ArgumentNullException(nameof(securableObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(securableObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "BreakRoleInheritance",
                requestPayload.CreateParameter(copyRoleAssignments),
                requestPayload.CreateParameter(clearSubscopes)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public RoleAssignment AddObject(SecurableObject securableObject, Principal principalObject, RoleDefinition roleDefinitionObject)
    {
        _ = securableObject ?? throw new ArgumentNullException(nameof(securableObject));
        _ = principalObject ?? throw new ArgumentNullException(nameof(principalObject));
        _ = roleDefinitionObject ?? throw new ArgumentNullException(nameof(roleDefinitionObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(RoleDefinitionBindingEnumerable)),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Add",
                requestPayload.CreateParameter(roleDefinitionObject)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathIdentity(securableObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RoleAssignments"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(principalObject),
                new ClientRequestParameterObjectPath(objectPath1)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RoleAssignment))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<RoleAssignment>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<RoleAssignment> GetObjectEnumerable(SecurableObject securableObject)
    {
        _ = securableObject ?? throw new ArgumentNullException(nameof(securableObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(securableObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "RoleAssignments"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(RoleAssignment))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<RoleAssignmentEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public RoleAssignment GetObject(SecurableObject securableObject, int? principalId)
    {
        _ = securableObject ?? throw new ArgumentNullException(nameof(securableObject));
        _ = principalId ?? throw new ArgumentNullException(nameof(principalId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(securableObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "RoleAssignments"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "GetByPrincipalId",
                requestPayload.CreateParameter(principalId)),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RoleAssignment))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<RoleAssignment>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void ResetObjectInheritance(SecurableObject securableObject)
    {
        _ = securableObject ?? throw new ArgumentNullException(nameof(securableObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(securableObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "ResetRoleInheritance"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
