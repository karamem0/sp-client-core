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
public class AddListCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                ["Description"] = "Test List 0 Description",
                ["QuickLaunchOption"] = "On",
                ["ServerRelativeUrl"] = "Lists/TestList0",
                ["Template"] = "DocumentLibrary",
                ["Title"] = "Test List 0"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                ["Identity"] = result1[0]
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
