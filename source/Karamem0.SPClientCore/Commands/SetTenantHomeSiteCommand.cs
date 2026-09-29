//
// Copyright (c) 2018-2026 karamem0
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

    protected override async Task ProcessRecordAsync()
    {
        _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
        if (this.Url.IsAbsoluteUri)
        {
            await this.Service.SetObjectAsync(this.Url);
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync());
            }
        }
        else
        {
            throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
        }
    }

}
