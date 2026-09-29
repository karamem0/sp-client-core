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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantUserService
{

    Task<User?> AddObjectAsync(
        Uri siteCollectionUrl,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task<User?> GetObjectAsync(
        Uri siteCollectionUrl,
        int userId,
        bool selectAllProperties = true
    );

    Task<User?> GetObjectAsync(
        Uri siteCollectionUrl,
        string userName,
        bool selectAllProperties = true
    );

    Task<IEnumerable<User>?> GetObjectEnumerableAsync(Uri siteCollectionUrl, bool selectAllProperties = true);

    Task RemoveObjectAsync(Uri siteCollectionUrl, User userObject);

    Task SetObjectAsync(
        Uri siteCollectionUrl,
        User userObject,
        bool isSiteCollectionAdmin
    );

    Task SetObjectAsync(
        Uri siteCollectionUrl,
        string userName,
        bool isSiteCollectionAdmin
    );

}

public class TenantUserService(ClientContext clientContext) : ClientService<User>(clientContext), ITenantUserService
{

    public async Task<User?> AddObjectAsync(
        Uri siteCollectionUrl,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"));
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<UserCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<User?> GetObjectAsync(
        Uri siteCollectionUrl,
        int userId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"));
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "GetById",
                requestPayload.CreateParameter(userId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<User?> GetObjectAsync(
        Uri siteCollectionUrl,
        string userName,
        bool selectAllProperties = true
    )
    {
        if (Regex.IsMatch(userName, "^[ci]:0"))
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl)
                )
            );
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"));
            var objectPath5 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath4.Id,
                    "GetByLoginName",
                    requestPayload.CreateParameter(userName)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
        }
        else
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl)
                )
            );
            var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"));
            var objectPath5 = requestPayload.Add(
                ObjectPathMethod.Create(
                    objectPath4.Id,
                    "GetByEmail",
                    requestPayload.CreateParameter(userName)
                ),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(User)))
            );
            return await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<User>(requestPayload.GetActionId<ClientActionQuery>()));
        }
    }

    public async Task<IEnumerable<User>?> GetObjectEnumerableAsync(Uri siteCollectionUrl, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
        var objectPath4 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(User))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(Uri siteCollectionUrl, User userObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSiteByUrl",
                requestPayload.CreateParameter(siteCollectionUrl)
            )
        );
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RootWeb"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SiteUsers"));
        var objectPath5 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath4.Id,
                "GetById",
                requestPayload.CreateParameter(userObject.Id)
            )
        );
        var objectPath6 = requestPayload.Add(objectPath5, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(
        Uri siteCollectionUrl,
        User userObject,
        bool isSiteCollectionAdmin
    )
    {
        var userLoginName = userObject.LoginName;
        _ = userLoginName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        await this.SetObjectAsync(
            siteCollectionUrl,
            userLoginName,
            isSiteCollectionAdmin
        );
    }

    public async Task SetObjectAsync(
        Uri siteCollectionUrl,
        string userName,
        bool isSiteCollectionAdmin
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetSiteAdmin",
                requestPayload.CreateParameter(siteCollectionUrl),
                requestPayload.CreateParameter(userName),
                requestPayload.CreateParameter(isSiteCollectionAdmin)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
