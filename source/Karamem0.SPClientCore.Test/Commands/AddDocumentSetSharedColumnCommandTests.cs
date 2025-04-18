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
public class AddDocumentSetSharedColumnCommandTests
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
        var result1 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = context.AppSettings["SiteContentType7Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                ["ColumnId"] = context.AppSettings["Column9Id"]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshDocumentSetSharedColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Column"] = result2[0]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshDocumentSetSharedColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshDocumentSetSharedColumn",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Column"] = result2[0]
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
