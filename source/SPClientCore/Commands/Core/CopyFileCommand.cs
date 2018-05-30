//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("Copy", "SPFile")]
    [OutputType(typeof(File))]
    public class CopyFileCommand : PSCmdlet
    {

        public CopyFileCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0)]
        public FilePipeBind File { get; private set; }

        [Parameter(Mandatory = true)]
        public string ServerRelativeUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var fileQuery = ODataQuery.Create<File>(this.MyInvocation.BoundParameters);
            var file = fileService.GetFile(this.File);
            fileService.CopyFileTo(file.ServerRelativeUrl, this.ServerRelativeUrl, this.Overwrite);
            if (this.PassThru)
            {
                this.WriteObject(fileService.GetFile(new FilePipeBind(this.ServerRelativeUrl), fileQuery));
            }
        }

    }

}
