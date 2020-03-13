//
// Copyright (c) 2020 karamem0
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

    public interface IDocumentSetSharedColumnService
    {

        void AddObject(ContentType contentTypeObject, Column columnObject, bool pushChanges);

        IEnumerable<Column> GetObjectEnumerable(ContentType contentTypeObject);

        void RemoveObject(ContentType contentTypeObject, Column columnObject, bool pushChanges);

    }

    public class DocumentSetSharedColumnService : ClientService, IDocumentSetSharedColumnService
    {

        public DocumentSetSharedColumnService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void AddObject(ContentType contentTypeObject, Column columnObject, bool pushChanges)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (columnObject == null)
            {
                throw new ArgumentNullException(nameof(columnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                 new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                 new ObjectPathIdentity(columnObject.ObjectIdentity));
            var objectPath3 = requestPayload.Add(
                new ObjectPathStaticMethod(
                    typeof(DocumentSetTemplate),
                    "GetDocumentSetTemplate",
                    new ClientRequestParameterObjectPath(objectPath1)));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SharedFields"));
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Add",
                    new ClientRequestParameterObjectPath(objectPath2)));
            var objectPath6 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Update",
                    requestPayload.CreateParameter(pushChanges)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public IEnumerable<Column> GetObjectEnumerable(ContentType contentTypeObject)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                 new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathStaticMethod(
                    typeof(DocumentSetTemplate),
                    "GetDocumentSetTemplate",
                    new ClientRequestParameterObjectPath(objectPath1)));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "SharedFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(Column))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<SharedColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void RemoveObject(ContentType contentTypeObject, Column columnObject, bool pushChanges)
        {
            if (contentTypeObject == null)
            {
                throw new ArgumentNullException(nameof(contentTypeObject));
            }
            if (columnObject == null)
            {
                throw new ArgumentNullException(nameof(columnObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                 new ObjectPathIdentity(contentTypeObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                 new ObjectPathIdentity(columnObject.ObjectIdentity));
            var objectPath3 = requestPayload.Add(
                new ObjectPathStaticMethod(
                    typeof(DocumentSetTemplate),
                    "GetDocumentSetTemplate",
                    new ClientRequestParameterObjectPath(objectPath1)));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SharedFields"));
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Remove",
                    new ClientRequestParameterObjectPath(objectPath2)));
            var objectPath6 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Update",
                    requestPayload.CreateParameter(pushChanges)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
