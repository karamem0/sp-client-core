//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("New-KshOrganizationSharingLink")]
    public class NewOrganizationSharingLinkCommandTests
    {

        [TestMethod()]
        public void CreateOrganizationSharingLink()
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
                var result2 = context.Runspace.InvokeCommand<string>(
                    "New-KshOrganizationSharingLink",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                        { "IsEditLink", true }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Remove-KshOrganizationSharingLink",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["File1Url"] },
                        { "IsEditLink", true },
                        { "RemoveAssociatedSharingLinkGroup", true }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
