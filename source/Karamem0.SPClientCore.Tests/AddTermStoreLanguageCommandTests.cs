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
    public class AddTermStoreCommandLanguageTests
    {

        [TestMethod()]
        public void AddTermStoreLanguage()
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
            var result2 = context.Runspace.InvokeCommand(
                "Add-KshTermStoreLanguage",
                new Dictionary<string, object>()
                {
                    { "Lcid", 1036 }
                }
            );
            var result3 = context.Runspace.InvokeCommand<TermStore>(
                "Get-KshTermStore",
                new Dictionary<string, object>()
                {
                }
            );
            var result4 = context.Runspace.InvokeCommand(
                "Remove-KshTermStoreLanguage",
                new Dictionary<string, object>()
                {
                    { "Lcid", 1036 }
                }
            );
            var actual = result3.ElementAt(0);
        }

    }

}
