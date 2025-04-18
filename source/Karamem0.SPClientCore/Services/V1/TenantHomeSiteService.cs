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

public interface ITenantHomeSiteService
{

    Uri GetObject();

    void RemoveObject();

    void SetObject(Uri homeSiteUrl);

}

public class TenantHomeSiteService(ClientContext clientContext) : ClientService(clientContext), ITenantHomeSiteService
{

    public Uri GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => new ClientActionMethod(objectPathId, "GetSPHSiteUrl"));
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Uri>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public void RemoveObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => new ClientActionMethod(objectPathId, "RemoveSPHSite"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(Uri homeSiteUrl)
    {
        _ = homeSiteUrl ?? throw new ArgumentNullException(nameof(homeSiteUrl));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathConstructor(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetSPHSite",
                requestPayload.CreateParameter(homeSiteUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
