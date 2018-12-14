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

    [Cmdlet("Update", "KshContentTypeColumn")]
    [OutputType(typeof(ContentTypeColumn))]
    public class UpdateContentTypeColumnCommand : ClientObjectCmdlet<IContentTypeColumnService>
    {

        public UpdateContentTypeColumnCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = true, Position = 1)]
        public ContentTypeColumn ContentTypeColumn { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Hidden { get; private set; }

        [Parameter(Mandatory = false)]
        public bool Required { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PushChanges { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.UpdateObject(this.ContentType, this.ContentTypeColumn, this.MyInvocation.BoundParameters, this.PushChanges);
            if (this.PassThru)
            {
                this.WriteObject(this.Service.GetObject(this.ContentTypeColumn));
            }
        }

    }

}
