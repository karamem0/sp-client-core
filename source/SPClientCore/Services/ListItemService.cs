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

    public interface IListItemService
    {

        void ApproveObject(ListItem listItemObject, string comment);

        ListItem CreateObject(List listObject, IReadOnlyDictionary<string, object> creationInformation);

        void DenyObject(ListItem listItemObject, string comment);

        ListItem GetObject(ListItem listItemObject);

        ListItem GetObject(Folder folderObject);

        ListItem GetObject(File fileObject);

        ListItem GetObject(List listObject, int listItemId);

        IEnumerable<ListItem> GetObjectEnumerable(List listObject, IReadOnlyDictionary<string, object> filterInformation);

        Guid RecycleObject(ListItem listItemObject);

        void RemoveObject(ListItem listItemObject);

        void SuspendObject(ListItem listItemObject, string comment);

        void UpdateObject(ListItem listItemObject, IReadOnlyDictionary<string, object> modificationInformation, bool useSyetemUpdate);

    }

    public class ListItemService : ClientService<ListItem>, IListItemService
    {

        public ListItemService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void ApproveObject(ListItem listItemObject, string comment)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
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

        public ListItem CreateObject(List listObject, IReadOnlyDictionary<string, object> creationInformation)
        {
            if (listObject == null)
            {
                throw new ArgumentNullException(nameof(listObject));
            }
            if (creationInformation == null)
            {
                throw new ArgumentNullException(nameof(creationInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var delegates = new List<ClientActionDelegate>();
            delegates.Add(objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            delegates.AddRange(creationInformation.Select(parameter =>
                new ClientActionDelegate(objectPathId =>
                    new ClientActionMethod(objectPathId, "SetFieldValue",
                    requestPayload.CreateParameter(parameter.Key),
                    requestPayload.CreateParameter(parameter.Value)))));
            delegates.Add(objectPathId => new ClientActionMethod(objectPathId, "Update"));
            delegates.Add(objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(ListItem))
            });
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "AddItem",
                    requestPayload.CreateParameter(new ListItemCreationInformation())));
            var objectPath3 = requestPayload.Add(objectPath2, delegates.ToArray());
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.ActionQueryId);
        }

        public void DenyObject(ListItem listItemObject, string comment)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
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

        public ListItem GetObject(Folder folderObject)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ListItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.ActionQueryId);
        }

        public ListItem GetObject(File fileObject)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ListItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.ActionQueryId);
        }

        public ListItem GetObject(List listObject, int listItemId)
        {
            if (listObject == null)
            {
                throw new ArgumentNullException(nameof(listObject));
            }
            if (listItemId == default(int))
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetItemById",
                    requestPayload.CreateParameter(listItemId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ListItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.ActionQueryId);
        }

        public IEnumerable<ListItem> GetObjectEnumerable(List listObject, IReadOnlyDictionary<string, object> filterInformation)
        {
            if (listObject == null)
            {
                throw new ArgumentNullException(nameof(listObject));
            }
            if (filterInformation == null)
            {
                throw new ArgumentNullException(nameof(filterInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetItems",
                    requestPayload.CreateParameter(new CamlQuery(filterInformation))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(ListItemEnumerable)),
                    ChildItemQuery = new ClientQuery(true, typeof(ListItem))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItemEnumerable>(requestPayload.ActionQueryId);
        }

        public Guid RecycleObject(ListItem listItemObject)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "Recycle"));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Guid>(requestPayload.ActionMethodId);
        }

        public void SuspendObject(ListItem listItemObject, string comment)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
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

        public void UpdateObject(ListItem listItemObject, IReadOnlyDictionary<string, object> modificationInformation, bool useSyetemUpdate)
        {
            if (listItemObject == null)
            {
                throw new ArgumentNullException(nameof(listItemObject));
            }
            if (modificationInformation == null)
            {
                throw new ArgumentNullException(nameof(modificationInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
                modificationInformation.Select(parameter =>
                        new ClientActionDelegate(objectPathId =>
                            new ClientActionMethod(objectPathId, "SetFieldValue",
                            requestPayload.CreateParameter(parameter.Key),
                            requestPayload.CreateParameter(parameter.Value))))
                    .Append(objectPathId => new ClientActionMethod(
                        objectPathId,
                        useSyetemUpdate ? "SystemUpdate" : "Update"))
                    .Where(item => item != null)
                    .ToArray());
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
