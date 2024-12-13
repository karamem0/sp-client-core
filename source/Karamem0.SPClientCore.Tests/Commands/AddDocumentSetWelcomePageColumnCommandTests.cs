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
public class AddDocumentSetWelcomePageColumnCommandTests
{

    [Test()]
    public void AddDocumentSetWelcomePageColumn()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                { "ContentTypeId", context.AppSettings["SiteContentType7Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<Column>(
            "Get-KshColumn",
            new Dictionary<string, object>()
            {
                { "ColumnId", context.AppSettings["Column9Id"] }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshDocumentSetWelcomePageColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result1.ElementAt(0) },
                { "Column", result2.ElementAt(0) }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Column>(
            "Get-KshDocumentSetWelcomePageColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result1.ElementAt(0) }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshDocumentSetWelcomePageColumn",
            new Dictionary<string, object>()
            {
                { "ContentType", result1.ElementAt(0) },
                { "Column", result2.ElementAt(0) }
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
