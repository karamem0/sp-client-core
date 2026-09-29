//
// Copyright (c) 2018-2026 karamem0
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
using Karamem0.SharePoint.PowerShell.Services.V2;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "Drive")]
[OutputType(typeof(Drive))]
public class GetDriveCommand : ClientObjectCmdlet<IDriveService, ISiteCollectionService, ISiteService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public Drive? Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public List? List { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string? DriveId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Identity ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Identity));
            this.Outputs.Add(await this.Service1.GetObjectAsync(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.List ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.List));
            var siteCollectionObject = await this.Service2.GetObjectAsync();
            var siteObject = await this.Service3.GetObjectAsync();
            this.Outputs.Add(
                await this.Service1.GetObjectAsync(
                    siteCollectionObject?.Id ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull),
                    siteObject?.Id ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull),
                    this.List.Id
                )
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.DriveId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.DriveId));
            this.Outputs.Add(await this.Service1.GetObjectAsync(this.DriveId));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(await this.Service1.GetObjectEnumerableAsync());
            }
            else
            {
                this.Outputs.AddRange(await this.Service1.GetObjectEnumerableAsync());
            }
        }
    }

}
