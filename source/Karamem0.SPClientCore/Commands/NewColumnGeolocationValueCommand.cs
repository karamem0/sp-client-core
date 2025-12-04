//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.New, "ColumnGeolocationValue")]
[OutputType(typeof(ColumnGeolocationValue))]
public class NewColumnGeolocationValueCommand : ClientObjectCmdlet
{

    [Parameter(Mandatory = false)]
    public double Altitude { get; private set; }

    [Parameter(Mandatory = true)]
    public double Latitude { get; private set; }

    [Parameter(Mandatory = true)]
    public double Longitude { get; private set; }

    [Parameter(Mandatory = false)]
    public double Measure { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Outputs.Add(
            new ColumnGeolocationValue(
                this.Altitude,
                this.Latitude,
                this.Longitude,
                this.Measure
            )
        );
    }

}
