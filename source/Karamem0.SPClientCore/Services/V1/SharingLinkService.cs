//
// Copyright (c) 2018-2024 karamem0
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

public interface ISharingLinkService
{

    string CreateAnonymousLink(Uri url, bool isEditLink);

    string CreateAnonymousLink(Uri url, bool isEditLink, DateTime expiration);

    string CreateOrganizationSharingLink(Uri url, bool isEditLink);

    SharingInfo GetSharingInfo(
        Uri url,
        bool excludeCurrentUser,
        bool excludeSiteAdmin,
        bool excludeSecurityGroups,
        bool retrieveAnonymousLinks,
        bool retrieveUserInfoDetails,
        bool checkForAccessRequests,
        bool retrievePermissionLevels
    );

    SharingSettings GetSharingSettings(Uri url, int groupId, bool useSimplifiedRoles);

    SharingLinkKind GetSharingLinkKind(Uri url);

    void RemoveAnonymousLink(Uri url, bool isEditLink, bool removeAssociatedSharingLinkGroup);

    void RemoveOrganizationSharingLink(Uri url, bool isEditLink, bool removeAssociatedSharingLinkGroup);

}

public class SharingLinkService(ClientContext clientContext) : ClientService(clientContext), ISharingLinkService
{
    public string CreateAnonymousLink(Uri url, bool isEditLink)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "CreateAnonymousLink",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(isEditLink)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public string CreateAnonymousLink(Uri url, bool isEditLink, DateTime expiration)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "CreateAnonymousLinkWithExpiration",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(expiration.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz"))
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public string CreateOrganizationSharingLink(Uri url, bool isEditLink)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "CreateOrganizationSharingLink",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(isEditLink)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public SharingInfo GetSharingInfo(
        Uri url,
        bool excludeCurrentUser,
        bool excludeSiteAdmin,
        bool excludeSecurityGroups,
        bool retrieveAnonymousLinks,
        bool retrieveUserInfoDetails,
        bool checkForAccessRequests,
        bool retrievePermissionLevels
    )
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(SharingInfo),
                "GetObjectSharingInformationByUrl",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(excludeCurrentUser),
                requestPayload.CreateParameter(excludeSiteAdmin),
                requestPayload.CreateParameter(excludeSecurityGroups),
                requestPayload.CreateParameter(retrieveAnonymousLinks),
                requestPayload.CreateParameter(retrieveUserInfoDetails),
                requestPayload.CreateParameter(checkForAccessRequests),
                requestPayload.CreateParameter(retrievePermissionLevels)
            ),
            objectPath => new ClientActionQuery(objectPath)
            {
                Query = new ClientQuery(true, typeof(SharingInfo))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<SharingInfo>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public SharingSettings GetSharingSettings(Uri url, int groupId, bool useSimplifiedRoles)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticMethod(
                typeof(Site),
                "GetObjectSharingSettings",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(groupId),
                requestPayload.CreateParameter(useSimplifiedRoles)
            ),
            objectPath => new ClientActionQuery(objectPath)
            {
                Query = new ClientQuery(true, typeof(SharingSettings))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<SharingSettings>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public SharingLinkKind GetSharingLinkKind(Uri url)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "GetSharingLinkKind",
                requestPayload.CreateParameter(url.ToString())
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<SharingLinkKind>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public void RemoveAnonymousLink(Uri url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "DeleteAnonymousLinkForObject",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
        ));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveOrganizationSharingLink(Uri url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
    {
        _ = url ?? throw new ArgumentNullException(nameof(url));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Site),
                "DestroyOrganizationSharingLink",
                requestPayload.CreateParameter(url.ToString()),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
        ));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
