//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    public class AddDocumentSetCommandTests
    {

        [TestMethod()]
        public void AddDocumentSet()
        {
            using var context = new PSCmdletContext();
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
            var result2 = context.Runspace.InvokeCommand<List>(
                "Get-KshList",
                new Dictionary<string, object>()
                {
                    { "ListUrl", context.AppSettings["List3Url"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "List", result2.ElementAt(0) }
                }
            );
            var result4 = context.Runspace.InvokeCommand<ContentType>(
                "Get-KshContentType",
                new Dictionary<string, object>()
                {
                    { "ContentTypeId", context.AppSettings["ListContentType7Id"] },
                    { "List", result2.ElementAt(0) }
                }
            );
            var result5 = context.Runspace.InvokeCommand<string>(
                "Add-KshDocumentSet",
                new Dictionary<string, object>()
                {
                    { "Folder", result3.ElementAt(0) },
                    { "Name", "Test Document Set 0" },
                    { "ContentType", result4.ElementAt(0) }
                }
            );
            var result6 = context.Runspace.InvokeCommand<Folder>(
                "Get-KshFolder",
                new Dictionary<string, object>()
                {
                    { "FolderUrl", result5.ElementAt(0) }
                }
            );
            var result7 = context.Runspace.InvokeCommand(
                "Remove-KshFolder",
                new Dictionary<string, object>()
                {
                    { "Identity", result6.ElementAt(0) }
                }
            );
            var actual = result5.ElementAt(0);
        }

    }

}
