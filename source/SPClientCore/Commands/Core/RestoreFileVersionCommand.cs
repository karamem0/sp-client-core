//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

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

    [Cmdlet("Restore", "SPFileVersion")]
    [OutputType(typeof(void))]
    public class RestoreFileVersionCommand : PSCmdlet
    {

        public RestoreFileVersionCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FilePipeBind File { get; private set; }

        [Parameter(Mandatory = true)]
        public FileVersionPipeBind FileVersion { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fileVersionService = ClientObjectService.ServiceProvider.GetService<IFileVersionService>();
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var file = fileService.GetFile(this.File);
            var fileVersion = fileVersionService.GetFileVersion(file.ServerRelativeUrl, this.FileVersion);
            fileVersionService.RestoreFileVersion(file.ServerRelativeUrl, fileVersion.VersionLabel);
        }

    }

}
