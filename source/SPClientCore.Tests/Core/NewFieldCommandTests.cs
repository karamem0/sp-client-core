//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    [TestCategory("Field")]
    public class NewFieldCommandTests
    {

        [TestMethod()]
        public void CreateWebField()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "DefaultValue", "Test Field 0" },
                        { "Description", "Test Field 0 Description" },
                        { "Direction", "NONE" },
                        { "EnforceUniqueValues", true },
                        { "FieldTypeKind", FieldTypeKind.Text },
                        { "Group", "Test Field 0 Group" },
                        { "Hidden", true },
                        { "Indexed", true },
                        //{ "JSLink", "TestField0.js" },
                        { "ReadOnlyField", false },
                        { "Required", true },
                        { "Scope", context.AppSettings["List1Url"] },
                        { "Sortable", true },
                        { "StaticName", "TestField0" },
                        { "Title", "Test Field 0" },
                        { "ValidationFormula", "=LEN([Test Field 0])<10" },
                        { "ValidationMessage", "Test Field 0 Message" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result1.ElementAt(0).Id },
                        { "Hidden", false },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result1.ElementAt(0).Id },
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateWebFieldAsXml()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Options", "AddFieldInternalNameHint" },
                        { "SchemaXml", "<Field Name='TestField0' DisplayName='Test Field 0' Type='Text'/>" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result1.ElementAt(0).Id },
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateListField()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "DefaultValue", "Test Field 0" },
                        { "Description", "Test Field 0 Description" },
                        { "Direction", "NONE" },
                        { "EnforceUniqueValues", true },
                        { "FieldTypeKind", FieldTypeKind.Text },
                        { "Group", "Test Field 0 Group" },
                        { "Hidden", true },
                        { "Indexed", true },
                        { "JSLink", "TestField0.js" },
                        { "ReadOnlyField", false },
                        { "Required", true },
                        { "Scope", context.AppSettings["List1Url"] },
                        { "Sortable", true },
                        { "StaticName", "TestField0" },
                        { "Title", "Test Field 0" },
                        { "ValidationFormula", "=LEN([Test Field 0])<10" },
                        { "ValidationMessage", "Test Field 0 Message" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Update-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result1.ElementAt(0).Id },
                        { "Hidden", false },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateListFieldAsXml()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "New-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Options", 8 },
                        { "SchemaXml", "<Field Name='TestField0' DisplayName='Test Field 0' Type='Text'/>" }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result1.ElementAt(0).Id }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
