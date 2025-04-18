//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Add, "KshView")]
[OutputType(typeof(View))]
public class AddViewCommand : ClientObjectCmdlet<IViewService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public List List { get; private set; }

    [Parameter(Mandatory = false)]
    public int BaseViewId { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Paged { get; private set; }

    [Parameter(Mandatory = false)]
    public bool PersonalView { get; private set; }

    [Parameter(Mandatory = false)]
    public int RowLimit { get; private set; }

    [Parameter(Mandatory = false)]
    public bool SetAsDefaultView { get; private set; }

    [Parameter(Mandatory = true)]
    public string Title { get; private set; }

    [Parameter(Mandatory = false)]
    public string[] ViewColumns { get; private set; }

    [Parameter(Mandatory = false)]
    public string ViewQuery { get; private set; }

    [Parameter(Mandatory = false)]
    public ViewType ViewType { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(this.Service.AddObject(this.List, this.MyInvocation.BoundParameters));
    }

}
