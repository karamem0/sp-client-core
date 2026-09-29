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

public interface ISharingLinkService
{

    Task<string?> CreateAnonymousLinkAsync(Uri url, bool isEditLink);

    Task<string?> CreateAnonymousLinkAsync(
        Uri url,
        bool isEditLink,
        DateTime expiration
    );

    Task<string?> CreateOrganizationSharingLinkAsync(Uri url, bool isEditLink);

    Task<SharingInfo?> GetSharingInfoAsync(
        Uri url,
        bool excludeCurrentUser,
        bool excludeSiteAdmin,
        bool excludeSecurityGroups,
        bool retrieveAnonymousLinks,
        bool retrieveUserInfoDetails,
        bool checkForAccessRequests,
        bool retrievePermissionLevels,
        bool selectAllProperties = true
    );

    Task<SharingSettings?> GetSharingSettingsAsync(
        Uri url,
        int groupId,
        bool useSimplifiedRoles,
        bool selectAllProperties = true
    );

    Task<SharingLinkKind?> GetSharingLinkKindAsync(Uri url);

    Task RemoveAnonymousLinkAsync(
        Uri url,
        bool isEditLink,
        bool removeAssociatedSharingLinkGroup
    );

    Task RemoveOrganizationSharingLinkAsync(
        Uri url,
        bool isEditLink,
        bool removeAssociatedSharingLinkGroup
    );

}

public class SharingLinkService(ClientContext clientContext) : ClientService(clientContext), ISharingLinkService
{

    public async Task<string?> CreateAnonymousLinkAsync(Uri url, bool isEditLink)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "CreateAnonymousLink",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(isEditLink)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<string?> CreateAnonymousLinkAsync(
        Uri url,
        bool isEditLink,
        DateTime expiration
    )
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "CreateAnonymousLinkWithExpiration",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(expiration.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz"))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<string?> CreateOrganizationSharingLinkAsync(Uri url, bool isEditLink)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "CreateOrganizationSharingLink",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(isEditLink)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<SharingInfo?> GetSharingInfoAsync(
        Uri url,
        bool excludeCurrentUser,
        bool excludeSiteAdmin,
        bool excludeSecurityGroups,
        bool retrieveAnonymousLinks,
        bool retrieveUserInfoDetails,
        bool checkForAccessRequests,
        bool retrievePermissionLevels,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(SharingInfo),
                "GetObjectSharingInformationByUrl",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(excludeCurrentUser),
                requestPayload.CreateParameter(excludeSiteAdmin),
                requestPayload.CreateParameter(excludeSecurityGroups),
                requestPayload.CreateParameter(retrieveAnonymousLinks),
                requestPayload.CreateParameter(retrieveUserInfoDetails),
                requestPayload.CreateParameter(checkForAccessRequests),
                requestPayload.CreateParameter(retrievePermissionLevels)
            ),
            objectPath => ClientActionQuery.Create(objectPath, ClientQuery.Create(selectAllProperties, typeof(SharingInfo)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SharingInfo>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<SharingSettings?> GetSharingSettingsAsync(
        Uri url,
        int groupId,
        bool useSimplifiedRoles,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(Site),
                "GetObjectSharingSettings",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(groupId),
                requestPayload.CreateParameter(useSimplifiedRoles)
            ),
            objectPath => ClientActionQuery.Create(objectPath, ClientQuery.Create(selectAllProperties, typeof(SharingSettings)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SharingSettings>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<SharingLinkKind?> GetSharingLinkKindAsync(Uri url)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "GetSharingLinkKind",
                requestPayload.CreateParameter(url)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<SharingLinkKind>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task RemoveAnonymousLinkAsync(
        Uri url,
        bool isEditLink,
        bool removeAssociatedSharingLinkGroup
    )
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "DeleteAnonymousLinkForObject",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveOrganizationSharingLinkAsync(
        Uri url,
        bool isEditLink,
        bool removeAssociatedSharingLinkGroup
    )
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Site),
                "DestroyOrganizationSharingLink",
                requestPayload.CreateParameter(url),
                requestPayload.CreateParameter(isEditLink),
                requestPayload.CreateParameter(removeAssociatedSharingLinkGroup)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
