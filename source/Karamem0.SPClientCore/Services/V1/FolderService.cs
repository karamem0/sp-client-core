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

    Task<Folder?> AddObjectAsync(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    );

    Task CopyObjectAsync(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Task<Folder?> GetObjectAsync(Folder folderObject);

    Task<Folder?> GetObjectAsync(Folder folderObject, bool selectAllProperties = true);

    Task<Folder?> GetObjectAsync(List listObject, bool selectAllProperties = true);

    Task<Folder?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true);

    Task<Folder?> GetObjectAsync(Guid folderId, bool selectAllProperties = true);

    Task<Folder?> GetObjectAsync(Uri folderUrl, bool selectAllProperties = true);

    Task<Folder?> GetObjectAsync(
        Folder folderObject,
        string folderName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<Folder>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task<IEnumerable<Folder>?> GetObjectEnumerableAsync(Folder folderObject, bool selectAllProperties = true);

    Task MoveObjectAsync(Folder folderObject, Uri folderUrl);

    Task MoveObjectAsync(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Task<Guid> RecycleObjectAsync(Folder folderObject);

    Task RemoveObjectAsync(Folder folderObject);

    Task SetObjectAsync(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class FolderService(ClientContext clientContext) : ClientService<Folder>(clientContext), IFolderService
{

    public async Task<Folder?> AddObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task CopyObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<Folder?> GetObjectAsync(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "RootFolder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Folder?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Folder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Folder)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Folder?> GetObjectAsync(Guid folderId, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Folder?> GetObjectAsync(Uri folderUrl, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<Folder?> GetObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Folder>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<Folder>?> GetObjectEnumerableAsync(Folder folderObject, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task MoveObjectAsync(Folder folderObject, Uri folderUrl)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task MoveObjectAsync(
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<Guid> RecycleObjectAsync(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(folderObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>()));
    }

}
