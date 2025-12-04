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
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddTermStoreLanguageCommandTests
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
        _ = context.Runspace.InvokeCommand(
            "Add-KshTermStoreLanguage",
            new Dictionary<string, object>()
            {
                ["Lcid"] = 1036
            }
        );
        Thread.Sleep(TimeSpan.FromSeconds(15));
        var result1 = context.Runspace.InvokeCommand<TermStore>(
            "Get-KshTermStore",
            new Dictionary<string, object>()
            {
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshTermStoreLanguage",
            new Dictionary<string, object>()
            {
                ["Lcid"] = 1036
            }
        );
        var actual = result1[0];
        Assert.That(actual, Is.Not.Null);
    }

}
