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

public interface ITenantSiteDesignService
{

    TenantSiteDesign AddObject(IReadOnlyDictionary<string, object> creationInfo);

    TenantSiteDesign GetObject(Guid? siteDesignId);

    IEnumerable<TenantSiteDesign> GetObjectEnumerable();

    void RemoveObject(TenantSiteDesign siteDesignObject);

}

public class TenantSiteDesignService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteDesignService
{

    public TenantSiteDesign AddObject(IReadOnlyDictionary<string, object> creationInfo)
    {
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "CreateSiteDesign",
                requestPayload.CreateParameter(new TenantSiteDesignCreationInfo(creationInfo))),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(TenantSiteDesign))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteDesign>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TenantSiteDesign GetObject(Guid? siteDesignId)
    {
        _ = siteDesignId ?? throw new ArgumentNullException(nameof(siteDesignId));
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            new ClientActionStaticMethod(
                typeof(Tenant),
                "GetSiteDesign",
                requestPayload.CreateParameter(siteDesignId)
            ));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteDesign>(requestPayload.GetActionId<ClientActionStaticMethod>());
    }

    public IEnumerable<TenantSiteDesign> GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath1.Id,
                "GetSiteDesigns"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(TenantSiteDesign))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<TenantSiteDesignEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(TenantSiteDesign siteDesignObject)
    {
        _ = siteDesignObject ?? throw new ArgumentNullException(nameof(siteDesignObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "DeleteSiteDesign",
                requestPayload.CreateParameter(siteDesignObject.Id)));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
