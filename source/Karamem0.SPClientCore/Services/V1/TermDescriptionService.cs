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

public interface ITermDescriptionService
{

    Task<string?> GetObjectAsync(Term termObject, uint lcid);

    Task SetObjectAsync(
        Term termObject,
        string description,
        uint lcid
    );

}

public class TermDescriptionService(ClientContext clientContext) : ClientService(clientContext), ITermDescriptionService
{

    public async Task<string?> GetObjectAsync(Term termObject, uint lcid)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetDescription",
                requestPayload.CreateParameter(lcid)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task SetObjectAsync(
        Term termObject,
        string description,
        uint lcid
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetDescription",
                requestPayload.CreateParameter(description),
                requestPayload.CreateParameter(lcid)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
