// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
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
    public class CopyFileCommandTests
    {

        [TestMethod()]
        [TestCategory("File")]
        public void CopyFile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<File>(
                    "Copy-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", context.AppSettings["File1Url"] },
                        { "ServerRelativeUrl", context.AppSettings["Folder1Url"] + "/TestFile0.txt" },
                        { "Overwrite", true },
                        { "PassThru", true }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Remove-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        [TestCategory("Attachment")]
        public void CopyAttachment()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Attachment>(
                    "Get-SPAttachment",
                    new Dictionary<string, object>()
                    {
                        { "List", context.AppSettings["List1Id"] },
                        { "ListItem", context.AppSettings["ListItem1Id"] },
                        { "Attachment", context.AppSettings["Attachment1Name"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<File>(
                    "Copy-SPFile",
                    new Dictionary<string, object>()
                    {
                        { "File", result1.ElementAt(0).ServerRelativeUrl },
                        { "ServerRelativeUrl", new Uri(result1.ElementAt(0).ServerRelativeUrl, UriKind.Relative).MakeParentUri().ConcatPath("TestFile9.txt") },
                        { "Overwrite", true },
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
