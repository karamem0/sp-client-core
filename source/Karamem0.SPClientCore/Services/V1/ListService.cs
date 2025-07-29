//
// Copyright (c) 2018-2025 karamem0
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IListService
{

    List? AddObject(IReadOnlyDictionary<string, object?> creationInfo);

    List? GetObject(List listObject);

    List? GetObject(ListItem listItemObject);

    List? GetObject(Models.V1.Folder folderObject);

    List? GetObject(Models.V1.File fileObject);

    List? GetObject(View viewObject);

    List? GetObject(Drive driveObject);

    List? GetObject(Guid listId);

    List? GetObject(Uri listUrl);

    List? GetObject(string listTitle);

    List? GetObject(LibraryType libraryType);

    IEnumerable<List>? GetObjectEnumerable();

    Guid RecycleObject(List listObject);

    void RemoveObject(List listObject);

    void SetObject(List listObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ListService(ClientContext clientContext) : ClientService<List>(clientContext), IListService
{

    public List? AddObject(IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Models.V1.Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Models.V1.File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(View viewObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Drive driveObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Guid listId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(Uri listUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(string listTitle)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public List? GetObject(LibraryType libraryType)
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
            );
        }
        if (libraryType == LibraryType.ClientRenderedSitePages)
        {
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(objectPath3.Id, "EnsureClientRenderedSitePagesLibrary"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
            );
        }
        if (libraryType == LibraryType.SiteAssets)
        {
            var objectPath4 = requestPayload.Add(
                ObjectPathMethod.Create(objectPath3.Id, "EnsureSiteAssetsLibrary"),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
            );
        }
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<List>? GetObjectEnumerable()
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
                ClientQuery.Create(true, typeof(List))
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
