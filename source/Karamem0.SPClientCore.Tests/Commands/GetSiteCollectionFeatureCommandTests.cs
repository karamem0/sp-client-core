//
// Copyright (c) 2018-2024 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

[TestClass()]
public class GetSiteCollectionFeatureCommandTests
{

    [TestMethod()]
    public void GetSiteCollectionFeatures()
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
            }
        );
        var actual = result2.ToArray();
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteCollectionFeatureByIdentity()
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "88dc6e04-3256-401b-9851-8e07674bb0d6" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.IsNotNull(actual);
    }

    [TestMethod()]
    public void GetSiteCollectionFeatureByFeatureId()
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
        var result2 = context.Runspace.InvokeCommand<Feature>(
            "Get-KshSiteCollectionFeature",
            new Dictionary<string, object>()
            {
                { "FeatureId", "88dc6e04-3256-401b-9851-8e07674bb0d6" }
            }
        );
        var actual = result2.ElementAt(0);
        Assert.IsNotNull(actual);
    }

}
