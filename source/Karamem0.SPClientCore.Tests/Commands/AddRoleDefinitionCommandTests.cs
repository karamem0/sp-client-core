//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddRoleDefinitionCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["BaseUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<BasePermission>(
            "New-KshBasePermission",
            new Dictionary<string, object>()
            {
                { "Permission", "EmptyMask" }
            }
        );
        var result2 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Add-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                { "BasePermission", result1.ElementAt(0) },
                { "Description", "Test Role Definition 0 Description" },
                { "Name", "Test Role Definition 0" },
                { "Order", 0 }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
