//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface IListItemService
    {

        ListItem AddObject(List listObject, IReadOnlyDictionary<string, object> creationInformation);

        IEnumerable<ListItem> AddObjectEnumerable(List listObject, IReadOnlyCollection<IReadOnlyDictionary<string, object>> creationInformations);

        void ApproveObject(ListItem listItemObject, string comment);

        void DenyObject(ListItem listItemObject, string comment);

        ListItem GetObject(ListItem listItemObject);

        ListItem GetObject(Models.V1.Folder folderObject);

        ListItem GetObject(Models.V1.File fileObject);

        ListItem GetObject(DriveItem driveItemObject);

        ListItem GetObject(List listObject, int? listItemId);

        ListItem GetObject(string listItemUrl);

        IEnumerable<ListItem> GetObjectEnumerable(List listObject);

        IEnumerable<ListItem> GetObjectEnumerable(List listObject, IReadOnlyDictionary<string, object> filterInformation);

        Guid RecycleObject(ListItem listItemObject);

        void RemoveObject(ListItem listItemObject);

        void SetObject(ListItem listItemObject, IReadOnlyDictionary<string, object> modificationInformation, bool useSyetemUpdate);

        void SuspendObject(ListItem listItemObject, string comment);

    }

    public class ListItemService : ClientService<ListItem>, IListItemService
    {

        public ListItemService(ClientContext clientContext) : base(clientContext)
        {
        }

        public ListItem AddObject(List listObject, IReadOnlyDictionary<string, object> creationInformation)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = creationInformation ?? throw new ArgumentNullException(nameof(creationInformation));
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
                Query = new ClientQuery(true)
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
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<ListItem> AddObjectEnumerable(List listObject, IReadOnlyCollection<IReadOnlyDictionary<string, object>> creationInformations)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = creationInformations ?? throw new ArgumentNullException(nameof(creationInformations));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listObject.ObjectIdentity));
            foreach (var creationInformation in creationInformations)
            {
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
                    Query = new ClientQuery(true)
                });
                var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath1.Id,
                        "AddItem",
                        requestPayload.CreateParameter(new ListItemCreationInformation())));
                var objectPath3 = requestPayload.Add(objectPath2, delegates.ToArray());
            }
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObjectEnumerable<ListItem>(requestPayload.GetActionIds<ClientActionQuery>());
        }

        public void ApproveObject(ListItem listItemObject, string comment)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
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
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public void DenyObject(ListItem listItemObject, string comment)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
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
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public override ListItem GetObject(ListItem listItemObject)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public ListItem GetObject(Models.V1.Folder folderObject)
        {
            _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public ListItem GetObject(Models.V1.File fileObject)
        {
            _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public ListItem GetObject(DriveItem driveItemObject)
        {
            _ = driveItemObject ?? throw new ArgumentNullException(nameof(driveItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Lists"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath3.Id,
                    "GetById",
                    requestPayload.CreateParameter(new Guid(driveItemObject.SharePointIds.ListId))));
            var objectPath5 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath4.Id,
                    "GetItemById",
                    requestPayload.CreateParameter(int.Parse(driveItemObject.SharePointIds.ListItemId))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public ListItem GetObject(List listObject, int? listItemId)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = listItemId ?? throw new ArgumentNullException(nameof(listItemId));
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
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public ListItem GetObject(string listItemUrl)
        {
            _ = listItemUrl ?? throw new ArgumentNullException(nameof(listItemUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetListItem",
                    requestPayload.CreateParameter(listItemUrl)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<ListItem> GetObjectEnumerable(List listObject)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            var listItemCollectionPosition = default(ListItemCollectionPosition);
            do
            {
                var requestPayload = new ClientRequestPayload();
                var objectPath1 = requestPayload.Add(
                    new ObjectPathIdentity(listObject.ObjectIdentity));
                var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath1.Id,
                        "GetItems",
                        requestPayload.CreateParameter(new CamlQuery(new Dictionary<string, object>()
                        {
                            { "ViewXml", "<View Scope=\"Recursive\"><RowLimit Paged=\"TRUE\">5000</RowLimit></View>" },
                            { "ListItemCollectionPosition", listItemCollectionPosition }
                        }))),
                    objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                    objectPathId => new ClientActionQuery(objectPathId)
                    {
                        Query = new ClientQuery(true, typeof(ListItemEnumerable)),
                        ChildItemQuery = new ClientQuery(true)
                    });
                var listItemEnumerable = this.ClientContext
                    .ProcessQuery(requestPayload)
                    .ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
                foreach (var listItem in listItemEnumerable)
                {
                    yield return listItem;
                }
                listItemCollectionPosition = listItemEnumerable.ListItemCollectionPosition;
            }
            while (listItemCollectionPosition != null);
        }

        public IEnumerable<ListItem> GetObjectEnumerable(List listObject, IReadOnlyDictionary<string, object> filterInformation)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = filterInformation ?? throw new ArgumentNullException(nameof(filterInformation));
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
                    ChildItemQuery = new ClientQuery(true)
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public Guid RecycleObject(ListItem listItemObject)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "Recycle"));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
        }

        public void SetObject(ListItem listItemObject, IReadOnlyDictionary<string, object> modificationInformation, bool useSyetemUpdate)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            _ = modificationInformation ?? throw new ArgumentNullException(nameof(modificationInformation));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(listItemObject.ObjectIdentity),
                modificationInformation.Select(parameter =>
                    new ClientActionDelegate(objectPathId =>
                        new ClientActionMethod(
                            objectPathId,
                            "SetFieldValue",
                            requestPayload.CreateParameter(parameter.Key),
                            requestPayload.CreateParameter(parameter.Value))))
                    .Append(objectPathId => new ClientActionMethod(
                        objectPathId,
                        useSyetemUpdate ? "SystemUpdate" : "Update"))
                    .Where(item => item != null)
                    .ToArray());
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public void SuspendObject(ListItem listItemObject, string comment)
        {
            _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
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
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
