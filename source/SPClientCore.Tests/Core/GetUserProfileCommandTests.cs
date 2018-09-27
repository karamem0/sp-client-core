﻿//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

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
    [TestCategory("ProfileLoader")]
    public class GetUserProfileCommandTests
    {

        [TestMethod()]
        public void GetMyUserProfile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<UserProfile>(
                    "Get-SPUserProfile",
                    new Dictionary<string, object>()
                    {
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetOwnerUserProfile()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<UserProfile>(
                    "Get-SPUserProfile",
                    new Dictionary<string, object>()
                    {
                        { "Owner", true }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}