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
    [TestCategory("File")]
    public class UpdateFileCommandTests
    {

        [TestMethod()]
        public void CheckOutAndCheckInFile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "New-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] },
                        { "Name", "TestFile0.txt" },
                        { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) },
                        { "Overwrite", true }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<File>(
                    "Update-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "CheckOut", true },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<File>(
                    "Update-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "CheckIn", true },
                        { "Comment", "TestFile0" },
                        { "CheckInType", 1 },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CheckOutAndUndoCheckOutFile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "New-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] },
                        { "Name", "TestFile0.txt" },
                        { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) },
                        { "Overwrite", true }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<File>(
                    "Update-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "CheckOut", true },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<File>(
                    "Update-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "UndoCheckOut", true },
                        { "PassThru", true }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

    }

}
