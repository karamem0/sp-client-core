//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IRecycleBinItemService
{

    RecycleBinItem? GetObject(RecycleBinItem recycleBinItemObject);

    RecycleBinItem? GetObject(Guid itemId, RecycleBinItemState recycleBinItemState);

    IEnumerable<RecycleBinItem>? GetObjectEnumerable(RecycleBinItemState recycleBinItemState);

    void MoveAllObjectToSecondStage();

    void MoveObjectToSecondStage(RecycleBinItem recycleBinItemObject);

    void RemoveAllObject();

    void RemoveAllSecondStageObject();

    void RemoveObject(RecycleBinItem recycleBinItemObject);

    void RestoreAllObject();

    void RestoreObject(RecycleBinItem recycleBinItemObject);

}

public class RecycleBinItemService(ClientContext clientContext) : ClientService<RecycleBinItem>(clientContext), IRecycleBinItemService
{

    public RecycleBinItem? GetObject(Guid itemId, RecycleBinItemState recycleBinItemState)
    {
        if (recycleBinItemState == RecycleBinItemState.FirstStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(itemId)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RecycleBinItem)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>());
        }
        if (recycleBinItemState == RecycleBinItemState.SecondStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(itemId)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RecycleBinItem)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>());
        }
        throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
    }

    public IEnumerable<RecycleBinItem>? GetObjectEnumerable(RecycleBinItemState recycleBinItemState)
    {
        if (recycleBinItemState == RecycleBinItemState.FirstStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(
                    objectPathId,
                    ClientQuery.Empty,
                    ClientQuery.Create(true, typeof(RecycleBinItem))
                )
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }
        if (recycleBinItemState == RecycleBinItemState.SecondStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
            var objectPath3 = requestPayload.Add(
                ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(
                    objectPathId,
                    ClientQuery.Empty,
                    ClientQuery.Create(true, typeof(RecycleBinItem))
                )
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }
        throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
    }

    public void MoveAllObjectToSecondStage()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "MoveAllToSecondStage"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void MoveObjectToSecondStage(RecycleBinItem recycleBinItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(recycleBinItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "MoveToSecondStage")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveAllObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveAllSecondStageObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAllSecondStageItems"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreAllObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "RestoreAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreObject(RecycleBinItem recycleBinItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(recycleBinItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Restore")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
