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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveTenantSiteDesignCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AdminUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantSiteDesign>(
            "Add-KshTenantSiteDesign",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test Site Design 0",
                ["DesignPackageId"] = Guid.Empty,
                ["IsDefault"] = false,
                ["PreviewImageAltText"] = null,
                ["PreviewImageUrl"] = null,
                ["SiteScriptIds"] = new[]
                {
                    context.AppSettings["SiteScript1Id"]
                },
                ["SiteTemplate"] = null,
                ["ThumbnailUrl"] = null,
                ["Title"] = "Test Site Design 0",
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantSiteDesign",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
    }

}
