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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshTenantDeletedPersonalSiteCollection")]
[OutputType(typeof(TenantDeletedSiteCollection))]
public class
    GetTenantDeletedPersonalSiteCollectionCommand : ClientObjectCmdlet<ITenantDeletedPersonalSiteCollectionService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet1"
    )]
    public Uri SiteCollectionUrl { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            if (this.SiteCollectionUrl.IsAbsoluteUri)
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.SiteCollectionUrl));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.SiteCollectionUrl));
                }
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl)
                );
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}
