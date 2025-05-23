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

    RecycleBinItem GetObject(RecycleBinItem recycleBinItemObject);

    RecycleBinItem GetObject(Guid? itemId, RecycleBinItemState recycleBinItemState);

    IEnumerable<RecycleBinItem> GetObjectEnumerable(RecycleBinItemState recycleBinItemState);

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

    public RecycleBinItem GetObject(Guid? itemId, RecycleBinItemState recycleBinItemState)
    {
        _ = itemId ?? throw new ArgumentNullException(nameof(itemId));
        if (recycleBinItemState == RecycleBinItemState.FirstStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(itemId)
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(RecycleBinItem))
                }
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>());
        }
        if (recycleBinItemState == RecycleBinItemState.SecondStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Site"));
            var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(itemId)
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(RecycleBinItem))
                }
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>());
        }
        throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
    }

    public IEnumerable<RecycleBinItem> GetObjectEnumerable(RecycleBinItemState recycleBinItemState)
    {
        if (recycleBinItemState == RecycleBinItemState.FirstStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(RecycleBinItem))
                }
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<RecycleBinItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }
        if (recycleBinItemState == RecycleBinItemState.SecondStageRecycleBin)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Site"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(RecycleBinItem))
                }
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
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => new ClientActionMethod(objectPathId, "MoveAllToSecondStage"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void MoveObjectToSecondStage(RecycleBinItem recycleBinItemObject)
    {
        _ = recycleBinItemObject ?? throw new ArgumentNullException(nameof(recycleBinItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(recycleBinItemObject.ObjectIdentity), objectPathId => new ClientActionMethod(objectPathId, "MoveToSecondStage"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveAllObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => new ClientActionMethod(objectPathId, "DeleteAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveAllSecondStageObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => new ClientActionMethod(objectPathId, "DeleteAllSecondStageItems"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreAllObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => new ClientActionMethod(objectPathId, "RestoreAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreObject(RecycleBinItem recycleBinItemObject)
    {
        _ = recycleBinItemObject ?? throw new ArgumentNullException(nameof(recycleBinItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(recycleBinItemObject.ObjectIdentity), objectPathId => new ClientActionMethod(objectPathId, "Restore"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
