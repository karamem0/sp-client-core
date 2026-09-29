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

public abstract class TenantClientService(ClientContext clientContext) : ClientService(clientContext)
{

    public async Task WaitObjectAsync(TenantOperationResult? operationResultObject, bool selectAllProperties = true)
    {
        while (true)
        {
            _ = operationResultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            await Task.Delay(operationResultObject.PollingInterval);
            if (operationResultObject.IsComplete)
            {
                await Task.Delay(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTenantService));
                break;
            }
            if (operationResultObject.HasTimedout)
            {
                throw new InvalidOperationException(StringResources.ErrorOperationTimeout);
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                ObjectPathIdentity.Create(operationResultObject.ObjectIdentity),
                ClientActionInstantiateObjectPath.Create,
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantOperationResult)))
            );
            operationResultObject = await this
                .ClientContext.ProcessQueryAsync(requestPayload)
                .ContinueWith(task => task.Result.ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>()));
        }
    }

}
