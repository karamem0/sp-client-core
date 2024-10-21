//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class AddRoleDefinitionCommandTests
{

    [Test()]
    public void AddRoleDefinition()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["BaseUrl"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<BasePermission>(
            "New-KshBasePermission",
            new Dictionary<string, object>()
            {
                { "Permission", "EmptyMask" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<RoleDefinition>(
            "Add-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                { "BasePermission", result2.ElementAt(0) },
                { "Description", "Test Role Definition 0 Description" },
                { "Name", "Test Role Definition 0" },
                { "Order", 0 }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshRoleDefinition",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
