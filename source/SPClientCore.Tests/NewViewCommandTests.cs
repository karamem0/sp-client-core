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
    public class NewViewCommandTests
    {

        [TestMethod()]
        public void CreateView()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<View>(
                    "New-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Aggregations", "<FieldRef Name='LinkTitle' Type='COUNT' />" },
                        { "AggregationsStatus", "On" },
                        { "DefaultView", false },
                        { "DefaultViewForContentType", false },
                        { "EditorModified", true },
                        { "Formats", "<FormatDef Type='RowHeight' Value='100' />" },
                        { "Hidden", false },
                        { "IncludeRootFolder", true },
                        { "JSLink", "TestView0.js" },
                        { "Paged", true },
                        { "MobileDefaultView", false },
                        { "MobileView", false },
                        { "PersonalView", false },
                        { "RowLimit", 10 },
                        { "Scope", ViewScope.Recursive },
                        { "Title", "Test View 0" },
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
                        { "ViewType", "HTML" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
