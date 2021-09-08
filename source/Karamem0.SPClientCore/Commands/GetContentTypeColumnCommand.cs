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

    [Cmdlet("Get", "KshContentTypeColumn")]
    [OutputType(typeof(ContentTypeColumn))]
    public class GetContentTypeColumnCommand : ClientObjectCmdlet<IContentTypeColumnService>
    {

        public GetContentTypeColumnCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public ContentTypeColumn Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public Column Column { get; private set; }

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
                outputs.Add(this.Service.GetObject(this.ContentType, this.Column.Id));
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.ContentType));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.ContentType));
                }
            }
        }

    }

}
