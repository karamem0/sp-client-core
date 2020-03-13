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

    [Cmdlet("Remove", "KshDocumentSetAllowedContentType")]
    [OutputType(typeof(void))]
    public class RemoveDocumentSetAllowedContentTypeCommand : ClientObjectCmdlet<IDocumentSetAllowedContentTypeService>
    {

        public RemoveDocumentSetAllowedContentTypeCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = true)]
        public ContentType AllowedContentType { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PushChanges { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.RemoveObject(this.ContentType, this.AllowedContentType, this.PushChanges);
        }

    }

}
