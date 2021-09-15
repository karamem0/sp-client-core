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

    [Cmdlet("Get", "KshFile")]
    [OutputType(typeof(File))]
    public class GetFileCommand : ClientObjectCmdlet<IFileService>
    {

        public GetFileCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public File Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public AttachmentFile AttachmentFile { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
        public FileVersion FileVersion { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet4")]
        public App App { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
        public Guid FileId { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
        public Uri FileUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet7")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
        public Folder Folder { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet7")]
        public string FileName { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet8")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                var fileUrl = new Uri(this.AttachmentFile.ServerRelativeUrl, UriKind.RelativeOrAbsolute);
                if (fileUrl.IsAbsoluteUri)
                {
                    outputs.Add(this.Service.GetObject(new Uri(fileUrl.AbsolutePath, UriKind.Relative)));
                }
                else
                {
                    outputs.Add(this.Service.GetObject(fileUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                outputs.Add(this.Service.GetObject(this.FileVersion));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                outputs.Add(this.Service.GetObject(this.App));
            }
            if (this.ParameterSetName == "ParamSet5")
            {
                outputs.Add(this.Service.GetObject(this.FileId));
            }
            if (this.ParameterSetName == "ParamSet6")
            {
                if (this.FileUrl.IsAbsoluteUri)
                {
                    outputs.Add(this.Service.GetObject(new Uri(this.FileUrl.AbsolutePath, UriKind.Relative)));
                }
                else
                {
                    outputs.Add(this.Service.GetObject(this.FileUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet7")
            {
                outputs.Add(this.Service.GetObject(this.Folder, this.FileName));
            }
            if (this.ParameterSetName == "ParamSet8")
            {
                if (this.NoEnumerate)
                {
                    outputs.Add(this.Service.GetObjectEnumerable(this.Folder));
                }
                else
                {
                    outputs.AddRange(this.Service.GetObjectEnumerable(this.Folder));
                }
            }
        }

    }

}
