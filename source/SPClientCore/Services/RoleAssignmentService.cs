//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IRoleAssignmentService
    {

        RoleAssignment CreateObject(SecurableObject securableObject, Principal principalObject, RoleDefinition roleDefinitionObject);

        IEnumerable<RoleAssignment> GetObjectEnumerable(SecurableObject securableObject);

        RoleAssignment GetObject(RoleAssignment roleAssignmentObject);

        RoleAssignment GetObject(SecurableObject securableObject, int principalId);

        void RemoveObject(RoleAssignment roleAssignmentObject);

        void SetUniqueDisabled(SecurableObject securableObject);

        void SetUniqueEnabled(SecurableObject securableObject, bool copyRoleAssignments, bool clearSubscopes);

    }

    public class RoleAssignmentService : ClientService<RoleAssignment>, IRoleAssignmentService
    {

        public RoleAssignmentService(ClientContext clientContext) : base(clientContext)
        {
        }

        public RoleAssignment CreateObject(SecurableObject securableObject, Principal principalObject, RoleDefinition roleDefinitionObject)
        {
            if (securableObject == null)
            {
                throw new ArgumentNullException(nameof(securableObject));
            }
            if (principalObject == null)
            {
                throw new ArgumentNullException(nameof(principalObject));
            }
            if (roleDefinitionObject == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(RoleDefinitionBindingEnumerable)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Add",
                    requestPayload.CreateParameter(roleDefinitionObject)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathIdentity(securableObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RoleAssignments"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "Add",
                    requestPayload.CreateParameter(principalObject),
                    new ClientRequestParameterObjectPath(objectPath1)),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(RoleAssignment))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<RoleAssignment>(requestPayload.ActionQueryId);
        }

        public IEnumerable<RoleAssignment> GetObjectEnumerable(SecurableObject securableObject)
        {
            if (securableObject == null)
            {
                throw new ArgumentNullException(nameof(securableObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(securableObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
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
                .ToObject<RoleAssignmentEnumerable>(requestPayload.ActionQueryId);
        }

        public RoleAssignment GetObject(SecurableObject securableObject, int principalId)
        {
            if (securableObject == null)
            {
                throw new ArgumentNullException(nameof(securableObject));
            }
            if (principalId == default(int))
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(securableObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "RoleAssignments"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
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
                .ToObject<RoleAssignment>(requestPayload.ActionQueryId);
        }

        public void SetUniqueDisabled(SecurableObject securableObject)
        {
            if (securableObject == null)
            {
                throw new ArgumentNullException(nameof(securableObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(securableObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "ResetRoleInheritance"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void SetUniqueEnabled(SecurableObject securableObject, bool copyRoleAssignments, bool clearSubscopes)
        {
            if (securableObject == null)
            {
                throw new ArgumentNullException(nameof(securableObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(securableObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "BreakRoleInheritance",
                    requestPayload.CreateParameter(copyRoleAssignments),
                    requestPayload.CreateParameter(clearSubscopes)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
