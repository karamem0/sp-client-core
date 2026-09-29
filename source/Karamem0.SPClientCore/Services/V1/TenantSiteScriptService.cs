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

public interface ITenantSiteScriptService
{

    Task<TenantSiteScript?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo);

    Task<TenantSiteScript?> GetObjectAsync(Guid siteScriptId);

    Task<IEnumerable<TenantSiteScript>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(TenantSiteScript siteScriptObject);

    Task<string?> GetScriptFromListAsync(Uri listUrl);

    Task<string?> GetScriptFromSiteAsync(Uri siteUrl, IReadOnlyDictionary<string, object?> serializationInfo);

}

public class TenantSiteScriptService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteScriptService
{

    public async Task<TenantSiteScript?> AddObjectAsync(IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "CreateSiteScript",
                requestPayload.CreateParameter(ClientValueObject.Create<TenantSiteScriptCreationInfo>(creationInfo))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteScript>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<TenantSiteScript?> GetObjectAsync(Guid siteScriptId)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Tenant),
                "GetSiteScript",
                requestPayload.CreateParameter(siteScriptId)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteScript>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<IEnumerable<TenantSiteScript>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetSiteScripts"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantSiteScript))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteScriptEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(TenantSiteScript siteScriptObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteSiteScript",
                requestPayload.CreateParameter(siteScriptObject.Id)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<string?> GetScriptFromListAsync(Uri listUrl)
    {
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(Tenant),
                "GetSiteScriptFromList",
                requestPayload.CreateParameter(listUrl)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>()));
    }

    public async Task<string?> GetScriptFromSiteAsync(Uri siteUrl, IReadOnlyDictionary<string, object?> serializationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetSiteScriptFromSite",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<TenantSiteScriptSerializationInfo>(serializationInfo))
            )
        );
        var clientObject = await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantSiteScriptSerializationResult>(requestPayload.GetActionId<ClientActionMethod>()));
        _ = clientObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        if (clientObject.Warnings.Any())
        {
            throw new InvalidOperationException(clientObject.Warnings.FirstOrDefault());
        }
        return clientObject.Json;
    }

}
