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

public interface IFileService
{

    Task<File?> AddObjectAsync(
        Folder folderObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task CheckInObjectAsync(
        File fileObject,
        string? comment,
        CheckInType? checkInType
    );

    Task CheckOutObjectAsync(File fileObject);

    Task CopyObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite
    );

    Task CopyObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Task<System.IO.Stream> DownloadObjectAsync(File fileObject);

    Task<File?> GetObjectAsync(File fileObject);

    Task<File?> GetObjectAsync(File fileObject, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(FileVersion fileVersionObject, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(App appObject, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(Guid fileId, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(Uri fileUrl, bool selectAllProperties = true);

    Task<File?> GetObjectAsync(
        Folder folderObject,
        string fileName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<File>?> GetObjectEnumerableAsync(Folder folderObject, bool selectAllProperties = true);

    Task MoveObjectAsync(
        File fileObject,
        Uri fileUrl,
        MoveOperations fileMoveOperations
    );

    Task MoveObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Task PublishObjectAsync(File fileObject, string? comment);

    Task<Guid> RecycleObjectAsync(File fileObject);

    Task RemoveObjectAsync(File fileObject, bool force);

    Task SetObjectAsync(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task UndoCheckOutObjectAsync(File fileObject);

    Task UnpublishObjectAsync(File fileObject, string? comment);

    Task UploadObjectAsync(
        Uri folderUrl,
        string fileName,
        System.IO.Stream fileContent,
        bool overwrite
    );

}

public class FileService(ClientContext clientContext) : ClientService<File>(clientContext), IFileService
{

    public async Task<File?> AddObjectAsync(
        Folder folderObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Files"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<FileCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task CheckInObjectAsync(
        File fileObject,
        string? comment,
        CheckInType? checkInType
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "CheckIn",
                requestPayload.CreateParameter(comment),
                requestPayload.CreateParameter(checkInType ?? CheckInType.MinorCheckIn)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task CheckOutObjectAsync(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "CheckOut")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task CopyObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "CopyTo",
                requestPayload.CreateParameter(fileUrl),
                requestPayload.CreateParameter(overwrite)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task CopyObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = fileObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "CopyFile",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority)).ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(fileUrl),
                requestPayload.CreateParameter(overwrite),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<System.IO.Stream> DownloadObjectAsync(File fileObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream", fileObject.ServerRelativeUrl);
        return await this.ClientContext.GetStreamAsync(requestUrl);
    }

    public async Task<File?> GetObjectAsync(FileVersion fileVersionObject, bool selectAllProperties = true)
    {
        var objectIdentity = fileVersionObject.ObjectIdentity;
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<File?> GetObjectAsync(App appObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFileById",
                requestPayload.CreateParameter(appObject.Id)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<File?> GetObjectAsync(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "File"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<File?> GetObjectAsync(Guid fileId, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFileById",
                requestPayload.CreateParameter(fileId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<File?> GetObjectAsync(Uri fileUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFileByServerRelativeUrl",
                requestPayload.CreateParameter(fileUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<File?> GetObjectAsync(
        Folder folderObject,
        string fileName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Files"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByUrl",
                requestPayload.CreateParameter(fileName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(File)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<File>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<File>?> GetObjectEnumerableAsync(Folder folderObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Files"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(File))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<FileEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task MoveObjectAsync(
        File fileObject,
        Uri fileUrl,
        MoveOperations fileMoveOperations
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "MoveTo",
                requestPayload.CreateParameter(fileUrl),
                requestPayload.CreateParameter(fileMoveOperations)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task MoveObjectAsync(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = fileObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "MoveFile",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority)).ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(fileUrl),
                requestPayload.CreateParameter(overwrite),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task PublishObjectAsync(File fileObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Publish",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<Guid> RecycleObjectAsync(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public virtual async Task RemoveObjectAsync(File fileObject, bool force)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteWithParameters",
                requestPayload.CreateParameter(
                    ClientValueObject.Create<FileDeleteParameters>(
                        new Dictionary<string, object?>()
                        {
                            ["BypassSharedLock"] = force
                        }
                    )
                )
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task UndoCheckOutObjectAsync(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "UndoCheckOut")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task UnpublishObjectAsync(File fileObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "UnPublish",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task UploadObjectAsync(
        Uri folderUrl,
        string fileName,
        System.IO.Stream fileContent,
        bool overwrite
    )
    {
        fileContent.Position = 0;
        if (fileContent.Length <= ClientConstants.ChunkSize)
        {
            var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                "_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})",
                folderUrl,
                fileName,
                overwrite
            );
            await this.ClientContext.PostStreamAsync(requestUrl, fileContent);
        }
        else
        {
            var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                "_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})",
                folderUrl,
                fileName,
                overwrite
            );
            await this.ClientContext.PostObjectAsync(requestUrl, null);
            var uploadId = Guid.NewGuid();
            var chunk = new byte[ClientConstants.ChunkSize];
            var bytes = await fileContent.ReadAsync(
                chunk,
                0,
                chunk.Length
            );
            if (bytes > 0)
            {
                using (var stream = new System.IO.MemoryStream(chunk))
                {
                    requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                        "_api/web/getfilebyserverrelativeurl('{0}/{1}')/startupload(uploadid='{2}')",
                        folderUrl,
                        fileName,
                        uploadId
                    );
                    await this.ClientContext.PostStreamAsync(requestUrl, stream);
                }
                var offset = bytes;
                while ((bytes = await fileContent.ReadAsync(
                           chunk,
                           0,
                           chunk.Length
                       )) >
                       0)
                {
                    if (fileContent.Position < fileContent.Length)
                    {
                        using var stream = new System.IO.MemoryStream(chunk);
                        requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                            "_api/web/getfilebyserverrelativeurl('{0}/{1}')/continueupload(uploadid='{2}',fileoffset={3})",
                            folderUrl,
                            fileName,
                            uploadId,
                            offset
                        );
                        await this.ClientContext.PostStreamAsync(requestUrl, stream);
                    }
                    else
                    {
                        var buffer = new byte[bytes];
                        Array.Copy(
                            chunk,
                            buffer,
                            buffer.Length
                        );
                        using var stream = new System.IO.MemoryStream(buffer);
                        requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                            "_api/web/getfilebyserverrelativeurl('{0}/{1}')/finishupload(uploadid='{2}',fileoffset={3})",
                            folderUrl,
                            fileName,
                            uploadId,
                            offset
                        );
                        await this.ClientContext.PostStreamAsync(requestUrl, stream);
                    }
                    offset += bytes;
                }
            }
        }
    }

}
