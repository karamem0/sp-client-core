//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IFileService
    {

        void ApproveObject(File fileObject, string comment);

        void CheckInObject(File fileObject, string comment, CheckInType checkInType);

        void CheckOutObject(File fileObject);

        void CopyObject(File fileObject, Uri fileUrl, bool overwrite);

        void CopyObject(File fileObject, Uri fileUrl, bool overwrite, MoveCopyOptions moveCopyOptions);

        File CreateObject(Folder folderObject, IReadOnlyDictionary<string, object> creationInformation);

        void DenyObject(File fileObject, string comment);

        System.IO.Stream DownloadObject(File fileObject);

        File GetObject(File fileObject);

        File GetObject(FileVersion fileVersionObject);

        File GetObject(App appObject);

        File GetObject(Guid fileId);

        File GetObject(Uri fileUrl);

        File GetObject(Folder folderObject, string fileName);

        IEnumerable<File> GetObjectEnumerable(Folder folderObject);

        void MoveObject(File fileObject, Uri fileUrl, MoveOperations fileMoveOperations);

        void MoveObject(File fileObject, Uri fileUrl, bool overwrite, MoveCopyOptions moveCopyOptions);

        void PublishObject(File fileObject, string comment);

        Guid RecycleObject(File fileObject);

        void RemoveObject(File fileObject, bool force);

        void UndoCheckOutObject(File fileObject);

        void UnpublishObject(File fileObject, string comment);

        void UpdateObject(File fileObject, IReadOnlyDictionary<string, object> modificationInformation);

        void UploadObject(string folderUrl, string fileName, System.IO.Stream fileContent, bool overwrite);

    }

    public class FileService : ClientService<File>, IFileService
    {

        public FileService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void ApproveObject(File fileObject, string comment)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Approve",
                    requestPayload.CreateParameter(comment)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void CheckInObject(File fileObject, string comment, CheckInType checkInType)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "CheckIn",
                    requestPayload.CreateParameter(comment),
                    requestPayload.CreateParameter(checkInType)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void CheckOutObject(File fileObject)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "CheckOut"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void CopyObject(File fileObject, Uri fileUrl, bool overwrite)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "CopyTo",
                    requestPayload.CreateParameter(fileUrl.ToString()),
                    requestPayload.CreateParameter(overwrite)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void CopyObject(File fileObject, Uri fileUrl, bool overwrite, MoveCopyOptions moveCopyOptions)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (moveCopyOptions == null)
            {
                throw new ArgumentNullException(nameof(moveCopyOptions));
            }
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(MoveCopyUtil),
                    "CopyFile",
                    requestPayload.CreateParameter(
                        new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority))
                            .ConcatPath(fileObject.ServerRelativeUrl)
                            .ToString()),
                    requestPayload.CreateParameter(fileUrl.ToString()),
                    requestPayload.CreateParameter(overwrite),
                    requestPayload.CreateParameter(moveCopyOptions)
                ));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public File CreateObject(Folder folderObject, IReadOnlyDictionary<string, object> creationInformation)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            if (creationInformation == null)
            {
                throw new ArgumentNullException(nameof(creationInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Files"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "Add",
                    requestPayload.CreateParameter(new FileCreationInformation(creationInformation))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void DenyObject(File fileObject, string comment)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Deny",
                    requestPayload.CreateParameter(comment)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public System.IO.Stream DownloadObject(File fileObject)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream",
                    fileObject.ServerRelativeUrl);
            return this.ClientContext.GetStream(requestUrl);
        }

        public File GetObject(FileVersion fileVersionObject)
        {
            if (fileVersionObject == null)
            {
                throw new ArgumentNullException(nameof(fileVersionObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(string.Join(":", fileVersionObject.ObjectIdentity.Split(':').SkipLast(2))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public File GetObject(App appObject)
        {
            if (appObject == null)
            {
                throw new ArgumentNullException(nameof(appObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetFileById",
                    requestPayload.CreateParameter(appObject.Id)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public File GetObject(Guid fileId)
        {
            if (fileId == default(Guid))
            {
                throw new ArgumentNullException(nameof(fileId));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetFileById",
                    requestPayload.CreateParameter(fileId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public File GetObject(Uri fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetFileByServerRelativeUrl",
                    requestPayload.CreateParameter(fileUrl.ToString())),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public File GetObject(Folder folderObject, string fileName)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Files"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByUrl",
                    requestPayload.CreateParameter(fileName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<File>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<File> GetObjectEnumerable(Folder folderObject)
        {
            if (folderObject == null)
            {
                throw new ArgumentNullException(nameof(folderObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(folderObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Files"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(File))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<FileEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void MoveObject(File fileObject, Uri fileUrl, MoveOperations fileMoveOperations)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "MoveTo",
                    requestPayload.CreateParameter(fileUrl.ToString()),
                    requestPayload.CreateParameter(fileMoveOperations)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void MoveObject(File fileObject, Uri fileUrl, bool overwrite, MoveCopyOptions moveCopyOptions)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (moveCopyOptions == null)
            {
                throw new ArgumentNullException(nameof(moveCopyOptions));
            }
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(MoveCopyUtil),
                    "MoveFile",
                    requestPayload.CreateParameter(
                        new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority))
                            .ConcatPath(fileObject.ServerRelativeUrl)
                            .ToString()),
                    requestPayload.CreateParameter(fileUrl.ToString()),
                    requestPayload.CreateParameter(overwrite),
                    requestPayload.CreateParameter(moveCopyOptions)
                ));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void PublishObject(File fileObject, string comment)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "Publish",
                    requestPayload.CreateParameter(comment)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public Guid RecycleObject(File fileObject)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "Recycle"));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
        }

        public virtual void RemoveObject(File fileObject, bool force)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "DeleteWithParameters",
                    requestPayload.CreateParameter(new FileDeleteParameters(new Dictionary<string, object>()
                    {
                        { "BypassSharedLock", force }
                    }))));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void UndoCheckOutObject(File fileObject)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(objectPathId, "UndoCheckOut"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void UnpublishObject(File fileObject, string comment)
        {
            if (fileObject == null)
            {
                throw new ArgumentNullException(nameof(fileObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathIdentity(fileObject.ObjectIdentity),
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "UnPublish",
                    requestPayload.CreateParameter(comment)));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void UploadObject(string folderUrl, string fileName, System.IO.Stream fileContent, bool overwrite)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            if (fileContent == null)
            {
                throw new ArgumentNullException(nameof(fileContent));
            }
            fileContent.Position = 0;
            if (fileContent.Length <= ClientConstants.ChunkSize)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath(
                        "_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})",
                        folderUrl,
                        fileName,
                        overwrite);
                this.ClientContext.PostStream(requestUrl, fileContent);
            }
            else
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath(
                        "_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})",
                        folderUrl,
                        fileName,
                        overwrite);
                this.ClientContext.PostObject(requestUrl, null);
                var uploadId = Guid.NewGuid();
                var chunk = new byte[ClientConstants.ChunkSize];
                var bytes = fileContent.Read(chunk, 0, chunk.Length);
                if (bytes > 0)
                {
                    using (var stream = new System.IO.MemoryStream(chunk))
                    {
                        requestUrl = this.ClientContext.BaseAddress
                            .ConcatPath(
                                "_api/web/getfilebyserverrelativeurl('{0}/{1}')/startupload(uploadid='{2}')",
                                folderUrl,
                                fileName,
                                uploadId);
                        this.ClientContext.PostStream(requestUrl, stream);
                    }
                    var offset = bytes;
                    while ((bytes = fileContent.Read(chunk, 0, chunk.Length)) > 0)
                    {
                        if (fileContent.Position < fileContent.Length)
                        {
                            using (var stream = new System.IO.MemoryStream(chunk))
                            {
                                requestUrl = this.ClientContext.BaseAddress
                                    .ConcatPath(
                                        "_api/web/getfilebyserverrelativeurl('{0}/{1}')/continueupload(uploadid='{2}',fileoffset={3})",
                                        folderUrl,
                                        fileName,
                                        uploadId,
                                        offset);
                                this.ClientContext.PostStream(requestUrl, stream);
                            }
                        }
                        else
                        {
                            var buffer = new byte[bytes];
                            Array.Copy(chunk, buffer, buffer.Length);
                            using (var stream = new System.IO.MemoryStream(buffer))
                            {
                                requestUrl = this.ClientContext.BaseAddress
                                    .ConcatPath(
                                        "_api/web/getfilebyserverrelativeurl('{0}/{1}')/finishupload(uploadid='{2}',fileoffset={3})",
                                        folderUrl,
                                        fileName,
                                        uploadId,
                                        offset);
                                this.ClientContext.PostStream(requestUrl, stream);
                            }
                        }
                        offset += bytes;
                    }
                }
            }
        }

    }

}
