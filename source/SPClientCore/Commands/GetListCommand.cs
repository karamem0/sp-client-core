//
// Copyright (c) 2019 karamem0
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

    [Cmdlet("Get", "KshList")]
    [OutputType(typeof(List))]
    public class GetListCommand : ClientObjectCmdlet<IListService>
    {

        public GetListCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public List Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public ListItem ListItem { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public Guid ListId { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
        public Uri ListUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
        public string ListTitle { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.WriteObject(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.WriteObject(this.Service.GetObject(this.ListItem));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.WriteObject(this.Service.GetObject(this.ListId));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                if (this.ListUrl.IsAbsoluteUri)
                {
                    this.WriteObject(this.Service.GetObject(new Uri(this.ListUrl.AbsolutePath, UriKind.Relative)));
                }
                else
                {
                    this.WriteObject(this.Service.GetObject(this.ListUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                this.WriteObject(this.Service.GetObject(this.ListTitle));
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                this.WriteObject(this.Service.GetObjectEnumerable(), this.NoEnumerate ? false : true);
            }
        }

    }

}
