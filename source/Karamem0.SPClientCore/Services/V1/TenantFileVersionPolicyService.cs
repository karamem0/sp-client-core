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

public interface ITenantFileVersionPolicyService
{

    void SetObject(
        bool isAutoTrimEnabled,
        int majorVersionLimit,
        int expireVersionsAfterDays
    );

}

public class TenantFileVersionPolicyService(ClientContext clientContext) : TenantClientService(clientContext), ITenantFileVersionPolicyService
{

    public void SetObject(
        bool isAutoTrimEnabled,
        int majorVersionLimit,
        int expireVersionsAfterDays
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFileVersionPolicy",
                requestPayload.CreateParameter(isAutoTrimEnabled),
                requestPayload.CreateParameter(majorVersionLimit),
                requestPayload.CreateParameter(expireVersionsAfterDays)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
