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

[Cmdlet(VerbsCommon.Add, "KshSiteFeature")]
[OutputType(typeof(void))]
public class AddSiteFeatureCommand : ClientObjectCmdlet<ISiteFeatureService>
{

    [Parameter(Mandatory = true)]
    public Guid FeatureId { get; private set; }

    [Parameter(Mandatory = false)]
    public bool Force { get; private set; }

    [Parameter(Mandatory = false)]
    public FeatureDefinitionScope Scope { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service.AddObject(
            this.FeatureId,
            this.Force,
            this.Scope
        );
    }

}
