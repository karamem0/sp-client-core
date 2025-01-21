//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Tests;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class RemoveTenantSiteScriptCommandTests
{

    [Test()]
    public void InvokeCommand_RemoveItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AdminUrl"] },
                { "ClientId", context.AppSettings["ClientId"] },
                { "CertificatePath", context.AppSettings["CertificatePath"] },
                { "CertificatePassword", context.AppSettings["CertificatePassword"].ToSecureString() }
            }
        );
        var result1 = context.Runspace.InvokeCommand<TenantSiteScript>(
            "Add-KshTenantSiteScript",
            new Dictionary<string, object>()
            {
                { "Content", /*lang=json,strict*/ "{\"actions\":[{\"verb\":\"createSPList\",\"listName\":\"Test List 0\",\"templateType\":101,\"subactions\":[]}]}" },
                { "Title", "Test Site Script 0" }
            }
        );
        _ = context.Runspace.InvokeCommand<HubSite>(
            "Remove-KshTenantSiteScript",
            new Dictionary<string, object>()
            {
                { "Identity", result1.ElementAt(0) }
            }
        );
    }

}
