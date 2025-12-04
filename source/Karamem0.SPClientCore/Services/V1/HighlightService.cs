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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IHighlightService
{

    HighlightResult? AddObject(
        View viewObject,
        int itemId,
        string folderPath,
        int afterItemId
    );

    HighlightResult? RemoveObject(
        View viewObject,
        int itemId,
        string folderPath
    );

}

public class HighlightService(ClientContext clientContext) : ClientService(clientContext), IHighlightService
{

    public HighlightResult? AddObject(
        View viewObject,
        int itemId,
        string folderPath,
        int afterItemId
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HighlightResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public HighlightResult? RemoveObject(
        View viewObject,
        int itemId,
        string folderPath
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<HighlightResult>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
