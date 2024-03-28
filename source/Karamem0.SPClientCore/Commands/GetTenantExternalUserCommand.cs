//
// Copyright (c) 2018-2024 karamem0
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

[Cmdlet(VerbsCommon.Get, "KshTenantExternalUser")]
[OutputType(typeof(ExternalUser))]
public class GetTenantExternalUserCommand : ClientObjectCmdlet<ITenantExternalUserService>
{

    public GetTenantExternalUserCommand()
    {
    }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
    public string SiteCollectionUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public string Filter { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SortOrder SortOrder { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.SiteCollectionUrl, this.Filter, this.SortOrder));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.SiteCollectionUrl, this.Filter, this.SortOrder));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Filter, this.SortOrder));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Filter, this.SortOrder));
            }
        }
    }

}
