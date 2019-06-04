//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Move", "KshFile")]
    [OutputType(typeof(File))]
    public class MoveFileCommand : ClientObjectCmdlet<IFileService>
    {

        public MoveFileCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public File Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 1)]
        public Uri Url { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter AllowBrokenThickets { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter BypassApprovePermission { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            var moveOperations = FlagsParser.Parse<MoveOperations>(this.MyInvocation.BoundParameters);
            if (this.Url.IsAbsoluteUri)
            {
                this.Service.MoveObject(this.Identity, new Uri(this.Url.AbsolutePath, UriKind.Relative), moveOperations);
            }
            else
            {
                this.Service.MoveObject(this.Identity, this.Url, moveOperations);
            }
            if (this.PassThru)
            {
                this.WriteObject(this.Service.GetObject(this.Url));
            }
        }

    }

}
