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

public interface IAttachmentFileService
{

    System.IO.Stream DownloadObject(AttachmentFile attachmentFileObject);

    AttachmentFile? GetObject(AttachmentFile attachmentFileObject);

    AttachmentFile? GetObject(ListItem listItemObject, string attachmentFileName);

    IEnumerable<AttachmentFile>? GetObjectEnumerable(ListItem listItemObject);

    void RecycleObject(AttachmentFile attachmentFileObject);

    void RemoveObject(AttachmentFile attachmentFileObject);

    void UploadObject(
        ListItem listItemObject,
        string attachmentFileName,
        System.IO.Stream attachmentFileContent
    );

}

public class AttachmentFileService(ClientContext clientContext) : ClientService<AttachmentFile>(clientContext), IAttachmentFileService
{

    public System.IO.Stream DownloadObject(AttachmentFile attachmentFileObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream",
            attachmentFileObject.ServerRelativeUrl
        );
        return this.ClientContext.GetStream(requestUrl);
    }

    public AttachmentFile? GetObject(ListItem listItemObject, string attachmentFileName)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(AttachmentFile)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AttachmentFile>(ClientRequestObject.CurrentId());
    }

    public IEnumerable<AttachmentFile>? GetObjectEnumerable(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "AttachmentFiles"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(AttachmentFile))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<AttachmentFileEnumerable>(ClientRequestObject.CurrentId());
    }

    public void RecycleObject(AttachmentFile attachmentFileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(attachmentFileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "RecycleObject")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void UploadObject(
        ListItem listItemObject,
        string attachmentFileName,
        System.IO.Stream attachmentFileContent
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        var listObject = this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(ClientRequestObject.CurrentId());
        _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/items({1})/attachmentfiles/add(filename='{2}')",
            listObject.Id,
            listItemObject.Id,
            attachmentFileName
        );
        this.ClientContext.PostStream(requestUrl, attachmentFileContent);
    }

}
