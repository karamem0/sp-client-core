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

public interface IStorageEntityService
{

    Task AddObjectAsync(
        string key,
        string value,
        string? description,
        string? comments
    );

    Task<StorageEntity?> GetObjectAsync(string key, bool selectAllProperties = true);

    Task RemoveObjectAsync(string key);

}

public class StorageEntityService(ClientContext clientContext) : ClientService(clientContext), IStorageEntityService
{

    public async Task AddObjectAsync(
        string key,
        string value,
        string? description,
        string? comment
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"), ClientActionInstantiateObjectPath.Create);
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetStorageEntity",
                requestPayload.CreateParameter(key),
                requestPayload.CreateParameter(value),
                requestPayload.CreateParameter(description),
                requestPayload.CreateParameter(comment)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<StorageEntity?> GetObjectAsync(string key, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"), ClientActionInstantiateObjectPath.Create);
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetStorageEntity",
                requestPayload.CreateParameter(key)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(StorageEntity)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<StorageEntity>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(string key)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"), ClientActionInstantiateObjectPath.Create);
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveStorageEntity",
                requestPayload.CreateParameter(key)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
