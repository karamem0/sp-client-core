//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public abstract class ClientService<T>(ClientContext clientContext) : ClientService(clientContext) where T : ClientObject
{

    public virtual T? GetObject(T clientObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(clientObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(T)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<T>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public virtual void RemoveObject(T clientObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(clientObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public virtual void SetObject(T clientObject, IReadOnlyDictionary<string, object?> modificationInfo)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
