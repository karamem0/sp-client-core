//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshTenantTheme")]
[OutputType(typeof(TenantTheme))]
public class AddTenantThemeCommand : ClientObjectCmdlet<ITenantThemeService>
{

    [Parameter(Mandatory = true)]
    public bool IsInverted { get; private set; }

    [Parameter(Mandatory = true)]
    public string? Name { get; private set; }

    [Parameter(Mandatory = true)]
    public Hashtable? Palette { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Name ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Name));
        _ = this.Service.AddObject(this.Name, this.MyInvocation.BoundParameters);
        this.Outputs.Add(this.Service.GetObject(this.Name));
    }

}
