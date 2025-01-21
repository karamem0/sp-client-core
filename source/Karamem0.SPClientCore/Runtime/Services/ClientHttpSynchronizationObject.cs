//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientHttpSynchronizationObject
{

    public static readonly ClientHttpSynchronizationObject Completed = new(null, null);

    private ClientHttpSynchronizationObject()
    {
    }

    public ClientHttpSynchronizationObject(SendOrPostCallback callback, object state)
    {
        this.Callback = callback;
        this.State = state;
    }

    public SendOrPostCallback Callback { get; private set; }

    public object State { get; private set; }

}
