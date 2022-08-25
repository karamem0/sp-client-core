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
using System.Threading;
using System.Threading.Tasks;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITenantSiteCollectionService
    {

        TenantOperationResult AddObject(IReadOnlyDictionary<string, object> creationInfo);

        void AddObjectAwait(IReadOnlyDictionary<string, object> creationInfo);

        TenantSiteCollection GetObject(TenantSiteCollection siteCollectionObject);

        TenantSiteCollection GetObject(Uri siteCollectionUrl);

        TenantSiteCollection GetObjectAwait(TenantSiteCollection siteCollectionObject);

        TenantSiteCollection GetObjectAwait(Uri siteCollectionUrl);

        IEnumerable<TenantSiteCollection> GetObjectEnumerable();

        IEnumerable<TenantSiteCollection> GetObjectEnumerable(IReadOnlyDictionary<string, object> filterInfo);

        TenantOperationResult LockObject(TenantSiteCollection siteCollectionObject);

        void LockObjectAwait(TenantSiteCollection siteCollectionObject);

        TenantOperationResult RemoveObject(TenantSiteCollection siteCollectionObject);

        void RemoveObjectAwait(TenantSiteCollection siteCollectionObject);

        TenantOperationResult SetObject(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object> modificationInfo);

        void SetObjectAwait(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object> modificationInfo);

        TenantOperationResult UnlockObject(TenantSiteCollection siteCollectionObject);

        void UnlockObjectAwait(TenantSiteCollection siteCollectionObject);

    }

    public class TenantSiteCollectionService : TenantClientService, ITenantSiteCollectionService
    {

        public TenantSiteCollectionService(ClientContext clientContext) : base(clientContext)
        {
        }

        public TenantOperationResult AddObject(IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "CreateSite",
                    requestPayload.CreateParameter(new TenantSiteCollectionCreationInfo(creationInfo))),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void AddObjectAwait(IReadOnlyDictionary<string, object> creationInfo)
        {
            this.WaitObject(this.AddObject(creationInfo));
        }

        public TenantSiteCollection GetObject(TenantSiteCollection siteCollectionObject)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(siteCollectionObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public TenantSiteCollection GetObject(Uri siteCollectionUrl)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSitePropertiesByUrl",
                    requestPayload.CreateParameter(siteCollectionUrl.ToString()),
                    requestPayload.CreateParameter(false)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantSiteCollection>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public TenantSiteCollection GetObjectAwait(TenantSiteCollection siteCollectionObject)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            return this.GetObjectAwait(new Uri(siteCollectionObject.Url, UriKind.Absolute));
        }

        public TenantSiteCollection GetObjectAwait(Uri siteCollectionUrl)
        {
            _ = siteCollectionUrl ?? throw new ArgumentNullException(nameof(siteCollectionUrl));
            while (true)
            {
                var errorCount = 0;
                try
                {
                    Thread.Sleep(TimeSpan.FromSeconds(ClientConstants.TenantServiceWaitSeconds));
                    var siteCollectionObject = this.GetObject(siteCollectionUrl);
                    if (siteCollectionObject.Status == "Active")
                    {
                        return siteCollectionObject;
                    }
                }
                catch
                {
                    errorCount += 1;
                    if (errorCount > ClientConstants.MaxRetryCount)
                    {
                        throw;
                    }
                }
            }
        }

        public IEnumerable<TenantSiteCollection> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSitePropertiesFromSharePoint",
                    requestPayload.CreateParameter(null),
                    requestPayload.CreateParameter(false)
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TenantSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<TenantSiteCollection> GetObjectEnumerable(IReadOnlyDictionary<string, object> filterInfo)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                    new ObjectPathMethod(
                    objectPath1.Id,
                    "GetSitePropertiesFromSharePointByFilters",
                    requestPayload.CreateParameter(new TenantSiteCollectionFilter(filterInfo))
                ),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TenantSiteCollection))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantSiteCollectionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public TenantOperationResult LockObject(TenantSiteCollection siteCollectionObject)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(siteCollectionObject.ObjectIdentity),
                objectPathId => new ClientActionSetProperty(
                    objectPathId,
                    "LockState",
                    requestPayload.CreateParameter("NoAccess")));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(objectPath1.Id, "Update"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void LockObjectAwait(TenantSiteCollection siteCollectionObject)
        {
            this.WaitObject(this.LockObject(siteCollectionObject));
        }

        public TenantOperationResult RemoveObject(TenantSiteCollection siteCollectionObject)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            _ = siteCollectionObject.Url ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "RemoveSite",
                    requestPayload.CreateParameter(siteCollectionObject.Url)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void RemoveObjectAwait(TenantSiteCollection siteCollectionObject)
        {
            this.WaitObject(this.RemoveObject(siteCollectionObject));
        }

        public TenantOperationResult SetObject(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(siteCollectionObject.ObjectIdentity),
                requestPayload.CreateSetPropertyDelegates(siteCollectionObject, modificationInfo).ToArray());
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(objectPath1.Id, "Update"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void SetObjectAwait(TenantSiteCollection siteCollectionObject, IReadOnlyDictionary<string, object> modificationInfo)
        {
            this.WaitObject(this.SetObject(siteCollectionObject, modificationInfo));
        }

        public TenantOperationResult UnlockObject(TenantSiteCollection siteCollectionObject)
        {
            _ = siteCollectionObject ?? throw new ArgumentNullException(nameof(siteCollectionObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(siteCollectionObject.ObjectIdentity),
                objectPathId => new ClientActionSetProperty(
                    objectPathId,
                    "LockState",
                    requestPayload.CreateParameter("Unlock")));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(objectPath1.Id, "Update"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void UnlockObjectAwait(TenantSiteCollection siteCollectionObject)
        {
            this.WaitObject(this.UnlockObject(siteCollectionObject));
        }

    }

}
