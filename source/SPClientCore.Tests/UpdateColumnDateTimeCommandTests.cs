//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Update-KshColumnDateTime")]
    public class UpdateColumnDateTimeCommandTests
    {

        [TestMethod()]
        public void UpdateListColumnDateTime()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<List>(
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ColumnDateTime>(
                    "New-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "List", result2.ElementAt(0) },
                        { "Name", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "AddColumnInternalNameHint", true },
                        { "AddToDefaultView", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<ColumnDateTime>(
                    "Update-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "ClientValidationFormula", "=FALSE" },
                        { "ClientValidationMessage", "ERROR" },
                        { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                        { "DefaultValue", "2010/12/15 15:00:00" },
                        { "Direction", "none" },
                        { "Description", "Test Column 0 Description" },
                        { "EnforceUniqueValues", false },
                        { "Group", "Test Group 0" },
                        { "Hidden", true },
                        { "Indexed", false },
                        { "JSLink", "clienttemplates.js" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "ValidationFormula", "=FALSE" },
                        { "ValidationMessage", "ERROR" },
                        { "PassThru", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Update-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

        [TestMethod()]
        public void UpdateSiteColumnDateTime()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ColumnDateTime>(
                    "New-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "Name", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "AddColumnInternalNameHint", true },
                        { "AddToDefaultView", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ColumnDateTime>(
                    "Update-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "ClientValidationFormula", "=FALSE" },
                        { "ClientValidationMessage", "ERROR" },
                        { "CalendarType", "Japan" },
                        { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                        { "DefaultValue", "2010/12/15 15:00:00" },
                        { "DateFormat", "DateTime" },
                        { "Direction", "none" },
                        { "Description", "Test Column 0 Description" },
                        { "EnforceUniqueValues", false },
                        { "FriendlyFormat", "Disabled" },
                        { "Group", "Test Group 0" },
                        { "Hidden", true },
                        { "Indexed", false },
                        { "JSLink", "clienttemplates.js" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "ValidationFormula", "=FALSE" },
                        { "ValidationMessage", "ERROR" },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Update-KshColumnDateTime",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
