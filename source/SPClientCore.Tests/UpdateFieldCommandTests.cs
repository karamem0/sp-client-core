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
    [TestCategory("Field")]
    public class UpdateFieldCommandTests
    {

        [TestMethod()]
        public void UpdateWebField()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "FieldTypeKind", FieldTypeKind.Text },
                        { "Title", "Test Field 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result1.ElementAt(0).Id },
                        { "Hidden", true },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result2.ElementAt(0).Id },
                        { "Hidden", false },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result3.ElementAt(0).Id },
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void UpdateListField()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "FieldTypeKind", FieldTypeKind.Text },
                        { "Title", "Test Field 0" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result1.ElementAt(0).Id },
                        { "Hidden", true },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result2.ElementAt(0).Id },
                        { "Hidden", false },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result3.ElementAt(0).Id }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }


    }

}
