//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class AddDocumentSetDefaultDocumentCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = "0x0120D520"
            }
        );
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Description"] = "Test Content Type 0 Description",
                ["Group"] = "Test Content Type 0 Group",
                ["Name"] = "Test Content Type 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = "0x0101"
            }
        );
        _ = context.Runspace.InvokeCommand<DefaultDocument>(
            "Add-KshDocumentSetDefaultDocument",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["DocumentContentType"] = result3[0],
                ["Content"] = Encoding.UTF8.GetBytes("TestFile0"),
                ["FileName"] = "/TestFile0.txt",
                ["PushChanges"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshDocumentSetDefaultDocument",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result3[0],
                ["FileName"] = result3[0].Name
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

}
