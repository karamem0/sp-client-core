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
    [TestCategory("File")]
    public class RemoveFileCommandTests
    {

        [TestMethod()]
        public void RemoveFile()
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
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl }
                    }
                );
            }
        }

        [TestMethod()]
        public void RecycleFile()
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
                var result2 = context.Runspace.InvokeCommand<GuidResult>(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "RecycleBin", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-SPRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "RecycleBinItem", result2.ElementAt(0).Recycle }
                    }
                );
            }
        }

    }

}
