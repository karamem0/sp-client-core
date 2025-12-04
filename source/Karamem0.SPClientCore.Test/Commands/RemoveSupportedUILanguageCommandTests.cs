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
public class RemoveSupportedUILanguageCommandTests
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
            "Add-KshSupportedUILanguage",
            new Dictionary<string, object>()
            {
                ["Lcid"] = 1041
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSupportedUILanguage",
            new Dictionary<string, object>()
            {
                ["Lcid"] = 1041
            }
        );
        var result1 = context.Runspace.InvokeCommand<Site>(
            "Get-KshCurrentSite",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
