//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public abstract class ClientService<T>(ClientContext clientContext) : ClientService(clientContext) where T : ClientObject
{

    public virtual async Task<T?> GetObjectAsync(T clientObject)
    {
        return await this.GetObjectAsync(clientObject, selectAllProperties: true);
    }

    public virtual async Task<T?> GetObjectAsync(T clientObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(clientObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(T)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<T>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public virtual async Task RemoveObjectAsync(T clientObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(clientObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public virtual async Task SetObjectAsync(T clientObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectName = clientObject.ObjectType;
        _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectType = ClientObject.GetType(objectName);
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(clientObject.ObjectIdentity),
            requestPayload.CreateSetPropertyDelegates(clientObject, modificationInfo)
        );
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
