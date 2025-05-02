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

public interface ITenantSiteTemplateService
{

    IEnumerable<TenantSiteTemplate>? GetObjectEnumerable(uint lcid, int compatibilityLevel);

    IEnumerable<TenantSiteTemplate>? GetObjectEnumerable();

}

public class TenantSiteTemplateService(ClientContext clientContext) : ClientService(clientContext), ITenantSiteTemplateService
{

    public IEnumerable<TenantSiteTemplate>? GetObjectEnumerable(uint lcid, int compatibilityLevel)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetSPOTenantWebTemplates",
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(compatibilityLevel)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Empty
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TenantSiteTemplate>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetSPOTenantAllWebTemplates"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Empty
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantSiteTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
