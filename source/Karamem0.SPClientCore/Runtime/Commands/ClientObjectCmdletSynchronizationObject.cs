//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Runtime.Services;

public class ClientObjectCmdletSynchronizationObject(SendOrPostCallback callback, object state)
{

    public static readonly ClientObjectCmdletSynchronizationObject Completed = new((state) => { }, new object());

    public SendOrPostCallback Callback { get; private set; } = callback;

    public object State { get; private set; } = state;

}
