//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    public abstract class ClientObjectCmdlet : PSCmdlet
    {

        private TraceListener traceListener;

        protected ClientObjectCmdlet()
        {
            this.traceListener = new ClientObjectTraceListener(this);
        }

        protected override void BeginProcessing()
        {
            Trace.Listeners.Add(this.traceListener);
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            Trace.Listeners.Remove(this.traceListener);
        }

    }

}
