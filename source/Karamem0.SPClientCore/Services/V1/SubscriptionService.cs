//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISubscriptionService
{

    Task<Subscription?> AddObjectAsync(List listObject, IReadOnlyDictionary<string, object?> creationInfo);

    Task<Subscription?> GetObjectAsync(Subscription subscriptionObject);

    Task<Subscription?> GetObjectAsync(Subscription subscriptionObject, bool selectAllProperties = true);

    Task<Subscription?> GetObjectAsync(List listObject, Guid subscriptionId);

    Task<IEnumerable<Subscription>?> GetObjectEnumerableAsync(List listObject);

    Task RemoveObjectAsync(Subscription subscriptionObject);

    Task SetObjectAsync(Subscription subscriptionObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SubscriptionService(ClientContext clientContext) : ClientService(clientContext), ISubscriptionService
{

    public async Task<Subscription?> AddObjectAsync(List listObject, IReadOnlyDictionary<string, object?> creationInfo)
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
        return await this.ClientContext.PostObjectAsync<Subscription>(requestUrl, requestPayload.Entity);
    }

    public async Task<Subscription?> GetObjectAsync(Subscription subscriptionObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/subscriptions('{1}')",
                subscriptionObject.Resource,
                subscriptionObject.Id
            )
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return await this.ClientContext.GetObjectAsync<Subscription>(requestUrl);
    }

    public async Task<Subscription?> GetObjectAsync(Subscription subscriptionObject, bool selectAllProperties = true)
    {
        return await this.GetObjectAsync(subscriptionObject);
    }

    public async Task<Subscription?> GetObjectAsync(List listObject, Guid subscriptionId)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/lists('{0}')/subscriptions('{1}')",
                listObject.Id,
                subscriptionId
            )
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return await this.ClientContext.GetObjectAsync<Subscription>(requestUrl);
    }

    public async Task<IEnumerable<Subscription>?> GetObjectEnumerableAsync(List listObject)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/lists('{0}')/subscriptions", listObject.Id)
            .ConcatQuery(ODataQuery.CreateSelect<Subscription>());
        return await this.ClientContext.GetObjectAsync<ODataV1ObjectEnumerable<Subscription>>(requestUrl);
    }

    public async Task RemoveObjectAsync(Subscription subscriptionObject)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/subscriptions('{1}')",
            subscriptionObject.Resource,
            subscriptionObject.Id
        );
        await this.ClientContext.DeleteObjectAsync(requestUrl);
    }

    public async Task SetObjectAsync(Subscription subscriptionObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/lists('{0}')/subscriptions('{1}')",
            subscriptionObject.Resource,
            subscriptionObject.Id
        );
        var requestPayload = ODataV1RequestPayload.Create<SubscriptionModificationInfo>(modificationInfo);
        await this.ClientContext.PatchObjectAsync(requestUrl, requestPayload.Entity);
    }

}
