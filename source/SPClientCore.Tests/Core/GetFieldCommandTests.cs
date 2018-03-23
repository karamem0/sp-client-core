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
    public class GetFieldCommandTests
    {

        [TestMethod()]
        public void GetWebFieldByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", context.AppSettings["Field1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebFieldById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", context.AppSettings["Field1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebFieldByInternalName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", context.AppSettings["Field1Name"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetWebFieldByTitle()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "Field", context.AppSettings["Field1Title"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListFieldByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", context.AppSettings["Field1Id"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListFieldById()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", context.AppSettings["Field1Id"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListFieldByInternalName()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", context.AppSettings["Field1Name"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetListFieldByTitle()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Field>(
                    "Get-SPField",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "Field", context.AppSettings["Field1Title"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
