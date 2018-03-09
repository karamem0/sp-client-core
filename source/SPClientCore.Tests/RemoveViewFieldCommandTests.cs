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
    public class RemoveViewFieldCommandTests
    {

        [TestMethod()]
        public void RemoveViewField()
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
                var result2 = context.Runspace.InvokeCommand(
                    "Add-SPViewField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id },
                        { "Name", "TestField1" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPViewField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id },
                        { "Name", "TestField1" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<View>(
                    "Get-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id },
                        { "Includes", "ViewFields" }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-SPView",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "View", result1.ElementAt(0).Id }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

    }

}
