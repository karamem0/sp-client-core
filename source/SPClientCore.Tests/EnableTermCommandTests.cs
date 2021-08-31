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
    [TestCategory("Enable-KshTerm")]
    public class EnableTermCommandTests
    {

        [TestMethod()]
        public void EnableTerm()
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
                        { "TermId", context.AppSettings["Term1Id"] }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Disable-KshTerm",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand<Term>(
                    "Enable-KshTerm",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) },
                        { "PassThru", true }
                    }
                );
                var actual = result6.ElementAt(0);
            }
        }

    }

}
