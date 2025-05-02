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

public interface IGroupService
{

    Group? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    Group? GetObject(Group groupObject);

    Group? GetObject(int groupId);

    Group? GetObject(string groupName);

    IEnumerable<Group>? GetObjectEnumerable();

    void RemoveObject(Group groupObject);

    void SetObject(Group groupObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class GroupService(ClientContext clientContext) : ClientService<Group>(clientContext), IGroupService
{

    public Group? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteGroups"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<GroupCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Group)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Group? GetObject(int groupId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteGroups"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(groupId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Group)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Group? GetObject(string groupName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "SiteGroups"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(groupName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Group)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Group>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Group>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "SiteGroups"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Group))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<GroupEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void RemoveObject(Group groupObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "SiteGroups"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter(groupObject)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
