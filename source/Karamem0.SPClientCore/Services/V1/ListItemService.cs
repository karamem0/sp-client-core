//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IListItemService
{

    ListItem? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    IEnumerable<ListItem?>? AddObjectEnumerable(
        List listObject,
        IEnumerable<IReadOnlyDictionary<string, object?>> creationInfos,
        bool selectAllProperties = true
    );

    ListItem? GetObject(ListItem listItemObject);

    ListItem? GetObject(ListItem listItemObject, bool selectAllProperties = true);

    ListItem? GetObject(Models.V1.Folder folderObject, bool selectAllProperties = true);

    ListItem? GetObject(Models.V1.File fileObject, bool selectAllProperties = true);

    ListItem? GetObject(DriveItem driveItemObject, bool selectAllProperties = true);

    ListItem? GetObject(
        List listObject,
        int listItemId,
        bool selectAllProperties = true
    );

    ListItem? GetObject(
        List listObject,
        Guid listItemUniqueId,
        bool selectAllProperties = true
    );

    ListItem? GetObject(Uri listItemUrl, bool selectAllProperties = true);

    IEnumerable<ListItem>? GetObjectEnumerable(List listObject, bool selectAllProperties = true);

    IEnumerable<ListItem>? GetObjectEnumerable(
        List listObject,
        IReadOnlyDictionary<string, object?> filterInfo,
        bool selectAllProperties = true
    );

    Guid RecycleObject(ListItem listItemObject);

    void RemoveObject(ListItem listItemObject);

    void SetObject(
        ListItem listItemObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool useSyetemUpdate
    );

}

public class ListItemService(ClientContext clientContext) : ClientService<ListItem>(clientContext), IListItemService
{

    public ListItem? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var delegates = new List<ClientActionDelegate>
        {
            ClientActionInstantiateObjectPath.Create
        };
        delegates.AddRange(
            creationInfo.Select(parameter => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                        objectPathId,
                        "SetFieldValue",
                        requestPayload.CreateParameter(parameter.Key),
                        requestPayload.CreateParameter(parameter.Value)
                    )
                )
            )
        );
        delegates.Add(objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        delegates.Add(objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties)));
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "AddItem",
                requestPayload.CreateParameter(new ListItemCreationInfo())
            )
        );
        var objectPath3 = requestPayload.Add(objectPath2, delegates);
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ListItem?>? AddObjectEnumerable(
        List listObject,
        IEnumerable<IReadOnlyDictionary<string, object?>> creationInfos,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        foreach (var creationInfo in creationInfos)
        {
            var delegates = new List<ClientActionDelegate>
            {
                ClientActionInstantiateObjectPath.Create
            };
            delegates.AddRange(
                creationInfo.Select(parameter => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                            objectPathId,
                            "SetFieldValue",
                            requestPayload.CreateParameter(parameter.Key),
                            requestPayload.CreateParameter(parameter.Value)
                        )
                    )
                )
            );
            delegates.Add(objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
            delegates.Add(objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties)));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "AddItem",
                    requestPayload.CreateParameter(new ListItemCreationInfo())
                )
            );
            var objectPath3 = requestPayload.Add(objectPath2, delegates);
        }
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObjectEnumerable<ListItem>(requestPayload.GetActionIds<ClientActionQuery>());
    }

    public override ListItem? GetObject(ListItem listItemObject) => this.GetObject(listItemObject, true);

    public override ListItem? GetObject(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(Models.V1.Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(Models.V1.File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(DriveItem driveItemObject, bool selectAllProperties = true)
    {
        var listId = driveItemObject.SharePointIds?.ListId;
        _ = listId ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var listItemId = driveItemObject.SharePointIds?.ListItemId;
        _ = listItemId ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(new Guid(listId))
            )
        );
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "GetItemById",
                requestPayload.CreateParameter(int.Parse(listItemId))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(
        List listObject,
        int listItemId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetItemById",
                requestPayload.CreateParameter(listItemId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(
        List listObject,
        Guid listItemUniqueId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetItemByUniqueId",
                requestPayload.CreateParameter(listItemUniqueId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ListItem? GetObject(Uri listItemUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetListItem",
                requestPayload.CreateParameter(listItemUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<ListItem>? GetObjectEnumerable(List listObject, bool selectAllProperties = true)
    {
        var listItemCollectionPosition = default(ListItemCollectionPosition);
        do
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "GetItems",
                    requestPayload.CreateParameter(
                        ClientValueObject.Create<CamlQuery>(
                            new Dictionary<string, object?>()
                            {
                                ["ViewXml"] = "<View Scope=\"Recursive\"><RowLimit Paged=\"TRUE\">5000</RowLimit></View>",
                                ["ListItemCollectionPosition"] = listItemCollectionPosition
                            }
                        )
                    )
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(
                    objectPathId,
                    ClientQuery.Create(selectAllProperties, typeof(ListItemEnumerable)),
                    ClientQuery.Create(selectAllProperties)
                )
            );
            var listItemEnumerable = this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
            _ = listItemEnumerable ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            foreach (var listItem in listItemEnumerable)
            {
                yield return listItem;
            }
            listItemCollectionPosition = listItemEnumerable.ListItemCollectionPosition;
        } while (listItemCollectionPosition is not null);
    }

    public IEnumerable<ListItem>? GetObjectEnumerable(
        List listObject,
        IReadOnlyDictionary<string, object?> filterInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetItems",
                requestPayload.CreateParameter(ClientValueObject.Create<CamlQuery>(filterInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Create(selectAllProperties, typeof(ListItemEnumerable)),
                ClientQuery.Create(selectAllProperties)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Guid RecycleObject(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public void SetObject(
        ListItem listItemObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool useSyetemUpdate
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            modificationInfo
                .Select(parameter => new ClientActionDelegate(objectPathId => ClientActionMethod.Create(
                            objectPathId,
                            "SetFieldValue",
                            requestPayload.CreateParameter(parameter.Key),
                            requestPayload.CreateParameter(parameter.Value)
                        )
                    )
                )
                .Append(objectPathId => ClientActionMethod.Create(objectPathId, useSyetemUpdate ? "SystemUpdate" : "Update"))
                .Where(item => item is not null)
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
