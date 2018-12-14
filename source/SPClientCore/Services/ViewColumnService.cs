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

    public interface IViewColumnService
    {

        void AddObject(View viewObject, Column columnObject);

        IEnumerable<string> GetObjectEnumerable(View viewObject);

        void MoveObject(View viewObject, Column columnObject, int columnIndex);

        void RemoveObject(View viewObject, Column columnObject);

        void RemoveObjects(View viewObject);

    }

    public class ViewColumnService : ClientService, IViewColumnService
    {

        public ViewColumnService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void AddObject(View viewObject, Column columnObject)
        {
            if (viewObject == null)
            {
                throw new ArgumentNullException(nameof(viewObject));
            }
            if (columnObject == null)
            {
                throw new ArgumentNullException(nameof(columnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(new ObjectPathIdentity(viewObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ViewFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Add",
                    requestPayload.CreateParameter(columnObject.Name)));
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public IEnumerable<string> GetObjectEnumerable(View viewObject)
        {
            if (viewObject == null)
            {
                throw new ArgumentNullException(nameof(viewObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(viewObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ViewFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ViewColumnEnumerable)),
                    ChildItemQuery = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ViewColumnEnumerable>(requestPayload.ActionQueryId);
        }

        public void MoveObject(View viewObject, Column columnObject, int columnIndex)
        {
            if (viewObject == null)
            {
                throw new ArgumentNullException(nameof(viewObject));
            }
            if (columnObject == null)
            {
                throw new ArgumentNullException(nameof(columnObject));
            }
            if (columnIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(viewObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ViewFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "MoveFieldTo",
                    requestPayload.CreateParameter(columnObject.Name),
                    requestPayload.CreateParameter(columnIndex)));
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RemoveObject(View viewObject, Column columnObject)
        {
            if (viewObject == null)
            {
                throw new ArgumentNullException(nameof(viewObject));
            }
            if (columnObject == null)
            {
                throw new ArgumentNullException(nameof(columnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(viewObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ViewFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Remove",
                    requestPayload.CreateParameter(columnObject.Name)));
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RemoveObjects(View viewObject)
        {
            if (viewObject == null)
            {
                throw new ArgumentNullException(nameof(viewObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(viewObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ViewFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                objectPath2,
                objectPathId => new ClientActionMethod(objectPathId, "RemoveAll"));
            var objectPath4 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
