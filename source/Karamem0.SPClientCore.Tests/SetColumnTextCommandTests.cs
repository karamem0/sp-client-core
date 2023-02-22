//
// Copyright (c) 2023 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class SetColumnTextCommandTests
    {

        [TestMethod()]
        public void SetListColumnText()
        {
            using var context = new PSCmdletContext();
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
            var result3 = context.Runspace.InvokeCommand<ColumnText>(
                "Add-KshColumnText",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "Name", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "AddColumnInternalNameHint", true },
                    { "AddToDefaultView", true }
                }
            );
            var result4 = context.Runspace.InvokeCommand<ColumnText>(
                "Set-KshColumnText",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) },
                    // { "ClientSideComponentId", null },
                    // { "ClientSideComponentProperties", null },
                    { "ClientValidationFormula", "=FALSE" },
                    { "ClientValidationMessage", "ERROR" },
                    { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                    { "DefaultValue", "Test Value 0" },
                    { "EnforceUniqueValues", true },
                    { "Direction", "none" },
                    { "Description", "Test Column 0 Description" },
                    { "Group", "Test Group 0" },
                    { "Hidden", true },
                    { "Indexed", true },
                    { "JSLink", "clienttemplates.js" },
                    { "MaxLength", 128 },
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
                "Set-KshColumnText",
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

        [TestMethod()]
        public void SetSiteColumnText()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<ColumnText>(
                "Add-KshColumnText",
                new Dictionary<string, object>()
                {
                    { "Name", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "AddColumnInternalNameHint", true },
                    { "AddToDefaultView", true }
                }
            );
            var result3 = context.Runspace.InvokeCommand<ColumnText>(
                "Set-KshColumnText",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) },
                    // { "ClientSideComponentId", null },
                    // { "ClientSideComponentProperties", null },
                    { "ClientValidationFormula", "=TRUE" },
                    { "ClientValidationMessage", "ERROR" },
                    { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                    { "DefaultValue", "Test Value 0" },
                    { "EnforceUniqueValues", true },
                    { "Direction", "none" },
                    { "Description", "Test Column 0 Description" },
                    { "Group", "Test Group 0" },
                    { "Hidden", true },
                    { "Indexed", true },
                    { "JSLink", "clienttemplates.js" },
                    { "MaxLength", 128 },
                    { "NoCrawl", true },
                    { "ReadOnly", true },
                    { "Required", true },
                    { "StaticName", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "ValidationFormula", "=TRUE" },
                    { "ValidationMessage", "ERROR" },
                    { "PassThru", true }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Set-KshColumnText",
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
