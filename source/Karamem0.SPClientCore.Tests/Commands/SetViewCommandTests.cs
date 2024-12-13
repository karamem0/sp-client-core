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
public class SetViewCommandTests
{

    [Test()]
    public void SetView()
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
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                { "ListId", context.AppSettings["List1Id"] }
            }
        );
        var result2 = context.Runspace.InvokeCommand<View>(
            "Add-KshView",
            new Dictionary<string, object>()
            {
                { "List", result1.ElementAt(0) },
                { "Title", "Test View 0" },
                { "ViewColumns", "Title" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<View>(
            "Set-KshView",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "Aggregations", "<FieldRef Name='LinkTitle' Type='COUNT' />" },
                { "AggregationsStatus", "On" },
                { "AssociatedContentTypeId", null },
                { "CalendarViewStyles", null },
                { "DefaultView", true },
                { "DefaultViewForContentType", true },
                { "EditorModified", false },
                { "Formats", "<FormatDef Type='RowHeight' Value='100' />" },
                { "GridLayout", null },
                { "Hidden", true },
                { "IncludeRootFolder", true },
                { "JSLink", "clienttemplates.js" },
                { "MobileDefaultView", true },
                { "MobileView", true },
                { "NewDocumentTemplates", context.AppSettings["Site1Url"] + "/TestList0/Forms/template.dotx" },
                { "RowLimit", 10 },
                { "Paged", false },
                { "Scope", ViewScope.Recursive },
                { "TabularView", false },
                { "Title", "Test View 9" },
                { "Toolbar", "Standard" },
                { "ViewData", "" },
                { "ViewJoins",
                    "<Join Type='LEFT' ListAlias='TestList1'>" +
                    "<Eq>" +
                    "<FieldRef Name='TestColumn8' RefType='Id'/>" +
                    "<FieldRef List='TestList1' Name='ID'/>" +
                    "</Eq>" +
                    "</Join>" },
                { "ViewProjectedColumns", "<Field Name='TestColumn16' Type='Lookup' List='TestList1' ShowField='Title'/>" },
                { "ViewQuery", "<OrderBy><FieldRef Name='Title'/></OrderBy>" },
                { "ViewType2", null },
                { "PassThru", true }
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshView",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
