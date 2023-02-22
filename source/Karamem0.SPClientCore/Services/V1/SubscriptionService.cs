//
// Copyright (c) 2023 karamem0
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

    public interface ISubscriptionService
    {

        Subscription AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo);

        Subscription GetObject(Subscription subscriptionObject);

        Subscription GetObject(List listObject, Guid? subscriptionId);

        IEnumerable<Subscription> GetObjectEnumerable(List listObject);

        void RemoveObject(Subscription subscriptionObject);

        void SetObject(Subscription subscriptionObject, IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class SubscriptionService : ClientService, ISubscriptionService
    {

        public SubscriptionService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Subscription AddObject(List listObject, IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var listUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')", listObject.Id);
            var requestUrl = listUrl
                .ConcatPath("subscriptions")
                .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
            var requestPayload = new ODataV1RequestPayload<SubscriptionCreationInfo>(
                creationInfo
                    .Concat(new Dictionary<string, object>()
                    {
                        { "Resource", listUrl.ToString() }
                    })
                    .ToDictionary(item => item.Key, item => item.Value));
            return this.ClientContext.PostObject<Subscription>(requestUrl, requestPayload.Entity);
        }

        public Subscription GetObject(Subscription subscriptionObject)
        {
            _ = subscriptionObject ?? throw new ArgumentNullException(nameof(subscriptionObject));
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/subscriptions('{1}')",
                    subscriptionObject.Resource,
                    subscriptionObject.Id)
                .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
            return this.ClientContext.GetObject<Subscription>(requestUrl);
        }

        public Subscription GetObject(List listObject, Guid? subscriptionId)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            _ = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/subscriptions('{1}')",
                    listObject.Id,
                    subscriptionId)
                .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
            return this.ClientContext.GetObject<Subscription>(requestUrl);
        }

        public IEnumerable<Subscription> GetObjectEnumerable(List listObject)
        {
            _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/subscriptions", listObject.Id)
                .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
            return this.ClientContext.GetObject<ODataV1ObjectEnumerable<Subscription>>(requestUrl);
        }

        public void RemoveObject(Subscription subscriptionObject)
        {
            _ = subscriptionObject ?? throw new ArgumentNullException(nameof(subscriptionObject));
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/subscriptions('{1}')",
                    subscriptionObject.Resource,
                    subscriptionObject.Id);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void SetObject(Subscription subscriptionObject, IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = subscriptionObject ?? throw new ArgumentNullException(nameof(subscriptionObject));
            _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/lists('{0}')/subscriptions('{1}')",
                    subscriptionObject.Resource,
                    subscriptionObject.Id);
            var requestPayload = new ODataV1RequestPayload<SubscriptionModificationInfo>(modificationInfo);
            this.ClientContext.PatchObject(requestUrl, requestPayload.Entity);
        }

    }

}
