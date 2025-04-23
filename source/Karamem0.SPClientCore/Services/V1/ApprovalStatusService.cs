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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IApprovalStatusService
{

    void ApproveObject(File fileObject, string comment);

    void ApproveObject(Folder folderObject, string comment);

    void ApproveObject(ListItem listItemObject, string comment);

    void DenyObject(File fileObject, string comment);

    void DenyObject(Folder folderObject, string comment);

    void DenyObject(ListItem listItemObject, string comment);

    void SuspendObject(Folder folderObject, string comment);

    void SuspendObject(ListItem listItemObject, string comment);

}

public class ApprovalStatusService(ClientContext clientContext) : ClientService(clientContext), IApprovalStatusService
{

    public void ApproveObject(File fileObject, string comment)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(fileObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Approve",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void ApproveObject(Folder folderObject, string comment)
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Approved)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void ApproveObject(ListItem listItemObject, string comment)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listItemObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Approved)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(File fileObject, string comment)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(fileObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "Deny",
                requestPayload.CreateParameter(comment)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(Folder folderObject, string comment)
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Denied)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DenyObject(ListItem listItemObject, string comment)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listItemObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Denied)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SuspendObject(Folder folderObject, string comment)
    {
        _ = folderObject ?? throw new ArgumentNullException(nameof(folderObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "ListItemAllFields"),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Pending)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SuspendObject(ListItem listItemObject, string comment)
    {
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(listItemObject.ObjectIdentity),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationStatus"),
                requestPayload.CreateParameter(ModerationStatusType.Pending)
            ),
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("_ModerationComments"),
                requestPayload.CreateParameter(comment)
            ),
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
