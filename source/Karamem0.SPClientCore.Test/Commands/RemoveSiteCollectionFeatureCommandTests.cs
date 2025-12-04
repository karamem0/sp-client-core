//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveSiteCollectionFeatureCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                ["FeatureId"] = "b21b090c-c796-4b0f-ac0f-7ef1659c20ae",
                ["Force"] = false,
                ["Scope"] = "None"
            }
        );
        var result1 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                ["FeatureId"] = "b21b090c-c796-4b0f-ac0f-7ef1659c20ae"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0],
                ["Force"] = false
            }
        );
    }

}
