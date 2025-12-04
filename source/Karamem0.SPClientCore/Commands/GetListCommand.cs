//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "List")]
[OutputType(typeof(List))]
public class GetListCommand : ClientObjectCmdlet<IListService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public List? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public Models.V1.Folder? Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public Models.V1.File? File { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet5"
    )]
    public View? View { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet6"
    )]
    public Drive? Drive { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public Guid ListId { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet8")]
    public Uri? ListUrl { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet9")]
    public string? ListTitle { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet10")]
    public LibraryType LibraryType { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet11")]
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
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            this.Outputs.Add(this.Service.GetObject(this.Folder));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            this.Outputs.Add(this.Service.GetObject(this.File));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.View ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.View));
            this.Outputs.Add(this.Service.GetObject(this.View));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            _ = this.Drive ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Drive));
            this.Outputs.Add(this.Service.GetObject(this.Drive));
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            this.Outputs.Add(this.Service.GetObject(this.ListId));
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            _ = this.ListUrl ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListUrl));
            if (this.ListUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetObject(new Uri(this.ListUrl.AbsolutePath, UriKind.Relative)));
            }
            else
            {
                this.Outputs.Add(this.Service.GetObject(this.ListUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet9")
        {
            _ = this.ListTitle ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListTitle));
            this.Outputs.Add(this.Service.GetObject(this.ListTitle));
        }
        if (this.ParameterSetName == "ParamSet10")
        {
            this.Outputs.Add(this.Service.GetObject(this.LibraryType));
        }
        if (this.ParameterSetName == "ParamSet11")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}
