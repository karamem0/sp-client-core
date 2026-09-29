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

public interface IHighlightService
{

    Task<HighlightResult?> AddObjectAsync(
        View viewObject,
        int itemId,
        string folderPath,
        int afterItemId,
        bool selectAllProperties = true
    );

    Task<HighlightResult?> RemoveObjectAsync(
        View viewObject,
        int itemId,
        string folderPath,
        bool selectAllProperties = true
    );

}

public class HighlightService(ClientContext clientContext) : ClientService(clientContext), IHighlightService
{

    public async Task<HighlightResult?> AddObjectAsync(
        View viewObject,
        int itemId,
        string folderPath,
        int afterItemId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "AddToSpotlight",
                requestPayload.CreateParameter(itemId),
                requestPayload.CreateParameter(folderPath),
                requestPayload.CreateParameter(afterItemId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HighlightResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<HighlightResult?> RemoveObjectAsync(
        View viewObject,
        int itemId,
        string folderPath,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(viewObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "RemoveFromSpotlight",
                requestPayload.CreateParameter(itemId),
                requestPayload.CreateParameter(folderPath)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<HighlightResult>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
