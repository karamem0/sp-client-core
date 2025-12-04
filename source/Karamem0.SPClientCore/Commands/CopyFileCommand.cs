//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Copy, "File")]
[OutputType(typeof(File))]
public class CopyFileCommand : ClientObjectCmdlet<IFileService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public File? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet1"
    )]
    [Parameter(
        Mandatory = true,
        Position = 1,
        ParameterSetName = "ParamSet2"
    )]
    public Uri? NewUrl { get; private set; }

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
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.NewUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.NewUrl));
            if (this.NewUrl.IsAbsoluteUri)
            {
                _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
                this.Service.CopyObject(
                    this.Identity,
                    this.NewUrl,
                    this.Overwrite,
                    this.MyInvocation.BoundParameters
                );
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.NewUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Legacy));
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            _ = this.NewUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.NewUrl));
            if (this.NewUrl.IsAbsoluteUri)
            {
                var newUrl = new Uri(this.NewUrl.AbsolutePath, UriKind.Relative);
                this.Service.CopyObject(
                    this.Identity,
                    newUrl,
                    this.Overwrite
                );
                if (this.PassThru)
                {
                    this.Outputs.Add(this.Service.GetObject(newUrl));
                }
            }
            else
            {
                this.Service.CopyObject(
                    this.Identity,
                    this.NewUrl,
                    this.Overwrite
                );
                if (this.PassThru)
                {
                    this.Outputs.Add(this.Service.GetObject(this.NewUrl));
                }
            }
        }
    }

}
