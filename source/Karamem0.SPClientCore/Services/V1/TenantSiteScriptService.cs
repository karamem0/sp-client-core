//
// Copyright (c) 2018-2025 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantSiteScriptService
{

    TenantSiteScript AddObject(IReadOnlyDictionary<string, object> creationInfo);

    TenantSiteScript GetObject(Guid? siteScriptId);

    IEnumerable<TenantSiteScript> GetObjectEnumerable();

    void RemoveObject(TenantSiteScript siteScriptObject);

    string GetScriptFromList(string listUrl);

    string GetScriptFromSite(string siteUrl, IReadOnlyDictionary<string, object> serializationInfo);

}

public class TenantSiteScriptService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteScriptService
{

    public TenantSiteScript AddObject(IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "CreateSiteScript",
                requestPayload.CreateParameter(new TenantSiteScriptCreationInfo(creationInfo))));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteScript>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public TenantSiteScript GetObject(Guid? siteScriptId)
    {
        _ = siteScriptId ?? throw new ArgumentNullException(nameof(siteScriptId));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Tenant),
                "GetSiteScript",
                requestPayload.CreateParameter(siteScriptId)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteScript>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<TenantSiteScript> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetSiteScripts"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(TenantSiteScript))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteScriptEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(TenantSiteScript siteScriptObject)
    {
        _ = siteScriptObject ?? throw new ArgumentNullException(nameof(siteScriptObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "DeleteSiteScript",
                requestPayload.CreateParameter(siteScriptObject.Id)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public string GetScriptFromList(string listUrl)
    {
        _ = listUrl ?? throw new ArgumentNullException(nameof(listUrl));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Tenant),
                "GetSiteScriptFromList",
                requestPayload.CreateParameter(listUrl)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public string GetScriptFromSite(string siteUrl, IReadOnlyDictionary<string, object> serializationInfo)
    {
        _ = siteUrl ?? throw new ArgumentNullException(nameof(siteUrl));
        _ = serializationInfo ?? throw new ArgumentNullException(nameof(serializationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "GetSiteScriptFromSite",
                requestPayload.CreateParameter(siteUrl),
                requestPayload.CreateParameter(new TenantSiteScriptSerializationInfo(serializationInfo))));
        var clientObject = this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteScriptSerializationResult>(requestPayload.GetActionId<ClientActionMethod>());
        if (clientObject.Warnings.Any())
        {
            throw new InvalidOperationException(clientObject.Warnings.FirstOrDefault());
        }
        return clientObject.Json;
    }

}
