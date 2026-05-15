//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFolderService
{

    Folder? AddObject(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    );

    void CopyObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Folder? GetObject(Folder folderObject);

    Folder? GetObject(Folder folderObject, bool selectAllProperties = true);

    Folder? GetObject(List listObject, bool selectAllProperties = true);

    Folder? GetObject(ListItem listItemObject, bool selectAllProperties = true);

    Folder? GetObject(Guid folderId, bool selectAllProperties = true);

    Folder? GetObject(Uri folderUrl, bool selectAllProperties = true);

    Folder? GetObject(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    );

    IEnumerable<Folder>? GetObjectEnumerable(bool selectAllProperties = true);

    IEnumerable<Folder>? GetObjectEnumerable(Folder folderObject, bool selectAllProperties = true);

    void MoveObject(Folder folderObject, Uri folderUrl);

    void MoveObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Guid RecycleObject(Folder folderObject);

    void RemoveObject(Folder folderObject);

    void SetObject(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class FolderService(ClientContext clientContext) : ClientService<Folder>(clientContext), IFolderService
{

    public Folder? AddObject(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Folders"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(folderName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void CopyObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = folderObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "CopyFolder",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority)).ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(folderUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Folder? GetObject(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "RootFolder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Folder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(Guid folderId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFolderById",
                requestPayload.CreateParameter(folderId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(Uri folderUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFolderByServerRelativeUrl",
                requestPayload.CreateParameter(folderUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Folders"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByUrl",
                requestPayload.CreateParameter(folderName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Folder>? GetObjectEnumerable(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Folders"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Folder>? GetObjectEnumerable(Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Folders"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(Folder))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void MoveObject(Folder folderObject, Uri folderUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(folderObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "MoveTo",
                requestPayload.CreateParameter(folderUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void MoveObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = folderObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "MoveFolder",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority)).ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(folderUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Guid RecycleObject(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(folderObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
