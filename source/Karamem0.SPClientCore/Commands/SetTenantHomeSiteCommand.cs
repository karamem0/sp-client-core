//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "TenantHomeSite")]
[OutputType(typeof(Uri))]
public class SetTenantHomeSiteCommand : ClientObjectCmdlet<ITenantHomeSiteService>
{

    [Parameter(Mandatory = true)]
    public Uri? Url { get; private set; }

    [Parameter(Mandatory = false)]
    public SwitchParameter PassThru { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
        if (this.Url.IsAbsoluteUri)
        {
            this.Service.SetObject(this.Url);
            if (this.PassThru)
            {
                this.Outputs.Add(this.Service.GetObject());
            }
        }
        else
        {
            throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
        }
    }

}
