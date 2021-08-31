//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Remove-KshFile")]
    public class RemoveFileCommandTests
    {

        [TestMethod()]
        public void RemoveFile()
        {
            using (var context = new PSCmdletContext())
            {
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
                var result2 = context.Runspace.InvokeCommand<Folder>(
                    "Get-KshFolder",
                    new Dictionary<string, object>()
                    {
                        { "FolderUrl", context.AppSettings["Folder1Url"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<File>(
                    "New-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                        { "FileName", "TestFile0.txt" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) }
                    }
                );
            }
        }

        [TestMethod()]
        public void MoveFileToRecycleBin()
        {
            using (var context = new PSCmdletContext())
            {
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
                var result2 = context.Runspace.InvokeCommand<Folder>(
                    "Get-KshFolder",
                    new Dictionary<string, object>()
                    {
                        { "FolderUrl", context.AppSettings["Folder1Url"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<File>(
                    "New-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                        { "FileName", "TestFile0.txt" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<Guid>(
                    "Remove-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "RecycleBin", true }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<RecycleBinItem>(
                    "Get-KshRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "ItemId", result4.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshRecycleBinItem",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result5.ElementAt(0) }
                    }
                );
                var actual = result4.ElementAt(0);
            }
        }

    }

}
