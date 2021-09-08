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

    [Cmdlet("Get", "KshTermLabel")]
    [OutputType(typeof(TermLabel))]
    public class GetTermLabelCommand : ClientObjectCmdlet<ITermLabelService>
    {

        public GetTermLabelCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public TermLabel Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public Term Term { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public string LabelName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                outputs.Add(this.Service.GetObject(this.Term, this.LabelName));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.Term));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.Term));
                }
            }
        }

    }

}
