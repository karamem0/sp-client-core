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

    [Cmdlet("Get", "SPFileVersion")]
    [OutputType(typeof(FileVersion))]
    public class GetFileVersionCommand : PSCmdlet
    {

        public GetFileVersionCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public FilePipeBind File { get; private set; }

        [Parameter(Mandatory = true)]
        public FileVersionPipeBind FileVersion { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var fileVersionService = ClientObjectService.ServiceProvider.GetService<IFileVersionService>();
            var fileVersionQuery = ODataQuery.Create<FileVersion>(this.MyInvocation.BoundParameters);
            var fileService = ClientObjectService.ServiceProvider.GetService<IFileService>();
            var file = fileService.GetFile(this.File);
            this.WriteObject(fileVersionService.GetFileVersion(file.ServerRelativeUrl, this.FileVersion, fileVersionQuery));
        }

    }

}
