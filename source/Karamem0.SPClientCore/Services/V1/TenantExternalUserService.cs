//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantExternalUserService
{

    IEnumerable<ExternalUser>? GetObjectEnumerable(string? filter, SortOrder sortOrder);

    IEnumerable<ExternalUser>? GetObjectEnumerable(
        Uri siteCollectionUrl,
        string? filter,
        SortOrder sortOrder
    );

    void RemoveObject(ExternalUser userObject);

}

public class TenantExternalUserService(ClientContext clientContext) : ClientService(clientContext), ITenantExternalUserService
{

    public IEnumerable<ExternalUser>? GetObjectEnumerable(string? filter, SortOrder sortOrder)
    {
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ExternalUserResult)))
            );
            var resultObject = this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<ExternalUserResult>(requestPayload.GetActionId<ClientActionQuery>());
            _ = resultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (resultObject.ExternalUsers is not null)
            {
                foreach (var userObject in resultObject.ExternalUsers)
                {
                    yield return userObject;
                }
            }
            position = resultObject.Position;
            totalCount = resultObject.TotalCount;
        } while (position >= 0 && position < totalCount);
    }

    public IEnumerable<ExternalUser>? GetObjectEnumerable(
        Uri siteCollectionUrl,
        string? filter,
        SortOrder sortOrder
    )
    {
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(ExternalUserResult)))
            );
            var resultObject = this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<ExternalUserResult>(requestPayload.GetActionId<ClientActionQuery>());
            _ = resultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            if (resultObject.ExternalUsers is not null)
            {
                foreach (var userObject in resultObject.ExternalUsers)
                {
                    yield return userObject;
                }
            }
            position = resultObject.Position;
            totalCount = resultObject.TotalCount;
        } while (position >= 0 && position < totalCount);
    }

    public void RemoveObject(ExternalUser userObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
