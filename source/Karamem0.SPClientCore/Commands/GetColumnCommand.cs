//
// Copyright (c) 2023 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshColumn")]
    [OutputType(typeof(ContentType))]
    public class GetColumnCommand : ClientObjectCmdlet<IColumnService>
    {

        public GetColumnCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public Column Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
        public List List { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet5")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet8")]
        public Guid ColumnId { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet6")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet9")]
        public string ColumnTitle { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet7")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet10")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.Outputs.Add(this.Service.GetObject(this.ContentType, this.ColumnId));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.Outputs.Add(this.Service.GetObject(this.ContentType, this.ColumnTitle));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.ContentType));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.ContentType));
                }
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                this.Outputs.Add(this.Service.GetObject(this.List, this.ColumnId));
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                this.Outputs.Add(this.Service.GetObject(this.List, this.ColumnTitle));
            }
            if (this.ParameterSetName == "ParamSet7")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.GetObjectEnumerable(this.List));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.List));
                }
            }
            if (this.ParameterSetName == "ParamSet8")
            {
                this.Outputs.Add(this.Service.GetObject(this.ColumnId));
            }
            if (this.ParameterSetName == "ParamSet9")
            {
                this.Outputs.Add(this.Service.GetObject(this.ColumnTitle));
            }
            if (this.ParameterSetName == "ParamSet10")
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

}
