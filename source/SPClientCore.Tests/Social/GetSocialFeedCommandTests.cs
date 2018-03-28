//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Social;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Social.Tests
{

    [TestClass()]
    [TestCategory("Social")]
    public class GetSocialFeedCommandTests
    {

        [TestMethod()]
        public void GetCurrentSocialFeed()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<SocialRestFeed>(
                    "Get-SPSocialFeed",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetSocialFeedByItem()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<SocialRestFeed>(
                    "Get-SPSocialFeed",
                    new Dictionary<string, object>()
                    {
                        { "Actor",  context.AppSettings["LoginUrl"] + "/TestWeb1/newsfeed.aspx" }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
