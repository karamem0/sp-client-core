//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands;

public class ClientObjectCmdletTraceListener(Cmdlet cmdlet) : TraceListener
{

    private readonly List<string> messages = [];

    private readonly Cmdlet cmdlet = cmdlet;

    public override void Write(string message)
    {
        this.messages.Add(message);
    }

    public override void WriteLine(string message)
    {
        this.messages.Add(message);
    }

    public override void Flush()
    {
        this.messages.ForEach(this.cmdlet.WriteVerbose);
    }

}
