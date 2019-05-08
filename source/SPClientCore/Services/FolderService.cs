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

    public interface IFolderService
    {

        void ApproveObject(Folder folderObject, string comment);

        Folder CreateObject(Folder folderObject, string folderName);

        void DenyObject(Folder folderObject, string comment);

        Folder GetObject(Folder folderObject);

        Folder GetObject(List listObject);

        Folder GetObject(Guid folderId);

        Folder GetObject(Uri folderUrl);

        Folder GetObject(Folder folderObject, string folderName);

        IEnumerable<Folder> GetObjectEnumerable(Folder folderObject);

        Guid RecycleObject(Folder folderObject);

        void RemoveObject(Folder folderObject);

        void SuspendObject(Folder folderObject, string comment);

        void UpdateObject(Folder folderObject, IReadOnlyDictionary<string, object> modificationInformation);

    }

    public class FolderService : ClientService<Folder>, IFolderService
    {

        public FolderService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void ApproveObject(Folder folderObject, string comment)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationStatus"),
                    requestPayload.CreateParameter(ModerationStatusType.Approved)),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationComments"),
                    requestPayload.CreateParameter(comment)),
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public Folder CreateObject(Folder folderObject, string folderName)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            if (folderName == null)
            {
                throw new ArgumentNullException(nameof(folderName));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Folders"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "Add",
                    requestPayload.CreateParameter(folderName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Folder>(requestPayload.ActionQueryId);
        }

        public void DenyObject(Folder folderObject, string comment)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationStatus"),
                    requestPayload.CreateParameter(ModerationStatusType.Denied)),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationComments"),
                    requestPayload.CreateParameter(comment)),
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public Folder GetObject(List listObject)
        {
            if (listObject == null)
            {
                throw new ArgumentNullException(nameof(listObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "RootFolder"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Folder>(requestPayload.ActionQueryId);
        }

        public Folder GetObject(Guid folderId)
        {
            if (folderId == default(Guid))
            {
                throw new ArgumentNullException(nameof(folderId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetFolderById",
                    requestPayload.CreateParameter(folderId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Folder>(requestPayload.ActionQueryId);
        }

        public Folder GetObject(Uri folderUrl)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetFolderByServerRelativeUrl",
                    requestPayload.CreateParameter(folderUrl.ToString())),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Folder>(requestPayload.ActionQueryId);
        }

        public Folder GetObject(Folder folderObject, string folderName)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            if (folderName == null)
            {
                throw new ArgumentNullException(nameof(folderName));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Folders"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByUrl",
                    requestPayload.CreateParameter(folderName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Folder>(requestPayload.ActionQueryId);
        }

        public IEnumerable<Folder> GetObjectEnumerable(Folder folderObject)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Folders"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(Folder))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<FolderEnumerable>(requestPayload.ActionQueryId);
        }

        public Guid RecycleObject(Folder folderObject)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "Recycle"));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Guid>(requestPayload.ActionMethodId);
        }

        public void SuspendObject(Folder folderObject, string comment)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationStatus"),
                    requestPayload.CreateParameter(ModerationStatusType.Pending)),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("_ModerationComments"),
                    requestPayload.CreateParameter(comment)),
                objectPathId => new ClientActionMethod(objectPathId, "Update"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}