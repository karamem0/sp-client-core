//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    public class ClientObjectTraceListener : TraceListener
    {

        private readonly ClientObjectCmdlet cmdlet;

        public ClientObjectTraceListener(ClientObjectCmdlet cmdlet)
        {
            if (cmdlet == null)
            {
                throw new ArgumentNullException(nameof(cmdlet));
            }
            this.cmdlet = cmdlet;
        }

        public override void Write(string message)
        {
            this.cmdlet.WriteVerbose(message);
        }

        public override void WriteLine(string message)
        {
            this.cmdlet.WriteVerbose(message);
        }

    }

}
