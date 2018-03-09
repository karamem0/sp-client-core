//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Open", "SPFile")]
    [OutputType(typeof(System.IO.Stream))]
    public class OpenFileCommand : PSCmdlet
    {

        public OpenFileCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FilePipeBind File { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var file = fileService.GetFile(this.File);
            this.WriteObject(fileService.OpenFile(file.ServerRelativeUrl));
        }

    }

}
