//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IRecycleBinItemService
{

    Task<RecycleBinItem?> GetObjectAsync(RecycleBinItem recycleBinItemObject);

    Task<RecycleBinItem?> GetObjectAsync(RecycleBinItem recycleBinItemObject, bool selectAllProperties = true);

    Task<RecycleBinItem?> GetObjectAsync(
        Guid itemId,
        RecycleBinItemState recycleBinItemState,
        bool selectAllProperties = true
    );

    Task<IEnumerable<RecycleBinItem>?> GetObjectEnumerableAsync(RecycleBinItemState recycleBinItemState, bool selectAllProperties = true);

    Task MoveAllObjectToSecondStageAsync();

    Task MoveObjectToSecondStageAsync(RecycleBinItem recycleBinItemObject);

    Task RemoveAllObjectAsync();

    Task RemoveAllSecondStageObjectAsync();

    Task RemoveObjectAsync(RecycleBinItem recycleBinItemObject);

    Task RestoreAllObjectAsync();

    Task RestoreObjectAsync(RecycleBinItem recycleBinItemObject);

}

public class RecycleBinItemService(ClientContext clientContext) : ClientService<RecycleBinItem>(clientContext), IRecycleBinItemService
{

    public async Task<RecycleBinItem?> GetObjectAsync(
        Guid itemId,
        RecycleBinItemState recycleBinItemState,
        bool selectAllProperties = true
    )
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(RecycleBinItem)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>()));
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(RecycleBinItem)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<RecycleBinItem>(requestPayload.GetActionId<ClientActionQuery>()));
        }
        throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
    }

    public async Task<IEnumerable<RecycleBinItem>?> GetObjectEnumerableAsync(RecycleBinItemState recycleBinItemState, bool selectAllProperties = true)
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
                    ClientQuery.Create(selectAllProperties, typeof(RecycleBinItem))
                )
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<RecycleBinItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
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
                    ClientQuery.Create(selectAllProperties, typeof(RecycleBinItem))
                )
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<RecycleBinItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
        }
        throw new InvalidOperationException(StringResources.ErrorValueIsInvalid);
    }

    public async Task MoveAllObjectToSecondStageAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "MoveAllToSecondStage"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task MoveObjectToSecondStageAsync(RecycleBinItem recycleBinItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(recycleBinItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "MoveToSecondStage")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveAllObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveAllSecondStageObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Site"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteAllSecondStageItems"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RestoreAllObjectAsync()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RecycleBin"));
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "RestoreAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RestoreObjectAsync(RecycleBinItem recycleBinItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(recycleBinItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Restore")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
