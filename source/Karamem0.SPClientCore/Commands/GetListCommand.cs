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

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
        public View View { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet4")]
        public Guid ListId { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
        public Uri ListUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
        public string ListTitle { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet7")]
        public LibraryType LibraryType { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                outputs.Add(this.Service.GetObject(this.ListItem));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                outputs.Add(this.Service.GetObject(this.View));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                outputs.Add(this.Service.GetObject(this.ListId));
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                if (this.ListUrl.IsAbsoluteUri)
                {
                    outputs.Add(this.Service.GetObject(new Uri(this.ListUrl.AbsolutePath, UriKind.Relative)));
                }
                else
                {
                    outputs.Add(this.Service.GetObject(this.ListUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                outputs.Add(this.Service.GetObject(this.ListTitle));
            }
            if (this.ParameterSetName == "ParamSet7")
            {
                outputs.Add(this.Service.GetObject(this.LibraryType));
            }
            if (this.ParameterSetName == "ParamSet8")
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
