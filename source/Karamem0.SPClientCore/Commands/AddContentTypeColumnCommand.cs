//
// Copyright (c) 2022 karamem0
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

    [Cmdlet("Add", "KshContentTypeColumn")]
    [Alias("New-KshContentTypeColumn")]
    [OutputType(typeof(ContentTypeColumn))]
    public class AddContentTypeColumnCommand : ClientObjectCmdlet<IContentTypeColumnService>
    {

        public AddContentTypeColumnCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = true)]
        public Column Column { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PushChanges { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Outputs.Add(this.Service.AddObject(this.ContentType, this.MyInvocation.BoundParameters, this.PushChanges));
        }

    }

}
