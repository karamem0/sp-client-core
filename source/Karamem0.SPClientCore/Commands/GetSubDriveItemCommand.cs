//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V2;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "SubDriveItem")]
[OutputType(typeof(DriveItem))]
public class GetSubDriveItemCommand : ClientObjectCmdlet<IDriveItemService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public Drive? Drive { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public DriveItem? DriveItem { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Drive ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Drive));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.Drive));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.Drive));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.DriveItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.DriveItem));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable(this.DriveItem));
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable(this.DriveItem));
            }
        }
    }

}
