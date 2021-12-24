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
    [TestCategory("Remove-TermLocalCustomProperty")]
    public class RemoveTermLocalCustomPropertyCommandTests
    {

        [TestMethod()]
        public void RemoveTermLocalCustomProperty()
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
            var result2 = context.Runspace.InvokeCommand<TermGroup>(
                "Get-KshTermGroup",
                new Dictionary<string, object>()
                {
                    { "TermGroupId", context.AppSettings["TermGroup1Id"] }
                }
            );
            var result3 = context.Runspace.InvokeCommand<TermSet>(
                "Get-KshTermSet",
                new Dictionary<string, object>()
                {
                    { "TermGroup", result2.ElementAt(0) },
                    { "TermSetId", context.AppSettings["TermSet1Id"] }
                }
            );
            var result4 = context.Runspace.InvokeCommand<Term>(
                "Get-KshTerm",
                new Dictionary<string, object>()
                {
                    { "TermSet", result3.ElementAt(0) },
                    { "TermId", context.AppSettings["Term1Id"] },
                }
            );
            var result5 = context.Runspace.InvokeCommand(
                "Add-KshTermLocalCustomProperty",
                new Dictionary<string, object>()
                {
                    { "Term", result4.ElementAt(0) },
                    { "Name", "Test Property 0" },
                    { "Value", "Test Value 0" }
                }
            );
            var result6 = context.Runspace.InvokeCommand(
                "Remove-KshTermLocalCustomProperty",
                new Dictionary<string, object>()
                {
                    { "Term", result4.ElementAt(0) },
                    { "Name", "Test Property 0" }
                }
            );
            var result7 = context.Runspace.InvokeCommand<Term>(
                "Get-KshTerm",
                new Dictionary<string, object>()
                {
                    { "Identity", result4.ElementAt(0) }
                }
            );
            var actual = result7.ElementAt(0);
        }

    }

}
