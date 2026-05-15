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

public interface IListService
{

    List? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true);

    List? GetObject(List listObject);

    List? GetObject(List listObject, bool selectAllProperties = true);

    List? GetObject(ListItem listItemObject, bool selectAllProperties = true);

    List? GetObject(Models.V1.Folder folderObject, bool selectAllProperties = true);

    List? GetObject(Models.V1.File fileObject, bool selectAllProperties = true);

    List? GetObject(View viewObject, bool selectAllProperties = true);

    List? GetObject(Drive driveObject, bool selectAllProperties = true);

    List? GetObject(Guid listId, bool selectAllProperties = true);

    List? GetObject(Uri listUrl, bool selectAllProperties = true);

    List? GetObject(string listTitle, bool selectAllProperties = true);

    List? GetObject(LibraryType libraryType, bool selectAllProperties = true);

    IEnumerable<List>? GetObjectEnumerable(bool selectAllProperties = true);

    Guid RecycleObject(List listObject);

    void RemoveObject(List listObject);

    void SetObject(List listObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ListService(ClientContext clientContext) : ClientService<List>(clientContext), IListService
{

    public List? AddObject(IReadOnlyDictionary<string, object?> creationInfo, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ListCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Models.V1.Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Models.V1.File fileObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(View viewObject, bool selectAllProperties = true)
    {
        var objectIdentity = viewObject.ObjectIdentity;
        _ = objectIdentity ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(
                string.Join(
                    ":",
                    objectIdentity
                        .Split(':')
                        .SkipLast(2)
                )
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Drive driveObject, bool selectAllProperties = true)
    {
        var listId = driveObject.SharePointIds?.ListId;
        _ = listId ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(new Guid(listId))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Guid listId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetById",
                requestPayload.CreateParameter(listId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Uri listUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetList",
                requestPayload.CreateParameter(listUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(string listTitle, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByTitle",
                requestPayload.CreateParameter(listTitle)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(LibraryType libraryType, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Lists"));
        if (libraryType == LibraryType.SitePages)
        {
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(objectPath3.Id, "EnsureSitePagesLibrary"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
            );
        }
        if (libraryType == LibraryType.ClientRenderedSitePages)
        {
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(objectPath3.Id, "EnsureClientRenderedSitePagesLibrary"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
            );
        }
        if (libraryType == LibraryType.SiteAssets)
        {
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(objectPath3.Id, "EnsureSiteAssetsLibrary"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
            );
        }
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<List>? GetObjectEnumerable(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Lists"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(List))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ListEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Guid RecycleObject(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
