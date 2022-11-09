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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITenantUserService
    {

        User AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object> creationInfo);

        User GetObject(Uri siteCollectionUrl, int? userId);

        User GetObject(Uri siteCollectionUrl, string userName);

        IEnumerable<User> GetObjectEnumerable(Uri siteCollectionUrl);

        void RemoveObject(Uri siteCollectionUrl, User userObject);

        void SetObject(Uri siteCollectionUrl, User userObject, bool isSiteCollectionAdmin);

        void SetObject(Uri siteCollectionUrl, string userName, bool isSiteCollectionAdmin);

    }

    public class TenantUserService : ClientService<User>, ITenantUserService
    {

        public TenantUserService(ClientContext clientContext) : base(clientContext)
        {
        }

        public User AddObject(Uri siteCollectionUrl, IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString())));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SiteUsers"));
            var objectPath5 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath4.Id,
                    "Add",
                    requestPayload.CreateParameter(new UserCreationInfo(creationInfo))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(User))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public User GetObject(Uri siteCollectionUrl, int? userId)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            _ = userId ?? throw new ArgumentNullException(nameof(userId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString())));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SiteUsers"));
            var objectPath5 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath4.Id,
                    "GetById",
                    requestPayload.CreateParameter(userId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(User))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public User GetObject(Uri siteCollectionUrl, string userName)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            _ = userName ?? throw new ArgumentNullException(nameof(userName));
            if (Regex.IsMatch(userName, "^[ci]:0"))
            {
                var requestPayload = new ClientRequestPayload();
                var objectPath1 = requestPayload.Add(
                    new ObjectPathConstructor(typeof(Tenant)));
                var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath1.Id,
                        "GetSiteByUrl",
                        requestPayload.CreateParameter(siteCollectionUrl.ToString())));
                var objectPath3 = requestPayload.Add(
                    new ObjectPathProperty(objectPath2.Id, "RootWeb"));
                var objectPath4 = requestPayload.Add(
                    new ObjectPathProperty(objectPath3.Id, "SiteUsers"));
                var objectPath5 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath4.Id,
                        "GetByLoginName",
                        requestPayload.CreateParameter(userName)),
                    objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                    objectPathId => new ClientActionQuery(objectPathId)
                    {
                        Query = new ClientQuery(true, typeof(User))
                    });
                return this.ClientContext
                    .ProcessQuery(requestPayload)
                    .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
            }
            else
            {
                var requestPayload = new ClientRequestPayload();
                var objectPath1 = requestPayload.Add(
                    new ObjectPathConstructor(typeof(Tenant)));
                var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath1.Id,
                        "GetSiteByUrl",
                        requestPayload.CreateParameter(siteCollectionUrl.ToString())));
                var objectPath3 = requestPayload.Add(
                    new ObjectPathProperty(objectPath2.Id, "RootWeb"));
                var objectPath4 = requestPayload.Add(
                    new ObjectPathProperty(objectPath3.Id, "SiteUsers"));
                var objectPath5 = requestPayload.Add(
                    new ObjectPathMethod(
                        objectPath4.Id,
                        "GetByEmail",
                        requestPayload.CreateParameter(userName)),
                    objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                    objectPathId => new ClientActionQuery(objectPathId)
                    {
                        Query = new ClientQuery(true, typeof(User))
                    });
                return this.ClientContext
                    .ProcessQuery(requestPayload)
                    .ToObject<User>(requestPayload.GetActionId<ClientActionQuery>());
            }
        }

        public IEnumerable<User> GetObjectEnumerable(Uri siteCollectionUrl)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString())));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SiteUsers"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(User))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<UserEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void RemoveObject(Uri siteCollectionUrl, User userObject)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            _ = userObject ?? throw new ArgumentNullException(nameof(userObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSiteByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString())));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "RootWeb"));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "SiteUsers"));
            var objectPath5 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath4.Id,
                    "GetById",
                    requestPayload.CreateParameter(userObject.Id)));
            var objectPath6 = requestPayload.Add(
                objectPath5,
                objectPathId => new ClientActionMethod(objectPathId, "DeleteObject"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public void SetObject(Uri siteCollectionUrl, User userObject, bool isSiteCollectionAdmin)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            _ = userObject ?? throw new ArgumentNullException(nameof(userObject));
            this.SetObject(siteCollectionUrl, userObject.LoginName, isSiteCollectionAdmin);
        }

        public void SetObject(Uri siteCollectionUrl, string userName, bool isSiteCollectionAdmin)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            _ = userName ?? throw new ArgumentNullException(nameof(userName));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetSiteAdmin",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString()),
                    requestPayload.CreateParameter(userName),
                    requestPayload.CreateParameter(isSiteCollectionAdmin)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
