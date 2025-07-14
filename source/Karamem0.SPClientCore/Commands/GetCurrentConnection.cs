//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshCurrentConnection")]
[OutputType(typeof(ClientContext))]
public class GetCurrentConnectionCommand : ClientObjectCmdlet
{

    protected override void ProcessRecordCore()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.Outputs.Add(ClientService.ServiceProvider.GetService<ClientContext>());
    }

}
