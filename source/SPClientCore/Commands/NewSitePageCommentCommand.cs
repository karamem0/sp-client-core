//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
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

    [Cmdlet("New", "KshSitePageComment")]
    [OutputType(typeof(SitePageComment))]
    public class NewSitePageCommentCommand : ClientObjectCmdlet<ISitePageCommentService>
    {

        public NewSitePageCommentCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public ListItem ListItem { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public SitePageComment Comment { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public string Text { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.WriteObject(this.Service.CreateObject(this.ListItem, this.MyInvocation.BoundParameters));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.WriteObject(this.Service.CreateObject(this.Comment, this.MyInvocation.BoundParameters));
            }
        }

    }

}
