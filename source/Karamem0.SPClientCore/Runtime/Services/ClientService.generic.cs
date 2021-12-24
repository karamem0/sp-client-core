//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Runtime.Services
{

    public abstract class ClientService<T> : ClientService where T : ClientObject
    {

        protected ClientService(ClientContext clientContext) : base(clientContext)
        {
        }

        public virtual T GetObject(T clientObject)
        {
            _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
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
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(clientObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "DeleteObject"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public virtual void SetObject(T clientObject, IReadOnlyDictionary<string, object> modificationInformation)
        {
            _ = clientObject ?? throw new ArgumentNullException(nameof(clientObject));
            _ = modificationInformation ?? throw new ArgumentNullException(nameof(modificationInformation));
            var requestPayload = new ClientRequestPayload();
            var objectName = clientObject.ObjectType;
            var objectType = ClientObject.GetType(objectName);
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(clientObject.ObjectIdentity),
                requestPayload.CreateSetPropertyDelegates(clientObject, modificationInformation).ToArray());
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
