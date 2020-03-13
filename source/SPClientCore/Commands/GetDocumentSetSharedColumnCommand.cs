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

    [Cmdlet("Get", "KshDocumentSetSharedColumn")]
    [OutputType(typeof(Column))]
    public class GetDocumentSetSharedColumnCommand : ClientObjectCmdlet<IDocumentSetSharedColumnService>
    {

        public GetDocumentSetSharedColumnCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public ContentType ContentType { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(this.Service.GetObjectEnumerable(this.ContentType), this.NoEnumerate ? false : true);
        }

    }

}
