//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantCdnService
{

    Task AddOriginAsync(TenantCdnType cdnType, string cdnOrigin);

    Task<bool> GetEnabledAsync(TenantCdnType cdnType);

    Task<IEnumerable<string>?> GetOriginEnumerableAsync(TenantCdnType cdnType);

    Task<IEnumerable<string>?> GetPolicyEnumerableAsync(TenantCdnType cdnType);

    Task SetEnabledAsync(
        TenantCdnType cdnType,
        bool cdnEnabled,
        bool noDefaultOrigins
    );

    Task SetPolicyAsync(
        TenantCdnType cdnType,
        TenantCdnPolicyType cdnPolicyType,
        string cdnPolicyValue
    );

    Task RemoveOriginAsync(TenantCdnType cdnType, string cdnOrigin);

}

public class TenantCdnService(ClientContext clientContext) : ClientService(clientContext), ITenantCdnService
{

    public async Task AddOriginAsync(TenantCdnType cdnType, string cdnOrigin)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "AddTenantCdnOrigin",
                requestPayload.CreateParameter(cdnType),
                requestPayload.CreateParameter(cdnOrigin)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<bool> GetEnabledAsync(TenantCdnType cdnType)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetTenantCdnEnabled",
                requestPayload.CreateParameter(cdnType)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<IEnumerable<string>?> GetOriginEnumerableAsync(TenantCdnType cdnType)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetTenantCdnOrigins",
                requestPayload.CreateParameter(cdnType)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<IEnumerable<string>>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<IEnumerable<string>?> GetPolicyEnumerableAsync(TenantCdnType cdnType)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "GetTenantCdnPolicies",
                requestPayload.CreateParameter(cdnType)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<IEnumerable<string>>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task SetEnabledAsync(
        TenantCdnType cdnType,
        bool cdnEnabled,
        bool noDefaultOrigins
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetTenantCdnEnabled",
                requestPayload.CreateParameter(cdnType),
                requestPayload.CreateParameter(cdnEnabled)
            )
        );
        if (noDefaultOrigins)
        {
        }
        else
        {
            var objectPath3 = requestPayload.Add(
                objectPath1,
                objectPathId => ClientActionMethod.Create(
                    objectPathId,
                    "CreateTenantCdnDefaultOrigins",
                    requestPayload.CreateParameter(cdnType)
                )
            );
        }
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetPolicyAsync(
        TenantCdnType cdnType,
        TenantCdnPolicyType cdnPolicyType,
        string cdnPolicyValue
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetTenantCdnPolicy",
                requestPayload.CreateParameter(cdnType),
                requestPayload.CreateParameter(cdnPolicyType),
                requestPayload.CreateParameter(cdnPolicyValue)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task RemoveOriginAsync(TenantCdnType cdnType, string cdnOrigin)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveTenantCdnOrigin",
                requestPayload.CreateParameter(cdnType),
                requestPayload.CreateParameter(cdnOrigin)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
