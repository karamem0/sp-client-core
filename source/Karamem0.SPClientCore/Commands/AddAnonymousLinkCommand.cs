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

[Cmdlet(VerbsCommon.Add, "AnonymousLink")]
[OutputType(typeof(string))]
public class AddAnonymousLinkCommand : ClientObjectCmdlet<ISharingLinkService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public Uri? Url { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public bool IsEditLink { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public DateTime Expiration { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            if (this.Url.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.CreateAnonymousLink(this.Url, this.IsEditLink));
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            if (this.Url.IsAbsoluteUri)
            {
                this.Outputs.Add(
                    this.Service.CreateAnonymousLink(
                        this.Url,
                        this.IsEditLink,
                        this.Expiration
                    )
                );
            }
            else
            {
                throw new InvalidOperationException(string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.Url));
            }
        }
    }

}
