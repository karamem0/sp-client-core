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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantHomeSiteService
{

    Uri? GetObject();

    void RemoveObject();

    void SetObject(Uri homeSiteUrl);

}

public class TenantHomeSiteService(ClientContext clientContext) : ClientService(clientContext), ITenantHomeSiteService
{

    public Uri? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "GetSPHSiteUrl"));
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Uri>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public void RemoveObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "RemoveSPHSite"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(Uri homeSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetSPHSite",
                requestPayload.CreateParameter(homeSiteUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
