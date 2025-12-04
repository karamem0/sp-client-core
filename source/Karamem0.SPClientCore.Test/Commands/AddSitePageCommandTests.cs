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
public class AddSitePageCommandTests
{

    [Test()]
    public void InvokeCommand_AddItemToSite_ShouldSucceed()
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
            "Add-KshSitePage",
            new Dictionary<string, object>()
            {
                ["PageName"] = "Test Site Page 0",
                ["PageLayoutType"] = "Article"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSitePage",
            new Dictionary<string, object>()
            {
                ["PageName"] = "Test Site Page 0"
            }
        );
    }

    [Test()]
    public void InvokeCommand_AddItemToList_ShouldSucceed()
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
                ["LibraryType"] = "ClientRenderedSitePages"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshSitePage",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["PageName"] = "Test Site Page 0",
                ["PageLayoutType"] = "Article"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshSitePage",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["PageName"] = "Test Site Page 0",
            }
        );
    }

}
