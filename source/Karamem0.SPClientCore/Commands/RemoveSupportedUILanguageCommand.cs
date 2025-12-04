//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Remove, "SupportedUILanguage")]
[OutputType(typeof(void))]
public class RemoveSupportedUILanguageCommand : ClientObjectCmdlet<IRegionalSettingsService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true
    )]
    public uint Lcid { get; private set; }

    protected override void ProcessRecordCore()
    {
        this.Service.RemoveSupportedUILanguage(this.Lcid);
    }

}
