//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("View")]
    public class UpdateViewCommandTests
    {

        [TestMethod()]
        public void UpdateView()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<View>(
                    "New-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Title", "Test View 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<View>(
                    "Update-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id },
                        { "Aggregations", "<FieldRef Name='LinkTitle' Type='COUNT' />" },
                        { "AggregationsStatus", "On" },
                        { "DefaultView", true },
                        { "DefaultViewForContentType", true },
                        { "EditorModified", false },
                        { "Formats", "<FormatDef Type='RowHeight' Value='100' />" },
                        { "Hidden", true },
                        { "IncludeRootFolder", true },
                        { "JSLink", "TestView0.js" },
                        { "Paged", false },
                        { "MobileDefaultView", true },
                        { "MobileView", true },
                        { "RowLimit", 10 },
                        { "Scope", ViewScope.Recursive },
                        { "Title", "Test View 9" },
                        { "Toolbar", "Standard" },
                        { "ViewData", "" },
                        { "ViewQuery", "<OrderBy><FieldRef Name='Title'/></OrderBy>" },
                        { "ViewJoins",
                            "<Join Type='LEFT' ListAlias='TestList1'>" +
                            "<Eq>" +
                            "<FieldRef Name='TestField8' RefType='Id'/>" +
                            "<FieldRef List='TestList1' Name='ID'/>" +
                            "</Eq>" +
                            "</Join>" },
                        { "ViewProjectedFields",
                            "<Field Name='TestField15' Type='Lookup' List='TestList1' ShowField='Title' />" },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void UpdateViewAsXml()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<View>(
                    "New-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Title", "Test View 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<View>(
                    "Update-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id },
                        { "ListViewXml",
                            "<Query>" +
                            "<OrderBy>" +
                            "<FieldRef Name='Title'/>" +
                            "</OrderBy>" +
                            "</Query>" +
                            "<RowLimit Paged='TRUE'>10</RowLimit>" +
                            "<JSLink>TestView0.js</JSLink>" +
                            "<Toolbar Type='None'/>" +
                            "<Aggregations Value='On'>" +
                            "<FieldRef Name='LinkTitle' Type='COUNT'/>" +
                            "</Aggregations>" +
                            "<Formats>" +
                            "<FormatDef Type='RowHeight' Value='100'/>" +
                            "</Formats>" +
                            "<Joins>" +
                            "<Join Type='LEFT' ListAlias='TestList1'>" +
                            "<Eq>" +
                            "<FieldRef Name='TestField8' RefType='Id' />" +
                            "<FieldRef List='TestList1' Name='ID' />" +
                            "</Eq>" +
                            "</Join>" +
                            "</Joins>" +
                            "<ProjectedFields>" +
                            "<Field Name='TestField15' Type='Lookup' List='TestList1' ShowField='Title'/>" +
                            "</ProjectedFields>" },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
