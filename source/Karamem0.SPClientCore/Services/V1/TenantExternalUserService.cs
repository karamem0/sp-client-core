//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantExternalUserService
{

    Task<IEnumerable<ExternalUser>?> GetObjectEnumerableAsync(
        string? filter,
        SortOrder sortOrder,
        bool selectAllProperties = true
    );

    Task<IEnumerable<ExternalUser>?> GetObjectEnumerableAsync(
        Uri siteCollectionUrl,
        string? filter,
        SortOrder sortOrder,
        bool selectAllProperties = true
    );

    Task RemoveObjectAsync(ExternalUser userObject);

}

public class TenantExternalUserService(ClientContext clientContext) : ClientService(clientContext), ITenantExternalUserService
{

    public async Task<IEnumerable<ExternalUser>?> GetObjectEnumerableAsync(
        string? filter,
        SortOrder sortOrder,
        bool selectAllProperties = true
    )
    {
        var externalUsers = new List<ExternalUser>();
        var position = 0;
        var totalCount = 0;
        do
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Office365Tenant)));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "GetExternalUsers",
                    requestPayload.CreateParameter(position),
                    requestPayload.CreateParameter(ClientConstants.PageSize),
                    requestPayload.CreateParameter(filter),
                    requestPayload.CreateParameter(sortOrder)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ExternalUserResult)))
            );
            var resultObject = await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<ExternalUserResult>(requestPayload.GetActionId<ClientActionQuery>()));
            _ = resultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (resultObject.ExternalUsers is not null)
            {
                foreach (var userObject in resultObject.ExternalUsers)
                {
                    externalUsers.Add(userObject);
                }
            }
            position = resultObject.Position;
            totalCount = resultObject.TotalCount;
        } while (position >= 0 && position < totalCount);
        return externalUsers;
    }

    public async Task<IEnumerable<ExternalUser>?> GetObjectEnumerableAsync(
        Uri siteCollectionUrl,
        string? filter,
        SortOrder sortOrder,
        bool selectAllProperties = true
    )
    {
        var externalUsers = new List<ExternalUser>();
        var position = 0;
        var totalCount = 0;
        do
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Office365Tenant)));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "GetExternalUsersForSite",
                    requestPayload.CreateParameter(siteCollectionUrl),
                    requestPayload.CreateParameter(position),
                    requestPayload.CreateParameter(ClientConstants.PageSize),
                    requestPayload.CreateParameter(filter),
                    requestPayload.CreateParameter(sortOrder)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ExternalUserResult)))
            );
            var resultObject = await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<ExternalUserResult>(requestPayload.GetActionId<ClientActionQuery>()));
            _ = resultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (resultObject.ExternalUsers is not null)
            {
                foreach (var userObject in resultObject.ExternalUsers)
                {
                    externalUsers.Add(userObject);
                }
            }
            position = resultObject.Position;
            totalCount = resultObject.TotalCount;
        } while (position >= 0 && position < totalCount);
        return externalUsers;
    }

    public async Task RemoveObjectAsync(ExternalUser userObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Office365Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveExternalUsers",
                requestPayload.CreateParameter(
                    new[]
                    {
                        userObject.UniqueId
                    }
                )
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
