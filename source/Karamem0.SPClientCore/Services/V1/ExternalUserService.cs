//
// Copyright (c) 2018-2026 karamem0
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

    Task<IEnumerable<UserSharingResult>?> AddObjectAsync(
        IEnumerable<string> userId,
        RoleType role,
        bool sendServerManagedNotification,
        string? customMessage,
        bool additivePermission,
        bool allowExternalSharing
    );

    Task<IEnumerable<UserSharingResult>?> AddObjectAsync(
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

    Task<bool> CheckObjectAsync();

    Task<bool> CheckObjectAsync(List listObject);

}

public class ExternalUserService(ClientContext clientContext) : ClientService(clientContext), IExternalUserService
{

    public async Task<IEnumerable<UserSharingResult>?> AddObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<UserSharingResult>?> AddObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<bool> CheckObjectAsync()
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<bool> CheckObjectAsync(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(DocumentSharingManager),
                "CanMemberShare",
                requestPayload.CreateParameter(listObject)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

}
