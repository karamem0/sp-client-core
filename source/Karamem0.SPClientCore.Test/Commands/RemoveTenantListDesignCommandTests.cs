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
public class RemoveTenantListDesignCommandTests
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
        var result1 = context.Runspace.InvokeCommand<TenantListDesign>(
            "Add-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test List Design 0",
                ["ListColor"] = "DarkRed",
                ["ListIcon"] = "CubeShape",
                ["SiteScriptIds"] = new[]
                {
                    context.AppSettings["ListScript1Id"]
                },
                ["TemplateFeatures"] = null,
                ["ThumbnailUrl"] = null,
                ["Title"] = "Test List Design 0",
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTenantListDesign",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
    }

}
