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
    [TestCategory("Remove-KshDocumentSetDefaultDocument")]
    public class RemoveDocumentSetDefaultDocumentCommandTests
    {

        [TestMethod()]
        public void RemoveDocumentSetDefaultDocument()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["BaseUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-KshContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentTypeId", "0x0101" }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
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
                var result4 = context.Runspace.InvokeCommand<ContentType>(
                    "Get-KshContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentTypeId", context.AppSettings["SiteContentType7Id"] }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<DefaultDocument>(
                    "New-KshDocumentSetDefaultDocument",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result4.ElementAt(0) },
                        { "DocumentContentType", result2.ElementAt(0) },
                        { "Content", Encoding.UTF8.GetBytes("TestFile0") },
                        { "FileName", "TestFile0.txt" },
                        { "PushChanges", true }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshDocumentSetDefaultDocument",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result4.ElementAt(0) },
                        { "FileName", result5.ElementAt(0).Name }
                    }
                );
            }
        }


    }

}
