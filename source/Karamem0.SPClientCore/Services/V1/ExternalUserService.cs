//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IExternalUserService
{

    IEnumerable<UserSharingResult>? AddObject(
        IEnumerable<string> userId,
        RoleType role,
        bool sendServerManagedNotification,
        string? customMessage,
        bool additivePermission,
        bool allowExternalSharing
    );

    IEnumerable<UserSharingResult>? AddObject(
        Uri documentUrl,
        IEnumerable<string> userId,
        RoleType role,
        bool validateExistingPermissions,
        bool additivePermission,
        bool sendServerManagedNotification,
        string? customMessage,
        bool includeAnonymousLinksInNotification,
        bool propagateAcl
    );

    bool CheckObject();

    bool CheckObject(List listObject);

}

public class ExternalUserService(ClientContext clientContext) : ClientService(clientContext), IExternalUserService
{

    public IEnumerable<UserSharingResult>? AddObject(
        IEnumerable<string> userId,
        RoleType role,
        bool sendServerManagedNotification,
        string? customMessage,
        bool additivePermission,
        bool allowExternalSharing
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(WebSharingManager),
                "UpdateWebSharingInformation",
                ClientRequestParameterObjectPath.Create(objectPath2),
                requestPayload.CreateParameter(userId.Select(value => new UserRoleAssignment(value, role))),
                requestPayload.CreateParameter(sendServerManagedNotification),
                requestPayload.CreateParameter(customMessage),
                requestPayload.CreateParameter(additivePermission),
                requestPayload.CreateParameter(allowExternalSharing)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<UserSharingResult>? AddObject(
        Uri documentUrl,
        IEnumerable<string> userId,
        RoleType role,
        bool validateExistingPermissions,
        bool additivePermission,
        bool sendServerManagedNotification,
        string? customMessage,
        bool includeAnonymousLinksInNotification,
        bool propagateAcl
    )
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(DocumentSharingManager),
                "UpdateDocumentSharingInfo",
                requestPayload.CreateParameter(new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority)).ConcatPath(documentUrl.ToString())),
                requestPayload.CreateParameter(userId.Select(value => new UserRoleAssignment(value, role))),
                requestPayload.CreateParameter(validateExistingPermissions),
                requestPayload.CreateParameter(additivePermission),
                requestPayload.CreateParameter(sendServerManagedNotification),
                requestPayload.CreateParameter(customMessage),
                requestPayload.CreateParameter(includeAnonymousLinksInNotification),
                requestPayload.CreateParameter(propagateAcl)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public bool CheckObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(WebSharingManager),
                "CanMemberShare",
                ClientRequestParameterObjectPath.Create(objectPath2)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public bool CheckObject(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(DocumentSharingManager),
                "CanMemberShare",
                requestPayload.CreateParameter(listObject)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

}
