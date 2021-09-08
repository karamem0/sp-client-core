//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshTenantSiteTemplate")]
    [OutputType(typeof(TenantSiteTemplate))]
    public class GetTenantSiteTemplateCommand : ClientObjectCmdlet<ITenantSiteTemplateService>
    {

        public GetTenantSiteTemplateCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public int CompatibilityLevel { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public uint Lcid { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.Lcid, this.CompatibilityLevel));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.Lcid, this.CompatibilityLevel));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable());
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable());
                }
            }
        }

    }

}
