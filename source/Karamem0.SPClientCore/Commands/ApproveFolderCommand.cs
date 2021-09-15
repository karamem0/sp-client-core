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

    [Cmdlet("Approve", "KshFolder")]
    [OutputType(typeof(Folder))]
    public class ApproveFolderCommand : ClientObjectCmdlet<IFolderService>
    {

        public ApproveFolderCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Folder Identity { get; private set; }

        [Parameter(Mandatory = false)]
        public string Comment { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            this.Service.ApproveObject(this.Identity, this.Comment);
            if (this.PassThru)
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
        }

    }

}
