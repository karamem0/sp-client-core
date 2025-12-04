//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public abstract class TenantClientService(ClientContext clientContext) : ClientService(clientContext)
{

    public void WaitObject(TenantOperationResult? operationResultObject)
    {
        while (true)
        {
            _ = operationResultObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
            Thread.Sleep(operationResultObject.PollingInterval);
            if (operationResultObject.IsComplete)
            {
                Thread.Sleep(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTenantService));
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
                objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantOperationResult)))
            );
            operationResultObject = this
                .ClientContext.ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

}
