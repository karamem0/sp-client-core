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

    Task<ListItem?> AddObjectAsync(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task<IEnumerable<ListItem?>?> AddObjectEnumerableAsync(
        List listObject,
        IEnumerable<IReadOnlyDictionary<string, object?>> creationInfos,
        bool selectAllProperties = true
    );

    Task<ListItem?> GetObjectAsync(ListItem listItemObject);

    Task<ListItem?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true);

    Task<ListItem?> GetObjectAsync(Models.V1.Folder folderObject, bool selectAllProperties = true);

    Task<ListItem?> GetObjectAsync(Models.V1.File fileObject, bool selectAllProperties = true);

    Task<ListItem?> GetObjectAsync(DriveItem driveItemObject, bool selectAllProperties = true);

    Task<ListItem?> GetObjectAsync(
        List listObject,
        int listItemId,
        bool selectAllProperties = true
    );

    Task<ListItem?> GetObjectAsync(
        List listObject,
        Guid listItemUniqueId,
        bool selectAllProperties = true
    );

    Task<ListItem?> GetObjectAsync(Uri listItemUrl, bool selectAllProperties = true);

    Task<IEnumerable<ListItem>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true);

    Task<IEnumerable<ListItem>?> GetObjectEnumerableAsync(
        List listObject,
        IReadOnlyDictionary<string, object?> filterInfo,
        bool selectAllProperties = true
    );

    Task<Guid> RecycleObjectAsync(ListItem listItemObject);

    Task RemoveObjectAsync(ListItem listItemObject);

    Task SetObjectAsync(
        ListItem listItemObject,
        IReadOnlyDictionary<string, object?> modificationInfo,
        bool useSyetemUpdate
    );

}

public class ListItemService(ClientContext clientContext) : ClientService<ListItem>(clientContext), IListItemService
{

    public async Task<ListItem?> AddObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<ListItem?>?> AddObjectEnumerableAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObjectEnumerable<ListItem>(requestPayload.GetActionIds<ClientActionQuery>()));
    }

    public override async Task<ListItem?> GetObjectAsync(ListItem listItemObject) => await this.GetObjectAsync(listItemObject, true);

    public override async Task<ListItem?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(Models.V1.Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(Models.V1.File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListItem)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(DriveItem driveItemObject, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ListItem?> GetObjectAsync(Uri listItemUrl, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItem>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<ListItem>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true)
    {
        var listItems = new List<ListItem>();
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
            var listItemEnumerable = await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
            _ = listItemEnumerable ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            foreach (var listItem in listItemEnumerable)
            {
                listItems.Add(listItem);
            }
            listItemCollectionPosition = listItemEnumerable.ListItemCollectionPosition;
        } while (listItemCollectionPosition is not null);
        return listItems;
    }

    public async Task<IEnumerable<ListItem>?> GetObjectEnumerableAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListItemEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Guid> RecycleObjectAsync(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task SetObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
