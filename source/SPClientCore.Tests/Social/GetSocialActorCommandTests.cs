//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models.Search;
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
    public class GetSocialActorCommandTests
    {

        [TestMethod()]
        public void GetCurrentSocialActor()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<SocialRestActor>(
                    "Get-SPSocialActor",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetSocialActorByItem()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<SocialRestActor>(
                    "Get-SPSocialActor",
                    new Dictionary<string, object>()
                    {
                        { "Actor", context.AppSettings["User1LoginName"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
