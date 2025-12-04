//
// Copyright (c) 2018-2025 karamem0
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

    File? AddObject(Folder folderObject, IReadOnlyDictionary<string, object?> creationInfo);

    void CheckInObject(
        File fileObject,
        string? comment,
        CheckInType? checkInType
    );

    void CheckOutObject(File fileObject);

    void CopyObject(
        File fileObject,
        Uri fileUrl,
        bool overwrite
    );

    void CopyObject(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    System.IO.Stream DownloadObject(File fileObject);

    File? GetObject(File fileObject);

    File? GetObject(FileVersion fileVersionObject);

    File? GetObject(App appObject);

    File? GetObject(ListItem listItemObject);

    File? GetObject(Guid fileId);

    File? GetObject(Uri fileUrl);

    File? GetObject(Folder folderObject, string fileName);

    IEnumerable<File>? GetObjectEnumerable(Folder folderObject);

    void MoveObject(
        File fileObject,
        Uri fileUrl,
        MoveOperations fileMoveOperations
    );

    void MoveObject(
        File fileObject,
        Uri fileUrl,
        bool overwrite,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    void PublishObject(File fileObject, string? comment);

    Guid RecycleObject(File fileObject);

    void RemoveObject(File fileObject, bool force);

    void SetObject(File fileObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void UndoCheckOutObject(File fileObject);

    void UnpublishObject(File fileObject, string? comment);

    void UploadObject(
        Uri folderUrl,
        string fileName,
        System.IO.Stream fileContent,
        bool overwrite
    );

}

public class FileService(ClientContext clientContext) : ClientService<File>(clientContext), IFileService
{

    public File? AddObject(Folder folderObject, IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void CheckInObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void CheckOutObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "CheckOut")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void CopyObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void CopyObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public System.IO.Stream DownloadObject(File fileObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream", fileObject.ServerRelativeUrl);
        return this.ClientContext.GetStream(requestUrl);
    }

    public File? GetObject(FileVersion fileVersionObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public File? GetObject(App appObject)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public File? GetObject(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "File"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public File? GetObject(Guid fileId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public File? GetObject(Uri fileUrl)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public File? GetObject(Folder folderObject, string fileName)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(File)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<File>? GetObjectEnumerable(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Files"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(File))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void MoveObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void MoveObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void PublishObject(File fileObject, string? comment)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Guid RecycleObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public virtual void RemoveObject(File fileObject, bool force)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void UndoCheckOutObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "UndoCheckOut")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void UnpublishObject(File fileObject, string? comment)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void UploadObject(
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
            this.ClientContext.PostStream(requestUrl, fileContent);
        }
        else
        {
            var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
                "_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})",
                folderUrl,
                fileName,
                overwrite
            );
            this.ClientContext.PostObject(requestUrl, null);
            var uploadId = Guid.NewGuid();
            var chunk = new byte[ClientConstants.ChunkSize];
            var bytes = fileContent.Read(
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
                    this.ClientContext.PostStream(requestUrl, stream);
                }
                var offset = bytes;
                while ((bytes = fileContent.Read(
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
                        this.ClientContext.PostStream(requestUrl, stream);
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
                        this.ClientContext.PostStream(requestUrl, stream);
                    }
                    offset += bytes;
                }
            }
        }
    }

}
