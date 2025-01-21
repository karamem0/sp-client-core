//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public abstract class ClientService<T>(ClientContext clientContext) : ClientService(clientContext) where T : ClientObject
{

    public virtual T GetObject(T clientObject)
    {
        _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(clientObject.ObjectIdentity),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(T))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<T>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public virtual void RemoveObject(T clientObject)
    {
        _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(clientObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(objectPathId, "DeleteObject"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public virtual void SetObject(T clientObject, IReadOnlyDictionary<string, object> modificationInfo)
    {
        _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
        _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectName = clientObject.ObjectType;
        var objectType = ClientObject.GetType(objectName);
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(clientObject.ObjectIdentity),
            requestPayload.CreateSetPropertyDelegates(clientObject, modificationInfo).ToArray());
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
