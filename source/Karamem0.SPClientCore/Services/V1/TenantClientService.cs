//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public abstract class TenantClientService(ClientContext clientContext) : ClientService(clientContext)
{

    public void WaitObject(TenantOperationResult operationResultObject)
    {
        while (true)
        {
            Thread.Sleep(operationResultObject.PollingInterval);
            if (operationResultObject.IsComplete)
            {
                Thread.Sleep(TimeSpan.FromSeconds(ClientConstants.TenantServiceWaitSeconds));
                break;
            }
            if (operationResultObject.HasTimedout)
            {
                throw new InvalidOperationException(StringResources.ErrorOperationTimeout);
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(operationResultObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantOperationResult))
                });
            operationResultObject = this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantOperationResult>(requestPayload.GetActionId<ClientActionQuery>());
        }
    }

}
