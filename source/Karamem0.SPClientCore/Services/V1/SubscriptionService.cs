//
// Copyright (c) 2018-2025 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISubscriptionService
{

    Subscription? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo);

    Subscription? GetObject(Subscription subscriptionObject);

    Subscription? GetObject(List listObject, Guid subscriptionId);

    IEnumerable<Subscription>? GetObjectEnumerable(List listObject);

    void RemoveObject(Subscription subscriptionObject);

    void SetObject(Subscription subscriptionObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SubscriptionService(ClientContext clientContext) : ClientService(clientContext), ISubscriptionService
{

    public Subscription? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo)
    {
        var listUrl = this.ClientContext.BaseAddress.ConcatPath("_api/web/lists('{0}')", listObject.Id);
        var requestUrl = listUrl
            .ConcatPath("subscriptions")
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        var requestPayload = ODataV1RequestPayload.Create<SubscriptionCreationInfo>(
            creationInfo
                .Concat(
                    new Dictionary<string, object?>()
                    {
                        ["Resource"] = listUrl.ToString()
                    }
                )
                .ToDictionary(item => item.Key, item => item.Value)
        );
        return this.ClientContext.PostObject<Subscription>(requestUrl, requestPayload.Entity);
    }

    public Subscription? GetObject(Subscription subscriptionObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/subscriptions('{1}')",
                subscriptionObject.Resource,
                subscriptionObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return this.ClientContext.GetObject<Subscription>(requestUrl);
    }

    public Subscription? GetObject(List listObject, Guid subscriptionId)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/subscriptions('{1}')",
                listObject.Id,
                subscriptionId
            )
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return this.ClientContext.GetObject<Subscription>(requestUrl);
    }

    public IEnumerable<Subscription>? GetObjectEnumerable(List listObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/lists('{0}')/subscriptions", listObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return this.ClientContext.GetObject<ODataV1ObjectEnumerable<Subscription>>(requestUrl);
    }

    public void RemoveObject(Subscription subscriptionObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/subscriptions('{1}')",
            subscriptionObject.Resource,
            subscriptionObject.Id
        );
        this.ClientContext.DeleteObject(requestUrl);
    }

    public void SetObject(Subscription subscriptionObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/subscriptions('{1}')",
            subscriptionObject.Resource,
            subscriptionObject.Id
        );
        var requestPayload = ODataV1RequestPayload.Create<SubscriptionModificationInfo>(modificationInfo);
        this.ClientContext.PatchObject(requestUrl, requestPayload.Entity);
    }

}
