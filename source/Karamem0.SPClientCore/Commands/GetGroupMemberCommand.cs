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

    [Cmdlet("Get", "KshGroupMember")]
    [OutputType(typeof(User))]
    public class GetGroupMemberCommand : ClientObjectCmdlet<IGroupMemberService>
    {

        public GetGroupMemberCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public Group Group { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        public int MemberId { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public string MemberName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Group, this.MemberId));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                outputs.Add(this.Service.GetObject(this.Group, this.MemberName));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.Group));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.Group));
                }
            }
        }

    }

}
