//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface IExternalUserService
    {

        IEnumerable<UserSharingResult> AddObject(
            IReadOnlyCollection<string> userId,
            RoleType role,
            bool sendServerManagedNotification,
            string customMessage,
            bool additivePermission,
            bool allowExternalSharing
        );

        IEnumerable<UserSharingResult> AddObject(
            string documentUrl,
            IReadOnlyCollection<string> userId,
            RoleType role,
            bool validateExistingPermissions,
            bool additivePermission,
            bool sendServerManagedNotification,
            string customMessage,
            bool includeAnonymousLinksInNotification,
            bool propagateAcl
        );

        bool CheckObject();

        bool CheckObject(List listObject);

    }

    public class ExternalUserService : ClientService, IExternalUserService
    {

        public ExternalUserService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<UserSharingResult> AddObject(
            IReadOnlyCollection<string> userId,
            RoleType role,
            bool sendServerManagedNotification,
            string customMessage,
            bool additivePermission,
            bool allowExternalSharing
        )
        {
            _ = userId ?? throw new ArgumentException(nameof(userId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(WebSharingManager),
                    "UpdateWebSharingInformation",
                    new ClientRequestParameterObjectPath(objectPath2),
                    requestPayload.CreateParameter(userId.Select(value => new UserRoleAssignment(value, role))),
                    requestPayload.CreateParameter(sendServerManagedNotification),
                    requestPayload.CreateParameter(customMessage),
                    requestPayload.CreateParameter(additivePermission),
                    requestPayload.CreateParameter(allowExternalSharing)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public IEnumerable<UserSharingResult> AddObject(
            string documentUrl,
            IReadOnlyCollection<string> userId,
            RoleType role,
            bool validateExistingPermissions,
            bool additivePermission,
            bool sendServerManagedNotification,
            string customMessage,
            bool includeAnonymousLinksInNotification,
            bool propagateAcl
        )
        {
            _ = documentUrl ?? throw new ArgumentNullException(nameof(documentUrl));
            _ = userId ?? throw new ArgumentException(nameof(userId));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(DocumentSharingManager),
                    "UpdateDocumentSharingInfo",
                    requestPayload.CreateParameter(
                        new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority))
                            .ConcatPath(documentUrl)
                            .ToString()),
                    requestPayload.CreateParameter(userId.Select(value => new UserRoleAssignment(value, role))),
                    requestPayload.CreateParameter(validateExistingPermissions),
                    requestPayload.CreateParameter(additivePermission),
                    requestPayload.CreateParameter(sendServerManagedNotification),
                    requestPayload.CreateParameter(customMessage),
                    requestPayload.CreateParameter(includeAnonymousLinksInNotification),
                    requestPayload.CreateParameter(propagateAcl)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<IEnumerable<UserSharingResult>>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public bool CheckObject()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathStaticProperty(typeof(Context), "Current"));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Web"));
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(WebSharingManager),
                    "CanMemberShare",
                    new ClientRequestParameterObjectPath(objectPath2)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public bool CheckObject(List listObject)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(DocumentSharingManager),
                    "CanMemberShare",
                    requestPayload.CreateParameter(listObject)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<bool>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

    }

}
