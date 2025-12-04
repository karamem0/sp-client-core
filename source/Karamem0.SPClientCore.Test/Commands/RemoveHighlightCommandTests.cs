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
public class RemoveHighlightCommandTests
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List2Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<View>(
            "Add-KshView",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["Title"] = "Test View 0",
                ["ViewColumns"] = new List<string>()
                {
                    "Title",
                    "Modified",
                    "Editor",
                    "Created",
                    "Author"
                }
            }
        );
        _ = context.Runspace.InvokeCommand<HighlightResult>(
            "Add-KshHighlight",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["ItemId"] = context.AppSettings["Folder1ListItemId"],
                ["FolderPath"] = context.AppSettings["List2Url"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<HighlightResult>(
            "Remove-KshHighlight",
            new Dictionary<string, object>()
            {
                ["View"] = result2[0],
                ["ItemId"] = context.AppSettings["Folder1ListItemId"],
                ["FolderPath"] = context.AppSettings["List2Url"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshView",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
