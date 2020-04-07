//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
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
    [TestCategory("Remove-KshDocumentSetAllowedContentType")]
    public class RemoveDocumentSetAllowedContentTypeCommandTests
    {

        [TestMethod()]
        public void RemoveDocumentSetAllowedContentType()
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
                        { "ContentTypeId", "0x0101009D1CB255DA76424F860D91F20E6C4118" }
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
                var result5 = context.Runspace.InvokeCommand(
                    "Add-KshDocumentSetAllowedContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result4.ElementAt(0) },
                        { "AllowedContentType", result2.ElementAt(0) },
                        { "PushChanges", true }
                    }
                );
                var result6 = context.Runspace.InvokeCommand(
                    "Remove-KshDocumentSetAllowedContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result4.ElementAt(0) },
                        { "AllowedContentType", result2.ElementAt(0) }
                    }
                );
                var result7 = context.Runspace.InvokeCommand<ContentTypeId>(
                    "Get-KshDocumentSetAllowedContentType",
                    new Dictionary<string, object>()
                    {
                        { "ContentType", result4.ElementAt(0) }
                    }
                );
                var actual = result7.ToArray();
            }
        }


    }

}
