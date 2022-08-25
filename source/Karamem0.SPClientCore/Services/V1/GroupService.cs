//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface IGroupService
    {

        Group AddObject(IReadOnlyDictionary<string, object> creationInfo);

        Group GetObject(Group groupObject);

        Group GetObject(int? groupId);

        Group GetObject(string groupName);

        IEnumerable<Group> GetObjectEnumerable();

        void RemoveObject(Group groupObject);

        void SetObject(Group groupObject, IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class GroupService : ClientService<Group>, IGroupService
    {

        public GroupService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Group AddObject(IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SiteGroups"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "Add",
                    requestPayload.CreateParameter(new GroupCreationInfo(creationInfo))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Group))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public Group GetObject(int? groupId)
        {
            _ = groupId ?? throw new ArgumentNullException(nameof(groupId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SiteGroups"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(groupId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Group))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public Group GetObject(string groupName)
        {
            _ = groupName ?? throw new ArgumentNullException(nameof(groupName));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SiteGroups"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetByName",
                    requestPayload.CreateParameter(groupName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Group))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<Group> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SiteGroups"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(Group))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<GroupEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public override void RemoveObject(Group groupObject)
        {
            _ = groupObject ?? throw new ArgumentNullException(nameof(groupObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SiteGroups"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Remove",
                    requestPayload.CreateParameter(groupObject)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
