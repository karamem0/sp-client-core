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

[Cmdlet(VerbsCommon.Get, "SharingInfo")]
[OutputType(typeof(SharingInfo))]
public class GetSharingInfoCommand : ClientObjectCmdlet<ISharingLinkService>
{

    [Parameter(Mandatory = true)]
    public Uri? Url { get; private set; }

    [Parameter(Mandatory = false)]
    public bool CheckForAccessRequests { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExcludeCurrentUser { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExcludeSecurityGroups { get; private set; }

    [Parameter(Mandatory = false)]
    public bool ExcludeSiteAdmin { get; private set; }

    [Parameter(Mandatory = false)]
    public bool RetrieveAnonymousLinks { get; private set; }

    [Parameter(Mandatory = false)]
    public bool RetrievePermissionLevels { get; private set; }

    [Parameter(Mandatory = false)]
    public bool RetrieveUserInfoDetails { get; private set; }

    protected override void ProcessRecordCore()
    {
        _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
        if (this.Url.IsAbsoluteUri)
        {
            this.Outputs.Add(
                this.Service.GetSharingInfo(
                    this.Url,
                    this.ExcludeCurrentUser,
                    this.ExcludeSiteAdmin,
                    this.ExcludeSecurityGroups,
                    this.RetrieveAnonymousLinks,
                    this.RetrieveUserInfoDetails,
                    this.CheckForAccessRequests,
                    this.RetrievePermissionLevels
                )
            );
        }
        else
        {
            throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
        }
    }

}
