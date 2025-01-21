//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientHttpSynchronizationContext : SynchronizationContext
{

    private readonly BlockingCollection<ClientHttpSynchronizationObject> collection;

    public ClientHttpSynchronizationContext()
    {
        this.collection = [];
    }

    public override void Post(SendOrPostCallback d, object state)
    {
        this.collection.Add(new ClientHttpSynchronizationObject(d, state));
    }

    public void Wait()
    {
        while (this.collection.TryTake(out var value, Timeout.Infinite))
        {
            if (value == ClientHttpSynchronizationObject.Completed)
            {
                break;
            }
            value?.Callback(value.State);
        }
    }

    public void Complete()
    {
        this.collection.Add(ClientHttpSynchronizationObject.Completed);
    }

}
