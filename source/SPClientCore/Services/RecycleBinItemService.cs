//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IRecycleBinItemService
    {

        RecycleBinItem GetObject(RecycleBinItem recycleBinItemObject);

        RecycleBinItem GetObject(Guid itemId);

        IEnumerable<RecycleBinItem> GetObjectEnumerable();

        void RemoveObject(RecycleBinItem recycleBinItemObject);

        void RemoveObjectAll();

        void RestoreObject(RecycleBinItem recycleBinItemObject);

        void RestoreObjectAll();

    }

    public class RecycleBinItemService : ClientService<RecycleBinItem>, IRecycleBinItemService
    {

        public RecycleBinItemService(ClientContext clientContext) : base(clientContext)
        {
        }

        public RecycleBinItem GetObject(Guid itemId)
        {
            if (itemId == default(Guid))
            {
                throw new ArgumentNullException(nameof(itemId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(itemId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(RecycleBinItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<RecycleBinItem>(requestPayload.ActionQueryId);
        }

        public IEnumerable<RecycleBinItem> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(RecycleBinItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<RecycleBinItemEnumerable>(requestPayload.ActionQueryId);
        }

        public void RemoveObjectAll()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(objectPathId, "DeleteAll"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RestoreObject(RecycleBinItem recycleBinItemObject)
        {
            if (recycleBinItemObject == null)
            {
                throw new ArgumentNullException(nameof(recycleBinItemObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(recycleBinItemObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "Restore"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RestoreObjectAll()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RecycleBin"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(objectPathId, "RestoreAll"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
