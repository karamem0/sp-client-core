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

[Cmdlet(VerbsCommon.Get, "File")]
[OutputType(typeof(File))]
public class GetFileCommand : ClientObjectCmdlet<IFileService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public File? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public AttachmentFile? AttachmentFile { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public FileVersion? FileVersion { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public App? App { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet5"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public Guid FileId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public Uri? FileUrl { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet8"
    )]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet9")]
    public Folder? Folder { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
    public string? FileName { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.AttachmentFile?.ServerRelativeUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.AttachmentFile));
            this.Outputs.Add(this.Service.GetObject(this.AttachmentFile.ServerRelativeUrl));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.FileVersion ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileVersion));
            this.Outputs.Add(this.Service.GetObject(this.FileVersion));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.App ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.App));
            this.Outputs.Add(this.Service.GetObject(this.App));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            this.Outputs.Add(this.Service.GetObject(this.FileId));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            _ = this.FileUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileUrl));
            if (this.FileUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetObject(new Uri(this.FileUrl.AbsolutePath, UriKind.Relative)));
            }
            else
            {
                this.Outputs.Add(this.Service.GetObject(this.FileUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            _ = this.FileName ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.FileName));
            this.Outputs.Add(this.Service.GetObject(this.Folder, this.FileName));
        }
        if (this.ParameterSetName == "ParamSet9")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Folder));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Folder));
            }
        }
    }

}
