//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class MoveFileCommandTests
    {

        [TestMethod()]
        [TestCategory("File")]
        public void MoveFile()
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
                    "Move-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "ServerRelativeUrl", context.AppSettings["Folder1Url"] + "/TestFile9.txt" },
                        { "MoveOperations", 1 },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result2.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        [TestCategory("Attachment")]
        public void MoveAttachment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Attachment>(
                    "New-SPAttachment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "Name", "TestFile0.txt" },
                        { "Content", new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")) }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<File>(
                    "Move-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "ServerRelativeUrl", new Uri(result1.ElementAt(0).ServerRelativeUrl, UriKind.Relative).MakeParentUri().ConcatPath("TestFile9.txt") },
                        { "MoveOperations", 1 },
                        { "PassThru", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result2.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
