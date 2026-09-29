//
// Copyright (c) 2018-2026 karamem0
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

    Task ApproveObjectAsync(File fileObject, string? comment);

    Task ApproveObjectAsync(Folder folderObject, string? comment);

    Task ApproveObjectAsync(ListItem listItemObject, string? comment);

    Task DenyObjectAsync(File fileObject, string? comment);

    Task DenyObjectAsync(Folder folderObject, string? comment);

    Task DenyObjectAsync(ListItem listItemObject, string? comment);

    Task SuspendObjectAsync(Folder folderObject, string? comment);

    Task SuspendObjectAsync(ListItem listItemObject, string? comment);

}

public class ApprovalStatusService(ClientContext clientContext) : ClientService(clientContext), IApprovalStatusService
{

    public async Task ApproveObjectAsync(File fileObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task ApproveObjectAsync(Folder folderObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task ApproveObjectAsync(ListItem listItemObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task DenyObjectAsync(File fileObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task DenyObjectAsync(Folder folderObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task DenyObjectAsync(ListItem listItemObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SuspendObjectAsync(Folder folderObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SuspendObjectAsync(ListItem listItemObject, string? comment)
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
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
