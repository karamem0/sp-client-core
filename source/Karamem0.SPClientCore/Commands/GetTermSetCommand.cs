//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
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

    [Cmdlet("Get", "KshTermSet")]
    [OutputType(typeof(TermSet))]
    public class GetTermSetCommand : ClientObjectCmdlet<ITermSetService>
    {

        public GetTermSetCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public TermSet Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
        public TermGroup TermGroup { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public Guid TermSetId { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet3")]
        public string TermSetName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                outputs.Add(this.Service.GetObject(this.TermGroup, this.TermSetId));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                outputs.Add(this.Service.GetObject(this.TermGroup, this.TermSetName));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.TermGroup));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.TermGroup));
                }
            }
        }

    }

}
