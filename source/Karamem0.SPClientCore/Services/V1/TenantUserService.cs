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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantUserService
{

    User? AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object?> creationInfo);

    User? GetObject(Uri siteCollectionUrl, int userId);

    User? GetObject(Uri siteCollectionUrl, string userName);

    IEnumerable<User>? GetObjectEnumerable(Uri siteCollectionUrl);

    void RemoveObject(Uri siteCollectionUrl, User userObject);

    void SetObject(
        Uri siteCollectionUrl,
        User userObject,
        bool isSiteCollectionAdmin
    );

    void SetObject(
        Uri siteCollectionUrl,
        string userName,
        bool isSiteCollectionAdmin
    );

}

public class TenantUserService(ClientContext clientContext) : ClientService<User>(clientContext), ITenantUserService
{

    public User? AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object?> creationInfo)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(Uri siteCollectionUrl, int userId)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public User? GetObject(Uri siteCollectionUrl, string userName)
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(User)))
            );
            return this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

    public IEnumerable<User>? GetObjectEnumerable(Uri siteCollectionUrl)
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
                ClientQuery.Create(true, typeof(User))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(Uri siteCollectionUrl, User userObject)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(
        Uri siteCollectionUrl,
        User userObject,
        bool isSiteCollectionAdmin
    )
    {
        var userLoginName = userObject.LoginName;
        _ = userLoginName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.SetObject(
            siteCollectionUrl,
            userLoginName,
            isSiteCollectionAdmin
        );
    }

    public void SetObject(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
