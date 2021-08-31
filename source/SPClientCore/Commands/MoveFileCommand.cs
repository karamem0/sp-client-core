//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
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

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public File Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        public Uri NewUrl { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter Overwrite { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter KeepBoth { get; protected set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter ResetAuthorAndCreatedOnCopy { get; protected set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter RetainEditorAndModifiedOnMove { get; protected set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter ShouldBypassSharedLocks { get; protected set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter Legacy { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter AllowBrokenThickets { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter BypassApprovePermission { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                if (this.NewUrl.IsAbsoluteUri)
                {
                    var moveCopyOptions = new MoveCopyOptions(this.MyInvocation.BoundParameters);
                    this.Service.MoveObject(this.Identity, this.NewUrl, this.Overwrite, moveCopyOptions);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.NewUrl),
                        nameof(this.NewUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                var moveOperations = FlagsParser.Parse<MoveOperations>(this.MyInvocation.BoundParameters);
                if (this.NewUrl.IsAbsoluteUri)
                {
                    var newUrl = new Uri(this.NewUrl.AbsolutePath, UriKind.Relative);
                    this.Service.MoveObject(this.Identity, newUrl, moveOperations);
                    if (this.PassThru)
                    {
                        this.WriteObject(this.Service.GetObject(newUrl));
                    }
                }
                else
                {
                    this.Service.MoveObject(this.Identity, this.NewUrl, moveOperations);
                    if (this.PassThru)
                    {
                        this.WriteObject(this.Service.GetObject(this.NewUrl));
                    }
                }
            }
        }

    }

}
