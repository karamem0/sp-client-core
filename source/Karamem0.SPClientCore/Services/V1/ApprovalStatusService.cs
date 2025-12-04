//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IApprovalStatusService
{

    void ApproveObject(File fileObject, string? comment);

    void ApproveObject(Folder folderObject, string? comment);

    void ApproveObject(ListItem listItemObject, string? comment);

    void DenyObject(File fileObject, string? comment);

    void DenyObject(Folder folderObject, string? comment);

    void DenyObject(ListItem listItemObject, string? comment);

    void SuspendObject(Folder folderObject, string? comment);

    void SuspendObject(ListItem listItemObject, string? comment);

}

public class ApprovalStatusService(ClientContext clientContext) : ClientService(clientContext), IApprovalStatusService
{

    public void ApproveObject(File fileObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Approve",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void ApproveObject(Folder folderObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Approved)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void ApproveObject(ListItem listItemObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Approved)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(File fileObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Deny",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(Folder folderObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Denied)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(ListItem listItemObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Denied)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SuspendObject(Folder folderObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ListItemAllFields"),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Pending)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SuspendObject(ListItem listItemObject, string? comment)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(listItemObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Pending)
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
