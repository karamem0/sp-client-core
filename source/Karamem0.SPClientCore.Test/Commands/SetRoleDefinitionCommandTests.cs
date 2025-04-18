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
public class SetRoleDefinitionCommandTests
{

    [Test()]
    public void InvokeCommand_SetItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<BasePermission>(
            "New-KshBasePermission",
            new Dictionary<string, object>()
            {
                ["Permission"] = "EmptyMask"
            }
        );
        var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Add-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["BasePermission"] = result1[0],
                ["Name"] = "Test Role Definition 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<BasePermission>(
            "New-KshBasePermission",
            new Dictionary<string, object>()
            {
                ["Permission"] = "ViewListItems"
            }
        );
        var result4 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Set-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0],
                ["BasePermission"] = result3[0],
                ["Name"] = "Test Role Definition 0",
                ["Description"] = "Test Role Definition 9 Description",
                ["Order"] = 1,
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

}
