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

public interface ITenantOrganizationNewsSiteService
{

    void AddObject(Uri organizationNewsSiteUrl);

    IEnumerable<Uri>? GetObjectEnumerable();

    void RemoveObject(Uri organizationNewsSiteUrl);

}

public class TenantOrganizationNewsSiteService(ClientContext clientContext) : ClientService(clientContext), ITenantOrganizationNewsSiteService
{

    public void AddObject(Uri organizationNewsSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetOrgNewsSite",
                requestPayload.CreateParameter(organizationNewsSiteUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<Uri>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "GetOrgNewsSites"));
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<IEnumerable<Uri>>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public void RemoveObject(Uri organizationNewsSiteUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveOrgNewsSite",
                requestPayload.CreateParameter(organizationNewsSiteUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
