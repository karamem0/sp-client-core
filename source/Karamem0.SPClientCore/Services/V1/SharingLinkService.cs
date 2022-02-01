//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ISharingLinkService
    {

        string CreateAnonymousLink(string url, bool isEditLink);

        string CreateAnonymousLink(string url, bool isEditLink, DateTime expiration);

        string CreateOrganizationSharingLink(string url, bool isEditLink);

        SharingLinkKind GetSharingLinkKind(string url);

        void RemoveAnonymousLink(string url, bool isEditLink, bool removeAssociatedSharingLinkGroup);

        void RemoveOrganizationSharingLink(string url, bool isEditLink, bool removeAssociatedSharingLinkGroup);

    }

    public class SharingLinkService : ClientService, ISharingLinkService
    {

        public SharingLinkService(ClientContext clientContext) : base(clientContext)
        {
        }

        public string CreateAnonymousLink(string url, bool isEditLink)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "CreateAnonymousLink",
                    requestPayload.CreateParameter(url),
                    requestPayload.CreateParameter(isEditLink)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public string CreateAnonymousLink(string url, bool isEditLink, DateTime expiration)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "CreateAnonymousLinkWithExpiration",
                    requestPayload.CreateParameter(url),
                    requestPayload.CreateParameter(isEditLink),
                    requestPayload.CreateParameter(expiration.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz"))
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public string CreateOrganizationSharingLink(string url, bool isEditLink)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "CreateOrganizationSharingLink",
                    requestPayload.CreateParameter(url),
                    requestPayload.CreateParameter(isEditLink)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public SharingLinkKind GetSharingLinkKind(string url)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "GetSharingLinkKind",
                    requestPayload.CreateParameter(url)
                ));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<SharingLinkKind>(requestPayload.GetActionId<ClientActionStaticMethod>());
        }

        public void RemoveAnonymousLink(string url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "DeleteAnonymousLinkForObject",
                    requestPayload.CreateParameter(url),
                    requestPayload.CreateParameter(isEditLink),
                    requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
            ));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public void RemoveOrganizationSharingLink(string url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
        {
            _ = url ?? throw new ArgumentNullException(nameof(url));
            var requestPayload = new ClientRequestPayload();
            requestPayload.Actions.Add(
                new ClientActionStaticMethod(
                    typeof(Site),
                    "DestroyOrganizationSharingLink",
                    requestPayload.CreateParameter(url),
                    requestPayload.CreateParameter(isEditLink),
                    requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
            ));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
