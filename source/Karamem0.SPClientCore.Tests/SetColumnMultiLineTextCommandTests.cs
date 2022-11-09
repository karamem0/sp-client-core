//
// Copyright (c) 2022 karamem0
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
    public class SetColumnMultiLineTextCommandTests
    {

        [TestMethod()]
        public void SetListColumnMultiLineText()
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
            var result3 = context.Runspace.InvokeCommand<ColumnMultiLineText>(
                "Add-KshColumnMultiLineText",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) },
                    { "Name", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "AddColumnInternalNameHint", true },
                    { "AddToDefaultView", true }
                }
            );
            var result4 = context.Runspace.InvokeCommand<ColumnMultiLineText>(
                "Set-KshColumnMultiLineText",
                new Dictionary<string, object>()
                {
                    { "Identity", result3.ElementAt(0) },
                    // { "ClientSideComponentId", null },
                    // { "ClientSideComponentProperties", null },
                    { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                    { "DefaultValue", "Test Value 0" },
                    { "Direction", "none" },
                    { "Description", "Test Column 0 Description" },
                    { "Group", "Test Group 0" },
                    { "Hidden", true },
                    { "JSLink", "clienttemplates.js" },
                    { "NoCrawl", true },
                    { "NumberOfLines", 10 },
                    { "ReadOnly", true },
                    { "Required", true },
                    { "RestrictedMode", true },
                    { "RichText", true },
                    { "RichTextMode", "FullHtml" },
                    { "StaticName", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "PassThru", true }
                }
            );
            var result5 = context.Runspace.InvokeCommand(
                "Set-KshColumnMultiLineText",
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
        public void SetSiteColumnMultiLineText()
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
            var result2 = context.Runspace.InvokeCommand<ColumnMultiLineText>(
                "Add-KshColumnMultiLineText",
                new Dictionary<string, object>()
                {
                    { "Name", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "AddColumnInternalNameHint", true },
                    { "AddToDefaultView", true }
                }
            );
            var result3 = context.Runspace.InvokeCommand<ColumnMultiLineText>(
                "Set-KshColumnMultiLineText",
                new Dictionary<string, object>()
                {
                    { "Identity", result2.ElementAt(0) },
                    // { "ClientSideComponentId", null },
                    // { "ClientSideComponentProperties", null },
                    { "CustomFormatter", "{ \"txtContent\": \"@currentField\" }" },
                    { "DefaultValue", "Test Value 0" },
                    { "Direction", "none" },
                    { "Description", "Test Column 0 Description" },
                    { "Group", "Test Group 0" },
                    { "Hidden", true },
                    { "JSLink", "clienttemplates.js" },
                    { "NoCrawl", true },
                    { "NumberOfLines", 10 },
                    { "ReadOnly", true },
                    { "Required", true },
                    { "RestrictedMode", true },
                    { "RichText", true },
                    { "RichTextMode", "FullHtml" },
                    { "StaticName", "TestColumn0" },
                    { "Title", "Test Column 0" },
                    { "PassThru", true }
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Set-KshColumnMultiLineText",
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
