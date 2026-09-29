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

public interface IAttachmentFileService
{

    Task<System.IO.Stream> DownloadObjectAsync(AttachmentFile attachmentFileObject);

    Task<AttachmentFile?> GetObjectAsync(AttachmentFile attachmentFileObject);

    Task<AttachmentFile?> GetObjectAsync(AttachmentFile attachmentFileObject, bool selectAllProperties = true);

    Task<AttachmentFile?> GetObjectAsync(
        ListItem listItemObject,
        string attachmentFileName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<AttachmentFile>?> GetObjectEnumerableAsync(ListItem listItemObject, bool selectAllProperties = true);

    Task RecycleObjectAsync(AttachmentFile attachmentFileObject);

    Task RemoveObjectAsync(AttachmentFile attachmentFileObject);

    Task UploadObjectAsync(
        ListItem listItemObject,
        string attachmentFileName,
        System.IO.Stream attachmentFileContent,
        bool selectAllProperties = true
    );

}

public class AttachmentFileService(ClientContext clientContext) : ClientService<AttachmentFile>(clientContext), IAttachmentFileService
{

    public async Task<System.IO.Stream> DownloadObjectAsync(AttachmentFile attachmentFileObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream",
            attachmentFileObject.ServerRelativeUrl
        );
        return await this.ClientContext.GetStreamAsync(requestUrl);
    }

    public async Task<AttachmentFile?> GetObjectAsync(
        ListItem listItemObject,
        string attachmentFileName,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "AttachmentFiles"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByFileName",
                requestPayload.CreateParameter(attachmentFileName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(AttachmentFile)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AttachmentFile>(ClientRequestObject.CurrentId()));
    }

    public async Task<IEnumerable<AttachmentFile>?> GetObjectEnumerableAsync(ListItem listItemObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "AttachmentFiles"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(AttachmentFile))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<AttachmentFileEnumerable>(ClientRequestObject.CurrentId()));
    }

    public async Task RecycleObjectAsync(AttachmentFile attachmentFileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(attachmentFileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "RecycleObject")
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task UploadObjectAsync(
        ListItem listItemObject,
        string attachmentFileName,
        System.IO.Stream attachmentFileContent,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(List)))
        );
        var listObject = await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<List>(ClientRequestObject.CurrentId()));
        _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/attachmentfiles/add(filename='{2}')",
            listObject.Id,
            listItemObject.Id,
            attachmentFileName
        );
        await this.ClientContext.PostStreamAsync(requestUrl, attachmentFileContent);
    }

}
